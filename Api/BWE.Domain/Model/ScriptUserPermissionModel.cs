
namespace BWE.Domain.Model
{
    public class ScriptUserPermissionModel
    {
        public int? Id { get; set; }
        public int ScriptId { get; set; }
        public int UserId { get; set; }
        public int PermissionId { get; set; }
    }
}
