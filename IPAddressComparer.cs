using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace NetworkMonitor
{
	public class IPAddressComparer : IComparer<IPAddress>
	{
		public int Compare(IPAddress left, IPAddress right)
		{
			var l = left.GetAddressBytes();
			var r = right.GetAddressBytes();
			var subs = l.Zip(r, (lb, rb) => lb - rb);
			return subs.Aggregate(0, (accumulate, el) =>
			{
				if (accumulate < 0)
					return -1;
				if (accumulate > 0)
					return 1;
				return el;
			});
		}
	}
}
