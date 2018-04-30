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
    public partial class FCFS : UserControl
    {
        private static FCFS _instance;
        public static FCFS Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new FCFS();
                }
                return _instance;
            }

        }

        Graphics dArea;
        public FCFS()
        {
            InitializeComponent();
            dArea = drawingArea.CreateGraphics();
        }

        private void button_ok_Click(object sender, EventArgs e)
        {
            int n;
            n = Convert.ToUInt16(textBox1.Text);
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
                if (s2[i]==' ')
                {
                    indl = i;
                    temp = s2.Substring(indf, indl - indf);
                    indf = indl + 1;
                    arrival.Add(Convert.ToDouble(temp));
                    
                }
                else if (s2[i]==';' )
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
            ////////////////////////////////
            ////////FCFS algorithm//////////
            ////////////////////////////////

            ///storing indexes of arrivals(sorted) of process in indexOfsorted[]
/*
            int[] indexOfsorted = new int[n];
            double oldmin = -1, newmin = double.MaxValue;
            for (int j = 0; j < n; j++)
            {
                if (j != 0) oldmin = newmin;
                newmin = double.MaxValue;
                for (int i = 0; i < n; i++)
                {
                    if (arrival[i]>oldmin && arrival[i]<newmin  )
                    {
                        newmin = arrival[i];
                        indexOfsorted[j] = i;
                        
                    }
                }

            }
            */
            double wtime=0,currenttime=0;

            ////////////////////////////////
            /////////////drawing////////////
            ////////////////////////////////
            double totallen = 0, x = 0, y = 0;
            float xx, yy;
            for (int i = 0; i < n; i++) totallen += len[i];
            Color[] colorSet = { Color.Black, Color.Red, Color.Brown,
                Color.Aqua,Color.BlueViolet,Color.CadetBlue,Color.DarkGoldenrod,
                Color.DeepPink,Color.Goldenrod,Color.Gray};

            dArea.Clear(Color.WhiteSmoke);
            string proc_color="";
            x = 0;
            for (int i = 0; i < n; i++)
            {
                SolidBrush sb = new SolidBrush(colorSet[i%10]);
                wtime += currenttime-arrival[i];
                xx = (float)x; yy = (float)y;
                dArea.FillRectangle(sb, xx, yy, (float)(len[ i] / totallen * 595), 50);
                x += ((len[i] / totallen) * 595);
                currenttime += len[i];
                proc_color += ("P#"+(i+1)+ ": "+colorSet[i]+" ,");


            }
            SolidBrush sb1 = new SolidBrush(Color.White);
            for (int i = 0; i <= totallen; i++)
            {
                x = i * 595 / totallen;
                dArea.FillRectangle(sb1, (float)x, 0, 1, 50);
            }
            wtime = wtime / n;
            label5.Text = ("average waiting time is:"+wtime);
            label4.Text = proc_color;




        }

        private void KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}
