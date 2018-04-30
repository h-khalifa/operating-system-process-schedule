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
    public partial class SJF : UserControl
    {
        private static SJF _instance;
        public static SJF Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new SJF();
                }
                return _instance;
            }

        }

        Graphics dArea;
        public SJF()
        {
            InitializeComponent();
            dArea = drawingArea.CreateGraphics();
        }

        private void textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void button_ok_Click(object sender, EventArgs e)
        {
            dArea.Clear(Color.WhiteSmoke);
            string x = comboBox1.Text;
            switch (x)
            {
                case "NON-preemptive":
                    nonPreemptive();
                    break;
                case "preemptive":
                    preemptive();
                    break;
            }
        }
        private void nonPreemptive()
        {
            int n;
            n = Convert.ToUInt16(textBox.Text);
            List<double> arrival = new List<double>();
            List<double> len = new List<double>();
            string s2, s3, temp;
            s2 = textBox2.Text;
            s3 = textBox3.Text;
            //////////////////////////////////////
            //////string processing
            //storing arrival in list
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
            /////////////////////////
            ///////    SJF    ///////
            /////////////////////////
            /////////non-pre/////////
            /////////////////////////

            double currenttime = 0, shortest = double.MaxValue, totallen=0, wtime=0, x=0;
            string lab = "";
            int arrive = 0, count = 0, shortestindex=0;
            bool[] arrived;
            arrived = new bool[n];
            bool[] finished;
            finished = new bool[n];

            Color[] colorSet = { Color.Black, Color.Red, Color.Brown,
                Color.Aqua,Color.BlueViolet,Color.CadetBlue,Color.DarkGoldenrod,
                Color.DeepPink,Color.Goldenrod,Color.Gray};

            

            for (int i = 0; i < n; i++)
            {
                totallen += len[i];
                arrived[i] = false;
                finished[i] = false;
            }

            while (currenttime < totallen)
            {
                if (currenttime < arrival[0]) currenttime = arrival[0];

                while (arrival[arrive] <= currenttime)
                {
                    arrived[arrive] = true;
                    arrive++;
                    if (arrive == n) break;
                }
                 arrive = 0;
                //label4.Text =Convert.ToString ( arrive);

                for (int i = 0; i < n; i++)
                {
                    if (arrived[i] && !finished[i] && (shortest > len[i] ) )
                    {
                        shortest = len[i];
                        shortestindex = i;
                    }
                }

                finished[shortestindex] = true;
                wtime += currenttime - arrival[shortestindex];
                currenttime += len[shortestindex];
                SolidBrush sb = new SolidBrush(colorSet[count % 10]);
                dArea.FillRectangle(sb, (float)x, 0, (float)(len[shortestindex] / totallen * 595), 50);
                x += ((len[shortestindex] / totallen) * 595);

                lab += ("P #" + (shortestindex + 1) + " :" + colorSet[count] + ", ");
                count++;
                shortest = double.MaxValue;
            }
            SolidBrush sb1 = new SolidBrush(Color.White);
            for (int i = 0; i <= totallen; i++)
            {
                x = i * 595 / totallen;
                dArea.FillRectangle(sb1, (float)x, 0, 1, 50);
            }
            wtime = wtime / n;
            label3.Text = ("Average waiting time :" + wtime);
            label4.Text = lab;

        }




        private void preemptive()
        {
            int n;
            n = Convert.ToUInt16(textBox.Text);
            List<double> arrival = new List<double>();
            List<double> len = new List<double>();
            string s2, s3, temp;
            s2 = textBox2.Text;
            s3 = textBox3.Text;
            //////////////////////////////////////
            //////string processing
            //storing arrival in list
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
            /////////////////////////
            ///////    SJF    ///////
            /////////////////////////
            /////////non-pre/////////
            /////////////////////////
            double currenttime = 0, shortest = double.MaxValue, totallen = 0, wtime = 0, x = 0;
            string lab = "";
            int arrive = 0,  shortestindex = 0, countready=0;
            bool[] arrived;
            arrived = new bool[n];
            bool[] finished;
            finished = new bool[n];

            double run = double.MaxValue;

            Color[] colorSet = { Color.Black, Color.Red, Color.Brown,
                Color.Aqua,Color.BlueViolet,Color.CadetBlue,Color.DarkGoldenrod,
                Color.DeepPink,Color.Goldenrod,Color.Gray};



            for (int i = 0; i < n; i++)
            {
                totallen += len[i];
                arrived[i] = false;
                finished[i] = false;
            }


            while (currenttime < totallen)
            {
                if (arrive != n)
                {
                    if (arrival[arrive]>currenttime)
                    {
                        currenttime = arrival[arrive];
                    }
                    while(arrival[arrive] <= currenttime)
                    {
                        arrived[arrive] = true;
                        arrive++;
                        countready++;
                        if (arrive == n) break;
                    }

                }

                for (int i=0; i < n; i++)
                {
                    if (arrived[i] && !finished[i] && shortest>len[i])
                    {
                        shortest = len[i];
                        shortestindex = i;
                    }
                }

                if (arrive < (n ))
                    run = arrival[arrive ] - currenttime;

                if (run >= len[shortestindex])
                {
                    countready--;
                    finished[shortestindex] = true;
                    currenttime += len[shortestindex];
                    wtime += countready * len[shortestindex];
                    SolidBrush sb = new SolidBrush(colorSet[shortestindex]);
                    dArea.FillRectangle(sb, (float)x, 0, (float)(len[shortestindex] * 595 / totallen), 50);
                    x+=(len[shortestindex]*595/totallen);
                    lab += ("P #" + (shortestindex + 1) + " :" + colorSet[shortestindex] + ", ");
                }
                else
                {
                    currenttime += run;
                    len[shortestindex] -= run;
                    wtime += (countready - 1) * run;
                    SolidBrush sb = new SolidBrush(colorSet[shortestindex]);
                    dArea.FillRectangle(sb, (float)x, 0, (float)(run * 595 / totallen), 50);
                    x += (run * 595 / totallen);

                }
                run = double.MaxValue;
                shortest = double.MaxValue;
            }
            wtime /= n;
            SolidBrush sb1 = new SolidBrush(Color.White);
            for (int i = 0; i <= totallen; i++)
            {
                x = i * 595 / totallen;
                dArea.FillRectangle(sb1, (float)x, 0, 1, 50);
            }
            label3.Text = ("Average waiting time :" + wtime);
            label4.Text = lab;



        }

        private void KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}
