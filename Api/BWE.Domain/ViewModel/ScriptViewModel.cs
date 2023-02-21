using BWE.Domain.Model;
namespace BWE.Domain.ViewModel
{
    public class ScriptViewModel : ScriptModel
    {
        public string DestinationServerName { get; set; }
        public string UserName { get; set; }
        public string? SendTo { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? LastUpdated { get; set; }
        public ServerViewModel Server { get; set; }
    }
}
