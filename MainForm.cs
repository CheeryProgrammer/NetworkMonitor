using SNMP;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NetworkMonitor
{
	public partial class MainForm : Form
	{
		private byte[] _startIP;
		private byte[] _endIP;

		public MainForm()
		{
			InitializeComponent();
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			//Demo.Run();
		}

		private void tbStartIP_Validating(object sender, CancelEventArgs e)
		{
			if (TryParseIP(tbStartIP.Text, out byte[] ip))
			{
				_startIP = ip;
			}
			else
			{
				epStartIP.SetError(tbStartIP, "Invalid ip address");
				e.Cancel = true;
			}
		}

		private void tbEndIP_Validating(object sender, CancelEventArgs e)
		{
			if (TryParseIP(tbEndIP.Text, out byte[] ip))
			{
				_endIP = ip;
			}
			else
			{
				epEndIP.SetError(tbEndIP, "Invalid ip address");
				e.Cancel = true;
			}
		}

		private bool TryParseIP(string text, out byte[] octets)
		{
			octets = new byte[4];
			string octet1Str, octet2Str, octet3Str, octet4Str;
			octet1Str = text.Substring(0, 3);
			octet2Str = text.Substring(4, 3);
			octet3Str = text.Substring(8, 3);
			octet4Str = text.Substring(12, 3);
			return byte.TryParse(octet1Str, out octets[0])
				&& byte.TryParse(octet2Str, out octets[1])
				&& byte.TryParse(octet3Str, out octets[2])
				&& byte.TryParse(octet4Str, out octets[3]);
		}

		private void tbEndIP_Validated(object sender, EventArgs e)
		{
			epStartIP.Clear();
		}

		private void tbStartIP_Validated(object sender, EventArgs e)
		{
			epEndIP.Clear();
		}

		private async void btnPingScan_Click(object sender, EventArgs e)
		{
			byte lastEnd = _endIP[3];

			var found = new List<byte[]>();

			List<Task<PingReply>> tasks = new List<Task<PingReply>>();

			for (int i = _startIP[3]; i <= lastEnd; i++)
			{
				byte[] ip = new byte[4];
				Array.Copy(_startIP, ip, 3);
				ip[3] = (byte)i;

				btnPingScan.Text = i.ToString();
				tasks.Add(new Ping().SendPingAsync(new IPAddress(ip)));
			}
			var result = (await Task.WhenAll(tasks))
				.Where(reply => reply.Status == IPStatus.Success)
				.Select(repl => repl.Address);

			tbResults.AppendText(string.Join(Environment.NewLine, result));
		}

		/*private void Ping_PingCompleted(object sender, PingCompletedEventArgs e)
		{
			if (e.Reply.Status == IPStatus.Success)
			{
				var addr = e.Reply.Address;
				tbResults.Invoke((Action)(() =>
				{
					tbResults.AppendText(string.Join(".", addr) + Environment.NewLine);
				}
				));
			}
		}*/
	}
}
