using BWE.Domain.Model;

namespace BWE.Domain.DBModel
{
    public class Permission : BaseModel<int>
    {
        public string Name { get; set; }
    }
}
