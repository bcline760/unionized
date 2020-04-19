using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

using AutoMapper;
using Unionized.Contract;
using Unionized.Contract.Repository;
using Unionized.Model.Database.Context;

namespace Unionized.Model.Database.Repository
{
    public class MonitoredServersRepository : UnionizedRepository<MonitoredServer, MonitoredServersModel>, IMonitorServersRepository
    {
        public MonitoredServersRepository(IUnionizedContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
