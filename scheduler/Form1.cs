using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace scheduler
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void select_Click(object sender, EventArgs e)
        {
            string type;
            type = comboBox.Text;
            switch (type)
            {
                case "FCFS":
                    if (!panel.Controls.Contains(FCFS.Instance))
                    {
                        panel.Controls.Add(FCFS.Instance);
                        FCFS.Instance.Dock = DockStyle.Fill;
                        FCFS.Instance.BringToFront();
                    }
                    else
                    {
                        FCFS.Instance.BringToFront();
                    }
                    break;
                case "SJF":
                    if (!panel.Controls.Contains(SJF.Instance))
                    {
                        panel.Controls.Add(SJF.Instance);
                        SJF.Instance.Dock = DockStyle.Fill;
                        SJF.Instance.BringToFront();
                    }
                    else
                    {
                        SJF.Instance.BringToFront();
                    }
                    break;
                case "PRIORITY":
                    if (!panel.Controls.Contains(priority.Instance))
                    {
                        panel.Controls.Add(priority.Instance);
                        priority.Instance.Dock = DockStyle.Fill;
                        priority.Instance.BringToFront();
                    }
                    else
                    {
                        priority.Instance.BringToFront();
                    }
                    break;
                case "ROUND ROBIN":
                    if (!panel.Controls.Contains(RR.Instance))
                    {
                        panel.Controls.Add(RR.Instance);
                        RR.Instance.Dock = DockStyle.Fill;
                        RR.Instance.BringToFront();
                    }
                    else
                    {
                        RR.Instance.BringToFront();
                    }
                    break;
            }
        }
    }
}
