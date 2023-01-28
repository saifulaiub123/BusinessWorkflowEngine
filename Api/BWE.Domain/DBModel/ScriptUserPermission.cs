using BWE.Domain.Model;

namespace BWE.Domain.DBModel
{
    public class ScriptUserPermission : BaseModel<int>
    {
        public int ScriptId { get; set; }
        public int UserId { get; set; }
        public int PermissionId { get; set; }

        public virtual Script Script { get; set; }
        public virtual ApplicationUser User { get; set; }
        public virtual Permission Permission { get; set; }

        public virtual ApplicationUser CreatedByUser { get; set; }
        public virtual ApplicationUser? UpdateByUser { get; set; }
    }
}
