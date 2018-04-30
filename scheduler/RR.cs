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
    public partial class RR : UserControl
    {
        Graphics dArea;

        private static RR _instance;
        public static RR Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new RR();
                }
                return _instance;
            }

        }



        public RR()
        {
            InitializeComponent();
            dArea = drawingArea.CreateGraphics();
        }

        private void button_ok_Click(object sender, EventArgs e)
        {
            dArea.Clear(Color.WhiteSmoke);
            int n;
            n = Convert.ToUInt16(textBox1.Text);
            double q, totallen = 0;
            q = Convert.ToDouble(textBox2.Text);
            List<double> arrival = new List<double>();
            List<double> len = new List<double>();
            string s2, s3, temp;
            s2 = textBox3.Text;
            s3 = textBox4.Text;
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
                    totallen += (Convert.ToDouble(temp));
                }
                else if (s3[i] == ';')
                {
                    indl = i;
                    temp = s3.Substring(indf, indl - indf);
                    len.Add(Convert.ToDouble(temp));
                    totallen += (Convert.ToDouble(temp));
                }
            }

            ////////////////////////////////////////
            //////////round robin code /////////////
            ////////////////////////////////////////
            Color[] colorSet = { Color.Black, Color.Red, Color.Brown,
                Color.Aqua,Color.BlueViolet,Color.CadetBlue,Color.DarkGoldenrod,
                Color.DeepPink,Color.Goldenrod,Color.Gray};

            double wtime = 0, currenttime = 0, x = 0;
            int tempindex = 0, arrive = 0, countelement;
            Queue<int> index = new Queue<int>();
            bool remain = false;
            string lab = "";


            while (currenttime < totallen)
            {
                if (arrive != n)
                {
                   // if (currenttime < arrival[arrive])
                    //    currenttime = arrival[arrive];

                    while (currenttime >= arrival[arrive])
                    {
                        index.Enqueue(arrive);
                        arrive++;
                        if (arrive == n)
                            break;
                    }
                }

                if (remain)
                    index.Enqueue(tempindex);

                tempindex = index.Dequeue();
                countelement = index.Count;

                if (len[tempindex] > q)
                {

                    wtime += countelement * q;
                    currenttime += q;
                    len[tempindex] -= q;
                    SolidBrush sb = new SolidBrush(colorSet[tempindex]);
                    dArea.FillRectangle(sb, (float)x, 0, (float)(q * 595 / totallen), 50);
                    x += (q * 595 / totallen);
                    remain = true;

                }
                else if (len[tempindex] <= q)
                {

                    wtime += countelement * len[tempindex];
                    currenttime += len[tempindex];
                    remain = false;
                    SolidBrush sb = new SolidBrush(colorSet[tempindex]);
                    dArea.FillRectangle(sb, (float)x, 0, (float)(len[tempindex] * 595 / totallen), 50);
                    x += (len[tempindex] * 595 / totallen);
                    lab+=("P #" + (tempindex + 1) + " :" + colorSet[tempindex] + ", ");


                }


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
