using Core.Entities;

namespace Core.Repositories {
    public interface IEventBusinessParticipantRepository : IRepository<EventBusinessParticipant> {
        Task<List<EventBusinessParticipant>> GetByEvent(int eventId);
        Task<bool> Exists(int eventId, int privateParticipantId);
    }
}
