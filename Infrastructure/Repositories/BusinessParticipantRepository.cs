using Core.Entities;
using Core.Repositories;
using Infrastructure.Context;

namespace Infrastructure.Repositories {
    public class BusinessParticipantRepository : RepositoryBase<BusinessParticipant>, IBusinessParticipantRepository {
        public BusinessParticipantRepository(ApiContext dbContext) : base(dbContext) { }
    }
}
