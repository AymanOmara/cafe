using cafe.Common;
using cafe.Domain.Event.Entity;
using cafe.Domain.Event.Repository;
using Microsoft.EntityFrameworkCore;

namespace cafe.infrastructure.Features.Event
{
    public class EventRepository : IEventRepository
    {
        private readonly CafeDbContext _context;
        private readonly LanguageService _localization;
        public EventRepository(CafeDbContext context, LanguageService localization)
        {
            _context = context;
            _localization = localization;
        }

        public async Task<EventEntity> CheckOut(EventEntity eventEntity)
        {
            eventEntity.CheckOut = true;
            _context.Entry(eventEntity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return eventEntity;
        }

        public async Task<EventEntity> Create(EventEntity entity)
        {
            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task Delete(EventEntity entity)
        {
            entity.Deleted = true;
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task<ICollection<EventEntity>> GetAllRecords()
        {
            return await _context.Events.ToListAsync();
        }

        public async Task<EventEntity?> GetEventById(int id)
        {
            var result = await _context.Events.AsNoTracking().FirstOrDefaultAsync(ev=> ev.Id == id);
            return result;
        }

        public async Task<EventEntity> Update(EventEntity entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}