using BWE.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BWE.Domain.ViewModel
{
    public class ScriptViewModel : ScriptModel
    {
        public string DestinationServerName { get; set; }
        public string UserName { get; set; }
    }
}
