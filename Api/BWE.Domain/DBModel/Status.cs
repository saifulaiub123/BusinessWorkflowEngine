
using BWE.Domain.Model;

namespace BWE.Domain.DBModel
{
    public class Status: BaseModel<int>
    {
        public string Name { get; set; }

        public virtual ApplicationUser UserStatusApplicationUser { get; set; }
    }
}
