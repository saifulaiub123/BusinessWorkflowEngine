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
        public bool IsDeleted { get; set; }


        public virtual ICollection<Script> Scripts { get; set; }

        public virtual ApplicationUser CreatedByUser { get; set; }
        public virtual ApplicationUser UpdateByUser { get; set; }
    }
}
