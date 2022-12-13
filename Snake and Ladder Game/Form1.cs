using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Snake_and_Ladder_Game
{
    public partial class Form1 : Form
    {
        int turn_brown = 0; //0 menz turn white player ki hai
        int[] pos = new int[104];
        bool white = false, brown=false;
        int x = 3, y = 385;
        int x2 = 3, y2 = 385;
        int DiceValue, p=01, q=01;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Hidelable();
            if (turn_brown == 0)
            {
                button2.Enabled = false;
                label11.BackColor = System.Drawing.Color.Red;
                label11.Text = "Player 1";
            }
            //Ladder();
            //SnakeBites();
            pictureBox4.Visible = false;
            pictureBox5.Visible = false;
            pictureBox3.Image = Image.FromFile(@"D:\aptech\2nd Semester\C#\Programming\Snake and Ladder Game\Snake and Ladder Game\Resources\diceroll.png");
            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;//stretch image code
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DiceValue = Roll_Dice(pictureBox3);
            label6.Text = DiceValue.ToString();

            if (white == true)
            {
                p = Move(ref x, ref y, p, DiceValue, ref pos, pictureBox4, label7);
                //p = Move(ref x, ref y, p, DiceValue, pictureBox4, label7);
            }
            //starting condition for 6
            if (label6.Text == "6" && white == false) 
            {
                pictureBox4.Visible = true;
                pictureBox1.Visible = false;
                white = true;

                pictureBox4.Location = new Point(x, y);
                label5.Text = x.ToString();
                label4.Text = y.ToString();
                label7.Text = p.ToString();
               // p++;
                pos[p] = 1;

            }

            if (p == 100)
            //if (p == 100) 
            {
                MessageBox.Show("You Won","Alert");
                button1.Enabled = false;
            }
            
            //snake mthod calling
            p = Snake(ref x, ref y, p, pictureBox4);

            //Ladder method calling
            p = ladder(ref x, ref y, p, pictureBox4);
            label7.Text = p.ToString();


            if(DiceValue==6)
            {
                turn_brown = 0;
            }
            else
            {
                
                turn_brown = 1;
                button1.Enabled = false;
                button2.Enabled = true;
                label11.BackColor = System.Drawing.Color.PaleGreen;
                label11.Text = "Player 2";
            }
        }//end of button event

        private int Roll_Dice(PictureBox PB)
        {
            int dice = 0;
            Random r = new Random();
            dice = r.Next(1, 7);

            PB.Image = Image.FromFile(@"D:\aptech\2nd Semester\C#\Programming\Snake and Ladder Game\Snake and Ladder Game\Resources\" + dice + ".png");
            PB.SizeMode = PictureBoxSizeMode.StretchImage;

            return dice;

        }//end of roll dice method

        
        private int Move(ref int x,ref int y, int p, int dice, ref int[]pos,PictureBox px,Label l)
        {
            if (dice + p > 100)
            {
                l.Text = "Cannot move";
                l.ForeColor = System.Drawing.Color.Red;
                
                
            }

            else
            {
                for (int i = 0; i < dice; i++)
                {


                    if (p == 10)
                    {
                        x = 19;
                        y = 346;
                       // p++;
                    }
                    else if (p == 20)
                    {
                        x = 19;
                        y = 306;
                       // p++;
                    }

                    else if (p == 30)
                    {
                        x = 19;
                        y = 263;
                        //p++;
                    }

                    else if (p == 40)
                    {
                        x = 19;
                        y = 213;
                       // p++;
                    }

                    else if (p == 50)
                    {
                        x = 19;
                        y = 179;
                        //p++;
                    }

                    else if (p == 60)
                    {
                        x = 19;
                        y = 140;
                       // p++;
                    }

                    else if (p == 70)
                    {
                        x = 19;
                        y = 91;
                       // p++;
                    }

                    else if (p == 80)
                    {
                        x = 19;
                        y = 48;
                       // p++;
                    }

                    else if (p == 90)
                    {
                        x = 19;
                        y = 6;
                       // p++;
                    }

                   
                    else
                    {
                        x += 63;
                        

                    }

                    l.Text = p.ToString();
                    px.Location = new Point(x, y);
                    p++;
                    //pos[p] = 1;

                }//end of for loop
            }
            return p;            
        }//end of move method

        //snake bite method
        private int Snake(ref int x,ref int y,int p, PictureBox px)
        {
            if (p == 25)
            {
                x = 262;
                y = 389;
                p = 5;

                //px.Location = new Point(x, y);
            }

            else if (p == 34)
            {
                x = 19;
                y = 390;
                p = 1;

               //px.Location = new Point(x, y);
            }

            else if (p == 47)
            {
                x = 507;
                y = 389;
                p = 9;
                //px.Location = new Point(x, y);
            }

            else if (p == 65)
            {
                x = 85;
                y = 183;
                p = 52;
                //px.Location = new Point(x, y);
            }

            else if (p == 87)
            {
                x = 387;
                y = 179;
                p = 57;
                //px.Location = new Point(x, y);
            }

            else if (p == 91)
            {
                x = 19;
                y = 139;
                p = 61;
                //px.Location = new Point(x, y);
            }

            else if (p == 99)
            {
                x = 501;
                y = 139;
                p = 69;
                //px.Location = new Point(x, y);
            }
            px.Location = new Point(x, y);
            return p;
        }//end of snake method

        private int ladder(ref int x,ref int y,int p, PictureBox px)
        {
            if (p == 3)
            {
                x = 19;
                y = 180;
                p = 51;
            }

            else if (p == 6)
            {
                x = 385;
                y = 306;
                p = 27;
            }

            else if (p == 20)
            {
                x = 566;
                y = 139;
                p = 70;
            }

            else if (p == 36)
            {
                x = 265;
                y = 180;
                p = 55;
            }
            else if (p == 63)
            {
                x = 265;
                y = 6;
                p = 95;
            }
            else if (p == 68)
            {
                x = 447;
                y = 6;
                p = 98;
            }

            px.Location = new Point(x, y);
            return p;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DiceValue = Roll_Dice(pictureBox3);
            label6.Text = DiceValue.ToString();

            if (brown == true)
            {
                q = Move(ref x2, ref y2, q, DiceValue, ref pos, pictureBox5, label9);
                //p = Move(ref x, ref y, p, DiceValue, pictureBox4, label7);
            }

            if (label6.Text == "6" && brown == false)
            {
                pictureBox5.Visible = true;
                pictureBox2.Visible = false;
                brown = true;

                pictureBox5.Location = new Point(x, y);
                label5.Text = x.ToString();
                label4.Text = y.ToString();
                label9.Text = q.ToString();
                // q++;
                pos[q] = 1;
            }

            if (q == 100)
            {
                MessageBox.Show("You Won", "Alert");
                button2.Enabled = false;
            }

            //snake mthod calling
            q = Snake(ref x2, ref y2, q, pictureBox5);

            //Ladder method calling
            q = ladder(ref x2, ref y2, q, pictureBox5);
            label9.Text = q.ToString();

            if (DiceValue == 6)
            {
                turn_brown = 1;
            }
            else
            {
                turn_brown = 0;
                button2.Enabled = false;
                button1.Enabled = true;
                label11.BackColor = System.Drawing.Color.Red;
                label11.Text = "Player 1";
            }
        }//p2

        
    }
}
