using BWE.Domain.Model;

namespace BWE.Domain.DBModel
{
    public class ScriptHistory : BaseModel<int>
    {
        public int ScriptId { get; set; }
        public int Status { get; set; }
        public string? Output { get; set; }
        public bool IsDeleted { get; set; }

        public virtual Script Script { get; set; }
        public virtual ApplicationUser CreatedByUser { get; set; }
        public virtual ApplicationUser UpdateByUser { get; set; }
    }
}
