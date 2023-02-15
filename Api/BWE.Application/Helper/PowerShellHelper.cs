using BWE.Application.IHelper;
using BWE.Domain.ViewModel;
using System.Management.Automation;
using System.Management.Automation.Runspaces;
using System.Security;
using System.Text;

namespace BWE.Application.Helper
{
    public class PowerShellHelper : IPowerShellHelper
    {
        public async Task RunPowerShellScript(ScriptViewModel script)
        {
            var securestring = new SecureString();
            foreach (Char c in script.Server.Password)
            {
                securestring.AppendChar(c);
            }
            PSCredential creds = new PSCredential(script.Server.UserName, securestring);
            WSManConnectionInfo connectionInfo = new WSManConnectionInfo();

            connectionInfo.ComputerName = script.Server.MachineName;
            connectionInfo.Credential = creds;
            //String psProg = File.ReadAllText(@"path_for_ps.ps1");
            Runspace runspace = RunspaceFactory.CreateRunspace(connectionInfo);
            runspace.Open();
            using (PowerShell ps = PowerShell.Create())
            {
                ps.Runspace = runspace;
                ps.AddScript(script.Content);
                //ps.AddArgument(@"Argument1");
                StringBuilder sb = new StringBuilder();
                
                var results = ps.Invoke();
                foreach (var x in results)
                {
                    sb.AppendLine(x.ToString());
                }
            }
            runspace.Close();
        }
    }
}
