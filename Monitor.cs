using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Threading.Tasks;

namespace NetworkMonitor
{
	class Monitor
	{
		private static readonly IPAddressComparer _IPComparer = new IPAddressComparer();

		internal Task<IEnumerable<string>> ScanByPing(IPAddress start, IPAddress end, int batchSize = 5000)
		{
			return Task.Run(() =>
			{
				var startIp = start.GetAddressBytes().Select(b => Convert.ToInt32(b)).ToArray();
				var endIp = end.GetAddressBytes().Select(b => Convert.ToInt32(b)).ToArray();

				if (_IPComparer.Compare(start, end) >= 0)
					return null;

				var found = new List<byte[]>();

				var pings = Enumerable.Range(0, batchSize).Select(num => new Ping()).ToList();
				List<Task<PingReply>> tasks = new List<Task<PingReply>>();
				IEnumerable<string> results = new List<string>();

				var count = 0;

				var end0 = endIp[0];
				var end1 = endIp[1];
				var end2 = endIp[2];
				var end3 = endIp[3];
				
				for (int octet0 = startIp[0]; octet0 <= end0; octet0++)
				{
					for (int octet1 = startIp[1]; octet1 <= end1; octet1++)
					{
						for (int octet2 = startIp[2]; octet2 <= end2; octet2++)
						{
							for (int octet3 = startIp[3]; octet3 <= end3; octet3++)
							{
								if (count < batchSize)
								{
									tasks.Add(pings[count].SendPingAsync(
										new IPAddress(new[] { octet0, octet1, octet2, octet3 }
										.Select(Convert.ToByte)
										.ToArray()))
										);
									count++;
								}
								else
								{
									var result = Task.WhenAll(tasks).Result
										.Where(reply => reply.Status == IPStatus.Success)
										.Select(repl => repl.Address.ToString());
									results = results.Concat(result);
									tasks = new List<Task<PingReply>>();
									count = 0;
								}
							}
							end3 = 255;
						}
						end2 = 255;
					}
					end1 = 255;
				}
				var lastResult = Task.WhenAll(tasks).Result
								.Where(reply => reply.Status == IPStatus.Success)
								.Select(repl => repl.Address.ToString());
				results = results.Concat(lastResult);
				foreach (var ping in pings)
					ping.Dispose();

				return AppendHostInfo(results);
			});
		}

		private IEnumerable<string> AppendHostInfo(IEnumerable<string> addrs)
		{
			foreach (var addr in addrs)
			{
				IPHostEntry hostEntry = null;
				string aliases = null;
				try
				{
					hostEntry = Dns.GetHostEntry(addr);
					aliases = hostEntry?.Aliases == null ? string.Empty : string.Join(", ", hostEntry?.Aliases);
				}
				catch { }
				yield return $"[{addr}] {hostEntry?.HostName} Aliases: {aliases}";
			}
		}
	}
}
