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
		private readonly Monitor _monitor = new Monitor();

		private IPAddress _startIP;
		private IPAddress _endIP;

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
			if (IPAddress.TryParse(tbStartIP.Text, out IPAddress ip))
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
			if (IPAddress.TryParse(tbEndIP.Text, out IPAddress ip))
			{
				_endIP = ip;
			}
			else
			{
				epEndIP.SetError(tbEndIP, "Invalid ip address");
				e.Cancel = true;
			}
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
			tbResults.Text = string.Empty;
			var ips = await _monitor.ScanByPing(_startIP, _endIP);
			tbResults.AppendText(string.Join(string.Empty, ips.Select(ip => ip + Environment.NewLine)));
		}		
	}
}
