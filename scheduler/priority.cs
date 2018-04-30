using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace scheduler
{
    public partial class priority : UserControl
    {
        private static priority _instance;
        public static priority Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new priority();
                }
                return _instance;
            }

        }
        Graphics dArea;
        public priority()
        {
            InitializeComponent();
            dArea = drawingArea.CreateGraphics();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string x = comboBox.Text;
            dArea.Clear(Color.WhiteSmoke);
            switch (x)
            {
                case ("NONpreemptive"):
                    NONpreemptive();
                    break;
                case ("preemptive"):
                    preemptive();
                    break;
            }

        }
        private void NONpreemptive()
        {
            int n;
            n = Convert.ToUInt16(textBox1.Text);
            List<double> arrival = new List<double>();
            List<double> prio = new List<double>();
            List<double> len = new List<double>();
            string s2, s3, temp,s4;
            s2 = textBox2.Text;
            s3 = textBox3.Text;
            s4 = textBox4.Text;
            //////////////////////////////////////
            //////string processing///////////////
            //storing arrival in list/////////////
            int indf, indl, l;
            l = s2.Length;
            indf = 0;
            for (int i = 0; i < l; i++)
            {
                if (s2[i] == ' ')
                {
                    indl = i;
                    temp = s2.Substring(indf, indl - indf);
                    indf = indl + 1;
                    arrival.Add(Convert.ToDouble(temp));

                }
                else if (s2[i] == ';')
                {
                    indl = i;
                    temp = s2.Substring(indf, indl - indf);
                    arrival.Add(Convert.ToDouble(temp));

                }
            }

            //storing burst time in list
            l = s3.Length;
            indf = 0;
            for (int i = 0; i < l; i++)
            {
                if (s3[i] == ' ')
                {
                    indl = i;
                    temp = s3.Substring(indf, indl - indf);
                    indf = indl + 1;
                    len.Add(Convert.ToDouble(temp));

                }
                else if (s3[i] == ';')
                {
                    indl = i;
                    temp = s3.Substring(indf, indl - indf);
                    len.Add(Convert.ToDouble(temp));

                }
            }
            //storing priority in list
            l = s4.Length;
            indf = 0;
            for (int i = 0; i < l; i++)
            {
                if (s4[i] == ' ')
                {
                    indl = i;
                    temp = s4.Substring(indf, indl - indf);
                    indf = indl + 1;
                    prio.Add(Convert.ToDouble(temp));

                }
                else if (s4[i] == ';')
                {
                    indl = i;
                    temp = s4.Substring(indf, indl - indf);
                    prio.Add(Convert.ToDouble(temp));

                }
            }
            ///////////////////////////
            ////////priority///////////
            ///////////////////////////
            bool[] finished;
            finished = new bool[n];
            bool[] arrived;
            arrived = new bool[n];
            string lab = "";
            int arrive = 0, highestpriorityindex=0, count = 0;
            double highestpriority=double.MaxValue, currenttime = 0, totallen = 0, x = 0,wtime = 0;

            Color[] colorSet = { Color.Black, Color.Red, Color.Brown,
                Color.Aqua,Color.BlueViolet,Color.CadetBlue,Color.DarkGoldenrod,
                Color.DeepPink,Color.Goldenrod,Color.Gray};

            for (int i = 0; i < n; i++)
            {
                totallen += len[i];
                finished[i] = false;
                arrived[i] = false;
            }

            while (currenttime < totallen) {
                if (arrive < n)
                {
                    if (arrival[arrive] > currenttime) currenttime = arrival[arrive];
                }

                if (arrive != n)
                {
                    while (arrival[arrive] <= currenttime)
                    {
                        arrived[arrive] = true;
                        arrive++;
                        if (arrive == n) break;
                    }
                }


                for (int i = 0; i < n; i++)
                {
                    if (arrived[i] && !finished[i] && (highestpriority>prio[i] ))
                    {
                        highestpriority = prio[i];
                        highestpriorityindex = i;
                    }
                }

                finished[highestpriorityindex] = true;
                

                lab += ("P #" + (highestpriorityindex + 1) + " :" + colorSet[count] + ", ");
                wtime += currenttime - arrival[highestpriorityindex];
                currenttime += len[highestpriorityindex];

                SolidBrush sb = new SolidBrush(colorSet[count % 10]);
                dArea.FillRectangle(sb, (float)x, 0, (float)(len[highestpriorityindex] / totallen * 595), 50);
                x += ((len[highestpriorityindex] / totallen) * 595);

                count++;
                highestpriority = double.MaxValue;
            }
            SolidBrush sb1 = new SolidBrush(Color.White);
            for (int i = 0; i <= totallen; i++)
            {
                x = i * 595 / totallen;
                dArea.FillRectangle(sb1, (float)x, 0, 1, 50);
            }

            wtime /= n;
            label5.Text = ("Average waiting time :" + wtime);
            label6.Text = lab;

        }

        private void preemptive()
        {
            int n;
            n = Convert.ToUInt16(textBox1.Text);
            List<double> arrival = new List<double>();
            List<double> prio = new List<double>();
            List<double> len = new List<double>();
            string s2, s3, temp, s4;
            s2 = textBox2.Text;
            s3 = textBox3.Text;
            s4 = textBox4.Text;
            //////////////////////////////////////
            //////string processing///////////////
            //storing arrival in list/////////////
            int indf, indl, l;
            l = s2.Length;
            indf = 0;
            for (int i = 0; i < l; i++)
            {
                if (s2[i] == ' ')
                {
                    indl = i;
                    temp = s2.Substring(indf, indl - indf);
                    indf = indl + 1;
                    arrival.Add(Convert.ToDouble(temp));

                }
                else if (s2[i] == ';')
                {
                    indl = i;
                    temp = s2.Substring(indf, indl - indf);
                    arrival.Add(Convert.ToDouble(temp));

                }
            }

            //storing burst time in list
            l = s3.Length;
            indf = 0;
            for (int i = 0; i < l; i++)
            {
                if (s3[i] == ' ')
                {
                    indl = i;
                    temp = s3.Substring(indf, indl - indf);
                    indf = indl + 1;
                    len.Add(Convert.ToDouble(temp));

                }
                else if (s3[i] == ';')
                {
                    indl = i;
                    temp = s3.Substring(indf, indl - indf);
                    len.Add(Convert.ToDouble(temp));

                }
            }
            //storing priority in list
            l = s4.Length;
            indf = 0;
            for (int i = 0; i < l; i++)
            {
                if (s4[i] == ' ')
                {
                    indl = i;
                    temp = s4.Substring(indf, indl - indf);
                    indf = indl + 1;
                    prio.Add(Convert.ToDouble(temp));

                }
                else if (s4[i] == ';')
                {
                    indl = i;
                    temp = s4.Substring(indf, indl - indf);
                    prio.Add(Convert.ToDouble(temp));

                }
            }

            ///////////////////////////
            //////priority code///////
            //////////////////////////

            bool[] finished;
            finished = new bool[n];
            bool[] arrived;
            arrived = new bool[n];
            string lab = "";
            int arrive = 0, highestpriorityindex = 0;
            double highestpriority = double.MaxValue, currenttime = 0, totallen = 0, x = 0, wtime = 0;

            Color[] colorSet = { Color.Black, Color.Red, Color.Brown,
                Color.Aqua,Color.BlueViolet,Color.CadetBlue,Color.DarkGoldenrod,
                Color.DeepPink,Color.Goldenrod,Color.Gray};

            for (int i = 0; i < n; i++)
            {
                totallen += len[i];
                finished[i] = false;
                arrived[i] = false;
            }
            int  countready = 0;
            double run = double.MaxValue;

            while (currenttime < totallen)
            {
                if (arrive != n)
                {
                    if (arrival[arrive] > currenttime) currenttime = arrival[arrive];

                    while(arrival[arrive] <= currenttime)
                    {
                        arrived[arrive] = true;
                        countready++;
                        arrive++;
                        if (arrive == n) break;
                    }

                }

                for(int i = 0; i < n; i++)
                {
                    if (arrived[i] && !finished[i] && prio[i]<highestpriority)
                    {
                        highestpriority = prio[i];
                        highestpriorityindex = i;
                    }
                }

                if (arrive < (n )) run = arrival[arrive] - currenttime;

                if (run >= len[highestpriorityindex])
                {
                    finished[highestpriorityindex] = true;
                    countready--;
                    currenttime += len[highestpriorityindex];
                    SolidBrush sb = new SolidBrush(colorSet[highestpriorityindex % 10]);
                    dArea.FillRectangle(sb, (float)x, 0,(float) (len[highestpriorityindex] * 595 / totallen), 50);
                    x += len[highestpriorityindex] * 595 / totallen;
                    wtime +=( (countready * len[highestpriorityindex]));
                    lab += ("P #" + (highestpriorityindex + 1) + " :" + colorSet[highestpriorityindex % 10] + ", ");
                    
                }
                else if (run < len[highestpriorityindex])
                { 
                    currenttime += run;
                    wtime += ((countready - 1) * run);
                    SolidBrush sb = new SolidBrush(colorSet[highestpriorityindex % 10]);
                    dArea.FillRectangle(sb, (float)x, 0, (float)(run * 595 / totallen), 50);
                    x += run *595 / totallen;

                    len[highestpriorityindex] -= run;

                    
                }

                highestpriority = double.MaxValue;
                run = double.MaxValue;
            }

            wtime /= n;
            SolidBrush sb1 = new SolidBrush(Color.White);
            for (int i = 0; i <= totallen; i++)
            {
                x = i * 595 / totallen;
                dArea.FillRectangle(sb1, (float)x, 0, 1, 50);
            }
            label5.Text = ("Average waiting time :" + wtime);
            label6.Text = lab;

        }

        private void KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

    }
}
