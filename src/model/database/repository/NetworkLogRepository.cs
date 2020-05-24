using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

using Microsoft.EntityFrameworkCore;
using AutoMapper;

using Unionized.Contract;
using Unionized.Contract.Repository;
using Unionized.Model.Database.Context;

namespace Unionized.Model.Database.Repository
{
    internal sealed class NetworkLogRepository : UnionizedRepository<NetworkLog, NetworkLogModel>, INetworkLogRepository
    {
        public NetworkLogRepository(IUnionizedContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public async Task<List<NetworkLog>> GetBySourceAddressAsync(string srcAddr)
        {
            var destinations = await (
                from m in Set
                where m.DestinationAddress == srcAddr
                select Mapper.Map<NetworkLog>(m)
                ).ToListAsync();

            return destinations;
        }

        public async Task<List<NetworkLog>> GetByDestinationAddressAsync(string destAddr)
        {
            var destinations = await (
                from m in Set
                where m.DestinationAddress == destAddr
                select Mapper.Map<NetworkLog>(m)
                ).ToListAsync();

            return destinations;
        }

        public async Task<List<NetworkLog>> GetByDestinationPortAsync(int port)
        {
            var destinations = await (
                from m in Set
                where m.DestinationPort == port
                select Mapper.Map<NetworkLog>(m)
                ).ToListAsync();

            return destinations;
        }

        public async Task<List<NetworkLog>> GetBySourcePortAsync(int port)
        {
            var destinations = await (
                from m in Set
                where m.SourcePort == port
                select Mapper.Map<NetworkLog>(m)
                ).ToListAsync();

            return destinations;
        }

        public async Task<List<NetworkLog>> GetByDateRangeAsync(DateTime? after, DateTime? before)
        {
            if (!after.HasValue && !before.HasValue)
                throw new ArgumentException("Must provide both a before and after");

            List<NetworkLog> logs = null;

            if (after.HasValue && !before.HasValue)
            {
                logs = await (
                    from m in Set
                    where m.LogDate >= after.Value
                    select Mapper.Map<NetworkLog>(m)
                    ).ToListAsync();
            }
            else if (!after.HasValue && before.HasValue)
            {
                logs = await (
                    from m in Set
                    where m.LogDate <= after.Value
                    select Mapper.Map<NetworkLog>(m)
                    ).ToListAsync();
            }
            else if (after.HasValue && before.HasValue)
            {
                logs = await (
                    from m in Set
                    where m.LogDate >= after.Value && m.LogDate <= before.Value
                    select Mapper.Map<NetworkLog>(m)
                    ).ToListAsync();
            }

            return logs;
        }

        public override Task<int> UpdateAsync(NetworkLog entity)
        {
            throw new NotImplementedException();
        }
    }
}
