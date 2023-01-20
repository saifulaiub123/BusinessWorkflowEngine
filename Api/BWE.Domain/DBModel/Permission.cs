using BWE.Domain.Model;

namespace BWE.Domain.DBModel
{
    public class Permission : BaseModel<int>
    {
        public string Name { get; set; }

        public virtual ApplicationUser CreatedByUser { get; set; }
        public virtual ApplicationUser UpdateByUser { get; set; }
        public virtual ICollection<ScriptUserPermission> ScriptUserPermissions { get; set; }

    }
}
