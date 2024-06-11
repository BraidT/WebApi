using Core.Entities;
using Core.Repositories;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories {
    public class EventPrivateParticipantRepository : RepositoryBase<EventPrivateParticipant>, IEventPrivateParticipantRepository {
        public EventPrivateParticipantRepository(ApiContext dbContext) : base(dbContext) {
        }

        public async Task<List<EventPrivateParticipant>> GetByEvent(int eventId) {
            return await _dbContext.EventPrivateParticipants.Include(x => x.PrivateParticipant).Where(x => x.EventId == eventId).ToListAsync();
        }

        public async Task<bool> Exists(int eventId, int privateParticipantId) {
            return (await _dbContext.EventPrivateParticipants.FirstOrDefaultAsync(x => x.EventId == eventId && x.PrivateParticipantId == privateParticipantId) != null);
        }
    }
}
