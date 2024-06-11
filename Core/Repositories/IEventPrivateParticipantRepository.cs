using Core.Entities;

namespace Core.Repositories {
    public interface IEventPrivateParticipantRepository : IRepository<EventPrivateParticipant> {
        Task<List<EventPrivateParticipant>> GetByEvent(int eventId);
        Task<bool> Exists(int eventId, int privateParticipantId);
    }
}
