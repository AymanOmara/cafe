using cafe.Domain.Event.Entity;
using cafe.Domain.Event.Repository;

namespace cafe.infrastructure.Features.Event
{
    public class EventRepository : IEventRepository
    {
        public Task<EventEntity> Create(EventEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task Delete(EventEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<EventEntity>> GetAllRecords()
        {
            throw new NotImplementedException();
        }

        public Task<EventEntity> Update(EventEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}

