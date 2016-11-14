using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ServiceModel;
using EF_WCF;


namespace HostWCF
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }


        ServiceHost host;
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                host = new ServiceHost(typeof(ServiciuLectori));
                host.Open();
                label1.Text = "Host is online";
                label1.ForeColor = Color.Green;
                label1.Font = new Font("Serif", 15, FontStyle.Bold);
            }
            catch(Exception)
            {
                host.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            host.Close();
            label1.Text = "Host is offline";
            label1.ForeColor = Color.Red;
            label1.Font = new Font("Serif", 15, FontStyle.Bold);
        }

    }
}
