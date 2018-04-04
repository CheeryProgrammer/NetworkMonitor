namespace NetworkMonitor
{
	partial class MainForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.tbResults = new System.Windows.Forms.TextBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.tbEndIP = new System.Windows.Forms.MaskedTextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.tbStartIP = new System.Windows.Forms.MaskedTextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.btnPingScan = new System.Windows.Forms.Button();
			this.epStartIP = new System.Windows.Forms.ErrorProvider(this.components);
			this.epEndIP = new System.Windows.Forms.ErrorProvider(this.components);
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.epStartIP)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.epEndIP)).BeginInit();
			this.SuspendLayout();
			// 
			// tbResults
			// 
			this.tbResults.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.tbResults.Location = new System.Drawing.Point(3, 50);
			this.tbResults.Multiline = true;
			this.tbResults.Name = "tbResults";
			this.tbResults.Size = new System.Drawing.Size(399, 236);
			this.tbResults.TabIndex = 0;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.tbEndIP);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.tbStartIP);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.btnPingScan);
			this.groupBox1.Controls.Add(this.tbResults);
			this.groupBox1.Location = new System.Drawing.Point(12, 12);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(405, 289);
			this.groupBox1.TabIndex = 1;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Ping scan";
			// 
			// tbEndIP
			// 
			this.tbEndIP.Location = new System.Drawing.Point(214, 23);
			this.tbEndIP.Mask = "000.000.000.000";
			this.tbEndIP.Name = "tbEndIP";
			this.tbEndIP.PromptChar = '0';
			this.tbEndIP.Size = new System.Drawing.Size(88, 20);
			this.tbEndIP.TabIndex = 4;
			this.tbEndIP.Text = "192168   255";
			this.tbEndIP.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
			this.tbEndIP.Validating += new System.ComponentModel.CancelEventHandler(this.tbEndIP_Validating);
			this.tbEndIP.Validated += new System.EventHandler(this.tbEndIP_Validated);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(166, 26);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(42, 13);
			this.label2.TabIndex = 5;
			this.label2.Text = "End IP:";
			// 
			// tbStartIP
			// 
			this.tbStartIP.Location = new System.Drawing.Point(57, 23);
			this.tbStartIP.Mask = "000.000.000.000";
			this.tbStartIP.Name = "tbStartIP";
			this.tbStartIP.PromptChar = '0';
			this.tbStartIP.Size = new System.Drawing.Size(88, 20);
			this.tbStartIP.TabIndex = 2;
			this.tbStartIP.Text = "192168";
			this.tbStartIP.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
			this.tbStartIP.Validating += new System.ComponentModel.CancelEventHandler(this.tbStartIP_Validating);
			this.tbStartIP.Validated += new System.EventHandler(this.tbStartIP_Validated);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(6, 26);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(45, 13);
			this.label1.TabIndex = 3;
			this.label1.Text = "Start IP:";
			// 
			// btnPingScan
			// 
			this.btnPingScan.Location = new System.Drawing.Point(324, 21);
			this.btnPingScan.Name = "btnPingScan";
			this.btnPingScan.Size = new System.Drawing.Size(75, 23);
			this.btnPingScan.TabIndex = 2;
			this.btnPingScan.Text = "Scan";
			this.btnPingScan.UseVisualStyleBackColor = true;
			this.btnPingScan.Click += new System.EventHandler(this.btnPingScan_Click);
			// 
			// epStartIP
			// 
			this.epStartIP.ContainerControl = this;
			// 
			// epEndIP
			// 
			this.epEndIP.ContainerControl = this;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.groupBox1);
			this.Name = "MainForm";
			this.Text = "Network monitor";
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.epStartIP)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.epEndIP)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TextBox tbResults;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.MaskedTextBox tbStartIP;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button btnPingScan;
		private System.Windows.Forms.MaskedTextBox tbEndIP;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ErrorProvider epStartIP;
		private System.Windows.Forms.ErrorProvider epEndIP;
	}
}

