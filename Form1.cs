using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PersonalClock
{
    public partial class frmPersonalClock : Form
    {
        public frmPersonalClock()
        {
            InitializeComponent();
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
            notifyIcon1.Visible = false;
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                minimizar();
            }
        }
        private void minimizar()
        {
            this.WindowState = FormWindowState.Minimized;
            this.Visible = false;
            notifyIcon1.Visible = true;
        }
        private void maximizar()
        {
            this.Visible = true;
            notifyIcon1.Visible = false;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (numMinutes.Value == 0) return;
            temporizador.Start();
            numMinutes.Enabled = false;
            btnStart.Enabled = false;
            btnStart.Text = "Waiting...";
            minimizar();
        }

        private void temporizador_Tick(object sender, EventArgs e)
        {
            if (numMinutes.Value == 0)
            {
                btnStart.Enabled = true;
                btnStart.Text = "Start countdown!";
                temporizador.Stop();
                maximizar();
                this.Show();
                this.Activate();
                numMinutes.Enabled = true;
                MessageBox.Show("Countdown has finished!", "Time out", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            numMinutes.Value = numMinutes.Value - 1;
            notifyIcon1.Text = numMinutes.Value + " minutes remaining";
        }
    }
}
