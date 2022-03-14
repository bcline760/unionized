using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

using Unionized.Contract;
using Unionized.Contract.Service;
using Unionized.Contract.Repository;

namespace Unionized.Service
{
    public class NetworkLogService : UnionizedService<NetworkLog>, INetworkLogService
    {
        public NetworkLogService(INetworkLogRepository repository) : base(repository)
        {
            Repository = repository;
        }

        public async Task<List<NetworkLog>> GetLogsByDate(DateTime? after, DateTime? before)
        {
            var netRepo = (INetworkLogRepository)Repository;

            return await netRepo.GetByDateRangeAsync(after, before);
        }

        public async Task<List<NetworkLog>> GetLogsByPort(int? sourcePort, int? destinationPort)
        {
            var netRepo = (INetworkLogRepository)Repository;

            List<NetworkLog> logs = new List<NetworkLog>();

            if (sourcePort.HasValue)
                logs.AddRange(await netRepo.GetBySourcePortAsync(sourcePort.Value));
            if (destinationPort.HasValue)
            {
                logs.AddRange(await netRepo.GetByDestinationPortAsync(destinationPort.Value));
            }

            return logs;
        }

        public async Task<List<NetworkLog>> GetLogsByAddress(string srcAddr, string destAddr)
        {
            var netRepo = (INetworkLogRepository)Repository;

            List<NetworkLog> logs = new List<NetworkLog>();

            if (!string.IsNullOrEmpty(srcAddr))
            {
                logs.AddRange(await netRepo.GetBySourceAddressAsync(srcAddr));
            }
            if (!string.IsNullOrEmpty(destAddr))
            {
                logs.AddRange(await netRepo.GetByDestinationAddressAsync(destAddr));
            }

            return logs;
        }

        public async Task SaveLog(string logText)
        {
            int identifierPos = logText.IndexOf("MainGateway");

            string logDateStr = logText.Substring(0, identifierPos);
            logText = logText.Replace(logDateStr, string.Empty);
            logText = logText.Replace("MainGateway kernel:", string.Empty);

            int openBracketPos = logText.IndexOf('[');
            int closeBracketPos = logText.LastIndexOf(']');
            string rule = logText.Substring(openBracketPos + 1, (closeBracketPos - openBracketPos) - 1);
            logText = logText.Remove(openBracketPos, (closeBracketPos - openBracketPos) + 1);

            Dictionary<string, string> dict = new Dictionary<string, string>();
            string[] samples = logText.Split(' ');
            foreach (var str in samples)
            {
                if (str.Contains("="))
                {
                    string[] moreSamples = str.Split('=');
                    dict.Add(moreSamples[0], moreSamples[1]);
                }
            }

            var netLog = new NetworkLog
            {
                DestinationAddress = dict["DST"],
                InterfaceIn = dict["IN"],
                InterfaceOut = dict["OUT"],
                MacAddress = dict["MAC"],
                TimeToLive = int.Parse(dict["TTL"]),
                PacketLength = int.Parse(dict["LEN"]),
                Protocol = dict["PROTO"],
                SourceAddress = dict["SRC"],
                Rule = rule,
                LogDate = DateTime.Parse(logDateStr)
            };

            if (dict.ContainsKey("SPT"))
                netLog.SourcePort = int.Parse(dict["SPT"]);
            if (dict.ContainsKey("DPT"))
                netLog.DestinationPort = int.Parse(dict["DPT"]);
            if (dict.ContainsKey("ICMP"))
                netLog.IcmpSequence = int.Parse(dict["ICMP"]);

            await Repository.SaveAsync(netLog);
        }
    }
}
