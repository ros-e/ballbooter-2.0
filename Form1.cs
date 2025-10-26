using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ballbooter_2._0
{
    public partial class Form1 : Form
    {
        private string sTargetIP;
        private string sTargetHost;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void Attack(bool toggle, bool on, bool silent = false)
        {
        }

        private void LockOnIP(bool silent = false)
        {
            try
            {
                string tIP = targetIP.Text.Trim().ToLowerInvariant();

                if (string.IsNullOrWhiteSpace(tIP))
                {
                    if (!silent)
                        MessageBox.Show("I think you forgot the IP.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                try
                {
                    string parsedIP = IPAddress.Parse(tIP).ToString();
                    sTargetIP = parsedIP;
                    sTargetHost = parsedIP;
                    textBox2.Text = sTargetIP;
                    if (sTargetHost.Contains(":"))
                        sTargetHost = $"[{sTargetHost.Trim('[', ']')}]";

                    targetIP.Text = sTargetHost;
                }
                catch (FormatException)
                {
                    if (!silent)
                        MessageBox.Show("I don't think an IP is supposed to be written like THAT.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                if (!silent)
                    MessageBox.Show($"An unexpected error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LockOnIP(false);
        }
    }
}
