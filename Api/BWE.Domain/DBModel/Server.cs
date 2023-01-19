using BWE.Domain.Model;

namespace BWE.Domain.DBModel
{
    public class Server : BaseModel<int>
    {
        public string Name { get; set; }
        public string? IpAddress { get; set; }
        public string? MachineName { get; set; }
        public string? UserName { get; set; }
        public string? Password { get; set; }
    }
}
