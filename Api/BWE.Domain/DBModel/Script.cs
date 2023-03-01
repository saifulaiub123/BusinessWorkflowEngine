using BWE.Domain.Model;

namespace BWE.Domain.DBModel
{
    public class Script : BaseModel<int>
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public int DestinationServerId { get; set; }
        public string Content { get; set; }
        public string? Parameter { get; set; }
        public string? SendTo { get; set; }
        public bool IsDeleted { get; set; }
        
        public virtual Server Server { get; set; }
        public virtual ICollection<ScriptUserPermission>? ScriptUserPermissions { get; set; }



        public virtual ApplicationUser CreatedByUser { get; set; }
        public virtual ApplicationUser UpdateByUser { get; set; }
    }
}
