
namespace BWE.Domain.Model
{
    public class ScriptModel
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public int DestinationServerId { get; set; }
        public string Content { get; set; }
    }
}
