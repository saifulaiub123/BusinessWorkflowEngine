using BWE.Application.IHelper;
using BWE.Application.IService;
using BWE.Domain.ViewModel;
using System.Management.Automation;
using System.Management.Automation.Runspaces;
using System.Security;
using System.Text;
using BWE.Domain.Model;
using BWE.Application.Enum;
using Microsoft.AspNetCore.Http;

namespace BWE.Application.Helper
{
    public class PowerShellHelper : IPowerShellHelper
    {
        private readonly IScriptHistoryService _scriptHistoryService;

        public PowerShellHelper(IScriptHistoryService scriptHistoryService)
        {
            _scriptHistoryService = scriptHistoryService;
        }

        public async Task RunPowerShellScript(ScriptViewModel script,int userId)
        {
            var scriptHistory = new ScriptHistoryModel();
            var securestring = new SecureString();
            foreach (Char c in script.Server.Password)
            {
                securestring.AppendChar(c);
            }
            PSCredential creds = new PSCredential(script.Server.UserName, securestring);
            WSManConnectionInfo connectionInfo = new WSManConnectionInfo();

            connectionInfo.ComputerName = script.Server.MachineName;
            connectionInfo.Credential = creds;
            Runspace runspace = RunspaceFactory.CreateRunspace(connectionInfo);
            //String psProg = File.ReadAllText(@"path_for_ps.ps1");
            try
            {
                runspace.Open();
                using (PowerShell ps = PowerShell.Create())
                {
                    ps.Runspace = runspace;
                    ps.AddScript(script.Content);
                    //ps.AddArgument(@"Argument1");
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
                }
                runspace.Close();
            }
            catch(System.Exception ex)
            {
                if(scriptHistory.Id != 0)
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
            }
        }
    }
}
