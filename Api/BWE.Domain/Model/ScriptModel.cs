
using BWE.Domain.DBModel;

namespace BWE.Domain.Model
{
    public class ScriptModel
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public int DestinationServerId { get; set; }
        public string Content { get; set; }
        public string? SendTo { get; set; }
        public int CreatedBy { get; set; }
        public List<ScriptUserPermissionModel>? ScriptUserPermissions { get; set; }

    }
}
