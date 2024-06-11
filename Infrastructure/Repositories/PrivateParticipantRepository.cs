using Core.Entities;
using Core.Repositories;
using Infrastructure.Context;

namespace Infrastructure.Repositories {
    public class PrivateParticipantRepository : RepositoryBase<PrivateParticipant>, IPrivateParticipantRepository {
        public PrivateParticipantRepository(ApiContext dbContext) : base(dbContext) {
        }
    }
}
