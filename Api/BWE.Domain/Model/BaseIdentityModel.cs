using BWE.Domain.IEntity;

namespace BWE.Domain.Model
{
    public class BaseIdentityModel<TId> : IBaseEntity<TId>
    {
        public TId Id { get; set; }
    }
}
