using MongoDB.Driver;

using AutoMapper;
using Unionized.Contract;
using Unionized.Contract.Repository;

namespace Unionized.Model.Database.Repository
{
    public class MonitoredServersRepository : UnionizedRepository<MonitoredServer, MonitoredServersModel>, IMonitorServersRepository
    {
        public MonitoredServersRepository(IMongoDatabase context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
