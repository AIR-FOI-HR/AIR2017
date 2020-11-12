using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Matrix_test
{
    public partial class Form1 : Form
    {
        Box[,] input;
        Box[,] template;
        int time = 0;
        LinkedList<Box> inputList = new LinkedList<Box>();
        LinkedList<Box> templates = new LinkedList<Box>();

        public Form1()
        {
            InitializeComponent();
        }

        private void panel1_MouseEnter(object sender, EventArgs e)
        {
            Panel panel = (Panel)sender;
            panel.BackColor = Color.Black;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            createMatrixI(input, 5, 5, 10, 10);
            createMatrixT(template, 350, 5, 10, 10);
            Cast.BackColor = Color.Yellow;
        }

        private void createMatrixI(Box[,] arr,int x, int y, int n, int m)
        {
            Point origin = new Point(x, y);
            arr = new Box[m, n];
            for (int i = 0; i < m; i++)
            {
                origin.Y = i * 30 + y;
                for (int j = 0; j < n; j++)
                {
                    origin.X = j * 30 + x;
                    arr[i, j] = new Box();
                    arr[i, j].Size = new Size(25, 25);
                    arr[i, j].BackColor = Color.White;
                    arr[i, j].Location = origin;
                    arr[i, j].MouseEnter += Form1_MouseEnter;
                    arr[i, j].MouseLeave += Form1_MouseLeave;
                    arr[i, j].time = 0;
                    arr[i, j].X = j;
                    arr[i, j].Y = i;
                    Controls.Add(arr[i, j]);
                }
            }
        }

        private void createMatrixT(Box[,] arr, int x, int y, int n, int m)
        {
            Point origin = new Point(x, y);
            arr = new Box[m, n];
            for (int i = 0; i < m; i++)
            {
                origin.Y = i * 30 + y;
                for (int j = 0; j < n; j++)
                {
                    origin.X = j * 30 + x;
                    arr[i, j] = new Box();
                    arr[i, j].Size = new Size(25, 25);
                    arr[i, j].BackColor = Color.White;
                    arr[i, j].Location = origin;
                    arr[i, j].MouseClick += Form1_MouseClick;
                    arr[i, j].time = 0;
                    arr[i, j].X = j;
                    arr[i, j].Y = i;
                    Controls.Add(arr[i, j]);
                }
            }
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            Box panel = (Box)sender;
            if (e.Button == MouseButtons.Left)
            {
                panel.time = 1;
                panel.BackColor = Color.Black;
                templates.AddFirst(panel);

            } else if(e.Button == MouseButtons.Right)
            {
                panel.time = 0;
                panel.BackColor = Color.White;
                templates.Remove(panel);
            }
            textBox1.Text = "";
            foreach (var item in templates)
            {
                textBox1.Text += item.X.ToString() + ";" + item.Y.ToString() + "\r\n";
            }
        }

        private void Form1_MouseLeave(object sender, EventArgs e)
        {
            //badCheck();
            betterCheck();
        }

        private void Form1_MouseEnter(object sender, EventArgs e)
        {
            Box panel = (Box)sender;
            if(true)
            {
                panel.BackColor = Color.Black;
                panel.time = time;
                inputList.AddFirst(panel);
                time++;
                label1.Text = panel.X.ToString() + ";" + panel.Y.ToString();
                label2.Text = inputList.Count.ToString();
            }
           
        }


        private void betterCheck()
        {
            while(time - inputList.Last.Value.time >= 2)
            {
                inputList.Last.Value.time = 0;
                inputList.Last.Value.BackColor = Color.White;
                inputList.RemoveLast();
            }
            int counter = 0;
            foreach (var input in inputList)
            {
                foreach (var template in template)
                {
                    if (input.X == template.X && input.Y == template.Y)
                    {
                        counter++;
                    }
                }
            }
            if(counter / template.Length > 50)
            {
                Cast.BackColor = Color.Green;
            }
        }

        private void loadTest()
        {
            for (int i = 0; i < 100; i++)
            {
                for (int j = 0; j < 100; j++)
                {
                    for (int k = 0; k < 100; k++)
                    {
                        if (false) ;
                    }
                }
            }
        }

        private void badCheck()
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (time - input[i, j].time >= 5)
                    {
                        input[i, j].time = 0;
                        input[i, j].BackColor = Color.White;
                    }
                }
            }
        }

        
    }
}
