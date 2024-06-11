using Core.Entities;
using Core.Repositories;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories {
    public class EventBusinessParticipantRepository : RepositoryBase<EventBusinessParticipant>, IEventBusinessParticipantRepository {
        public EventBusinessParticipantRepository(ApiContext dbContext) : base(dbContext) {
        }

        public async Task<List<EventBusinessParticipant>> GetByEvent(int eventId) {
           return await _dbContext.EventBusinessParticipants.Include(x => x.BusinessParticipant).Where(x => x.EventId == eventId).ToListAsync();
        }

        public async Task<bool> Exists(int eventId, int businessParticipantId) {
            return (await _dbContext.EventBusinessParticipants.FirstOrDefaultAsync(x => x.EventId == eventId && x.BusinessParticipantId == businessParticipantId) != null);
        }
    }
}
