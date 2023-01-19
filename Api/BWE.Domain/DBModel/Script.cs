using BWE.Domain.Model;

namespace BWE.Domain.DBModel
{
    public class Script : BaseModel<int>
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public int DestinationServerId { get; set; }
        public string Content { get; set; }
        
        //public virtual Server Server { get; set; }
    }
}
