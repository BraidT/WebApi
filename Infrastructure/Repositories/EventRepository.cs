using Core.Entities;
using Core.Repositories;
using Infrastructure.Context;

namespace Infrastructure.Repositories {
    public class EventRepository: RepositoryBase<Event>, IEventRepository {
        public EventRepository(ApiContext dbContext) : base(dbContext) {
        }
    }
}
