using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Teor_ver_lab
{
    public partial class Form1 : Form
    {
        List<int> seq;
        int[] count;
        string p_x;
        int x;
        int n;
        int[] count_total;
        //int dice;
        //int length = 0;
        public Form1()
        {
            InitializeComponent();
            seq = new List<int>();
            count = new int[10];
            count_total = new int[10000000];
            
        }

        public void get_numbers(int t)
        {
            int[] count_size = new int[10000000]; 
            for(int i = 0; i <t; i++)
            {
                int dice;
                if ((p_x != "0") && (p_x != "1"))
                {
                    dice = (int)Math.Pow(10, (p_x.Length - 2));
                    //MessageBox.Show(Convert.ToString(dice));
                }
                else
                    dice = Convert.ToInt32(p_x);
                //std::cout << "dice " << dice;
                int length = (int)(Convert.ToDouble(p_x) * dice);
                //std::cout << std::endl << "p_x " << std::stod(p_x) << std::endl << "length" << length << std::endl;
                var rand = new Random();
                while (true)
                {
                    int tmp = rand.Next(0, dice);
                    //std::cout << tmp << std::endl;
                    if (tmp <= length)
                    {
                        seq.Add(x);
                        //count[x] += 1;
                        //MessageBox.Show(Convert.ToString(count[x]));
                        break;
                    }
                    else if (tmp > length)

                    {
                        int tmp_l = rand.Next(0, x);
                        int tmp_r = rand.Next(x + 1, 10);
                        int coin = rand.Next(0, 2);
                        if (((coin == 1) || (x == 9)) && (x != 0))
                        {
                            seq.Add(tmp_l);
                            //count[tmp_l] += 1;
                        }
                        else
                        {
                            seq.Add(tmp_r);
                            //count[tmp_r] += 1;
                        }

                    }

                }

                count_total[seq.Count] += 1;
                MessageBox.Show(Convert.ToString(seq.Count));
                clear_seq();
            }
        }

        private void clear_seq()
        {

                for (int i = 0; i < count.Length; i++)
                {
                    count[i] = 0;
                }
                seq.Clear();

        }
        private void clear()
        {
            for(int i = 0; i < count.Length; i++) 
            {
                count[i] = 0;
            }
            seq.Clear();
            for (int i = 0; i < 10000000; i++)
                count_total[i] = 0;
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();
            chart1.Series[0].Points.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            clear();
            this.p_x = textBox2.Text;
            this.n = Convert.ToInt32(textBox1.Text);
            this.x = 5;
            get_numbers(n);

            for(int i = 0; i < 10000000; i++)
            {
                if (count_total[i] != 0)
                {
                    dataGridView1.Rows.Add(i, count_total[i], Convert.ToDouble(count_total[i]) / Convert.ToDouble(n));
                    chart1.Series[0].Points.AddXY(i, count_total[i]);
                }
            }
            //dataGridView1.Rows.Add("n_i", count[0], count[1], count[2], count[3], count[4], count[5], count[6], count[7], count[8], count[9]);
            //dataGridView1.Rows.Add("n_i / n", Convert.ToDouble(count[0]) / Convert.ToDouble(seq.Count), Convert.ToDouble(count[1]) / Convert.ToDouble(seq.Count),  Convert.ToDouble(count[2]) / Convert.ToDouble(seq.Count), Convert.ToDouble(count[3]) / Convert.ToDouble(seq.Count), Convert.ToDouble(count[4]) / Convert.ToDouble(seq.Count), Convert.ToDouble(count[5]) / Convert.ToDouble(seq.Count), Convert.ToDouble(count[6]) / Convert.ToDouble(seq.Count), Convert.ToDouble(count[7]) / Convert.ToDouble(seq.Count), Convert.ToDouble(count[8]) / Convert.ToDouble(seq.Count), Convert.ToDouble(count[9]) / Convert.ToDouble(seq.Count));
            //dataGridView1.Rows.Add("Всего", seq.Count);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            clear();
        }
    }
}
