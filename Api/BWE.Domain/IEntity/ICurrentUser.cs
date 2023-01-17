using BWE.Domain.DBModel;

namespace BWE.Domain.IEntity
{
    public interface ICurrentUser
    {
        public ApplicationUser User { get; }
    }
}
