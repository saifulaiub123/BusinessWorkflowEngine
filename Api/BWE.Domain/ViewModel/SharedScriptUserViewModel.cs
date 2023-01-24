using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BWE.Domain.ViewModel
{
    public class SharedScriptUserViewModel
    {
        public int ScriptId { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int PermissionId { get; set; }
    }
}
