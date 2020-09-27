using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Driver;

using AutoMapper;

using Unionized.Contract;
using Unionized.Contract.Repository;

namespace Unionized.Model.Database.Repository
{
    internal sealed class NetworkLogRepository : UnionizedRepository<NetworkLog, NetworkLogModel>, INetworkLogRepository
    {
        public NetworkLogRepository(IMongoDatabase context, IMapper mapper) : base(context, mapper)
        {
        }

        public async Task<List<NetworkLog>> GetBySourceAddressAsync(string srcAddr)
        {
            return await GetLogsAsync("src_address", srcAddr);
        }

        public async Task<List<NetworkLog>> GetByDestinationAddressAsync(string destAddr)
        {
            return await GetLogsAsync("dst_address", destAddr);
        }

        public async Task<List<NetworkLog>> GetByDestinationPortAsync(int port)
        {
            return await GetLogsAsync("dst_port", port.ToString());
        }

        public async Task<List<NetworkLog>> GetBySourcePortAsync(int port)
        {
            return await GetLogsAsync("src_port", port.ToString());
        }

        public async Task<List<NetworkLog>> GetByDateRangeAsync(DateTime? after, DateTime? before)
        {
            FilterDefinition<NetworkLogModel> filter = null;

            if (after.HasValue && before.HasValue)
            {
                var gtFilter = Builders<NetworkLogModel>.Filter.Gte("log_date", after.Value);
                var ltFilter = Builders<NetworkLogModel>.Filter.Lt("log_date", before.Value);

                filter = Builders<NetworkLogModel>.Filter.And(gtFilter, ltFilter);
            }
            else if (!after.HasValue && before.HasValue)
            {
                filter = Builders<NetworkLogModel>.Filter.Lt("log_date", before.Value);
            }
            else if (after.HasValue && !before.HasValue)
            {
                filter = Builders<NetworkLogModel>.Filter.Gte("log_date", after.Value);
            }
            else
                throw new ArgumentException("Must supply an after or before argument");

            return await GetLogsAsync(filter);
        }

        private async Task<List<NetworkLog>> GetLogsAsync(string field, string fieldValue)
        {
            var filter = Builders<NetworkLogModel>.Filter.Eq(field, fieldValue);
            return await GetLogsAsync(filter);
        }

        private async Task<List<NetworkLog>> GetLogsAsync(FilterDefinition<NetworkLogModel> filter)
        {
            var result = await Collection.FindAsync(filter);

            List<NetworkLog> logs = new List<NetworkLog>();
            if (result.Any())
            {
                var docs = await result.ToListAsync();
                logs.AddRange(Mapper.Map<List<NetworkLog>>(docs));
            }

            return logs;
        }
    }
}
