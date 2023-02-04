using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BWE.Domain.Model
{
    public class UpdateScriptModel
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public int DestinationServerId { get; set; }
        public string Content { get; set; }
        public int CreatedBy { get; set; }

        public List<ScriptUserPermissionModel> AddOrUpdatedScriptUserPermissions { get; set; }
        public List<ScriptUserPermissionModel> DeletedScriptUserPermissions { get; set; }
    }
}
