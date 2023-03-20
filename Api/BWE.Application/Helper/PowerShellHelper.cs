using BWE.Application.IHelper;
using BWE.Application.IService;
using BWE.Domain.ViewModel;
using System.Management.Automation;
using System.Management.Automation.Runspaces;
using System.Security;
using System.Text;
using BWE.Domain.Model;
using BWE.Application.Enum;
using BWE.Application.Mail;
using Hangfire;
using System.Xml;

namespace BWE.Application.Helper
{
    public class PowerShellHelper : IPowerShellHelper
    {
        private readonly IScriptHistoryService _scriptHistoryService;
        private readonly IMailHelper _mailHelper;

        public PowerShellHelper(IScriptHistoryService scriptHistoryService, IMailHelper mailHelper)
        {
            _scriptHistoryService = scriptHistoryService;
            _mailHelper = mailHelper;
        }
        [AutomaticRetry(Attempts = 0, LogEvents = false, OnAttemptsExceeded = AttemptsExceededAction.Fail)]
        public async Task RunPowerShellScript(ScriptViewModel script, string XmlParameters, int userId)
        {
            var scriptHistory = new ScriptHistoryModel();
            var securestring = new SecureString();
            StringBuilder parameter = new StringBuilder();
            if (!string.IsNullOrEmpty(XmlParameters))
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.LoadXml(XmlParameters);
                XmlNodeList nodeList = xmlDoc.GetElementsByTagName("parameters");
                foreach (XmlNode node in nodeList)
                {
                    if (node.HasChildNodes)
                    {
                        for (int i = 0; i < node.ChildNodes.Count; i++)
                        {
                            parameter.Append($"New-Variable -Name {node.ChildNodes[i].Name} -Value {node.ChildNodes[i].InnerText} {System.Environment.NewLine}");
                        }
                    }
                }
            }
            
            var content = $"{parameter.ToString()} {System.Environment.NewLine} {script.Content}";
            foreach (Char c in PasswordHelper.DecodePassword(script.Server.Password))
            {
                securestring.AppendChar(c);
            }
            PSCredential creds = new PSCredential(script.Server.UserName, securestring);
            WSManConnectionInfo connectionInfo = new WSManConnectionInfo();

            connectionInfo.ComputerName = script.Server.MachineName;
            connectionInfo.Credential = creds;
            Runspace runspace = RunspaceFactory.CreateRunspace(connectionInfo);
            try
            {
                runspace.Open();
                using (PowerShell ps = PowerShell.Create())
                {
                    ps.Runspace = runspace;
                    ps.AddScript(content);
                    //ps.AddArgument(script.Parameter);
                    StringBuilder sb = new StringBuilder();
                    scriptHistory = await _scriptHistoryService.AddReturn(new ScriptHistoryModel()
                    {
                        ScriptId = (int)script.Id,
                        Status = (int)ScriptHistoryStatusEnum.Running,
                        CreatedBy = userId,
                        UpdatedBy = userId,
                    });
                    var results = ps.Invoke();
                    foreach (var x in results)
                    {
                        sb.AppendLine(x.ToString());
                    }
                    scriptHistory.Status = (int)ScriptHistoryStatusEnum.Completed;
                    scriptHistory.Output = sb.ToString();
                    scriptHistory.CreatedBy = userId;
                    scriptHistory.UpdatedBy = userId;
                    await _scriptHistoryService.Update(scriptHistory);
                    if(!string.IsNullOrEmpty(script.SendTo))
                    {
                        BackgroundJob.Enqueue(() => _mailHelper.SendEmail(
                            script.SendTo,
                            "Script Execution", $"Script with id <b>{script.Id}</b> has been executed successfully  <br/>" +
                            $"<b>Output:</b>  <br/> {sb.ToString()}"
                            ));
                    }
                }
                runspace.Close();
            }
            catch(System.Exception ex)
            {
                if (scriptHistory.Id != 0)
                {
                    scriptHistory.Status = (int)ScriptHistoryStatusEnum.Failed;
                    scriptHistory.Output = ex.Message;
                    scriptHistory.UpdatedBy = userId;
                    await _scriptHistoryService.Update(scriptHistory);
                }
                else
                {
                    await _scriptHistoryService.AddReturn(new ScriptHistoryModel()
                    {
                        ScriptId = (int)script.Id,
                        Status = (int)ScriptHistoryStatusEnum.Failed,
                        Output = ex.Message,
                        CreatedBy = userId,
                        UpdatedBy = userId,
                    });
                }
                runspace.Close();
                if (!string.IsNullOrEmpty(script.SendTo))
                {
                    BackgroundJob.Enqueue(() => _mailHelper.SendEmail(script.SendTo,
                        "Script Execution", $"Script with id {script.Id} has been failed to execute. <br/>" +
                        $"Pleas check log for details"
                    ));
                }
                throw;
            }
        }
    }
}
