using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Unionized.Contract;
using Unionized.Contract.Repository;
using Unionized.Model.Database.Context;

namespace Unionized.Model.Database.Repository
{
    public sealed class NetworkLogRepository : UnionizedRepository<NetworkLog, NetworkLogModel>, INetworkLogRepository
    {
        public NetworkLogRepository(IUnionizedContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
