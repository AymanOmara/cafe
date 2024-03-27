using cafe.Domain.Common;
using cafe.Domain.Event.Entity;

namespace cafe.Domain.Event.Repository
{
    public interface IEventRepository : IUnitOfWorkRepository<EventEntity>
    {

    }

}

