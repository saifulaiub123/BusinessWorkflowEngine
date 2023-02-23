
namespace BWE.Domain.ViewModel
{
    public class ScriptHistoryViewModel
    {
        public int Id { get; set; }
        public int ScriptId { get; set; }
        public string ScriptName { get; set; }

        public int Status { get; set; }
        public string Output { get; set; }
        public int CreatedBy { get; set; }
        public DateTime DateCreated { get; set; }
        public string CreatedByName { get; set; }
        public string ScriptOwnerName { get; set; }
    }
}
