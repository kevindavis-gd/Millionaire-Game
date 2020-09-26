using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;


namespace Millionaire
{
    public partial class MainWindow : Form
    {
        int level;
        Storage ques;
        bool gameRunning;
        string AnswerChoice;
        GameLoop loop;
        int SafeFigure = 0;
        int CurrentWinnings = 0;


        public int get_level()
        {
            return level;
        }
        public void set_level(int x)
        {
            level = x;
        }

        public bool get_isRunning()
        {
            return gameRunning;
        }
        public void set_isRunning(bool x)
        {
            gameRunning = x;
        }


        public MainWindow()
        {
            InitializeComponent();
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
        }
        //when the play button is clicked
        private void pictureBoxPlay_Click(object sender, EventArgs e)
        {
            loop = new GameLoop(this);
            loop.Run();

        }

        public void loadQuestions()
        {
            ques = new Storage();
        }
        public void Gameload()
        { 
            level = 0;
            gameRunning = true;
            pictureBoxPlay.Visible = false;
            pictureBoxBG.Visible = true;
            pictureBox5050.Visible = true;
            pictureBoxPhoneFriend.Visible = true;
            pictureBoxWalkAway.Visible = true;
            pictureBoxMoney.Visible = true;
            groupBox1.Visible = true;
            labelQuestion.Visible = true;
            labelA.Visible = true;
            labelB.Visible = true;
            labelC.Visible = true;
            labelD.Visible = true;
            //Allow Question label to wrap
            labelQuestion.MaximumSize = new Size(350, 0);
        }//GameLoad

        public void displayQuestion()
        {
            if (level < 15)
            {
                labelQuestion.Text = ques.questions[level].question;
                labelA.Text = ques.questions[level].answer1;
                labelB.Text = ques.questions[level].answer2;
                labelC.Text = ques.questions[level].answer3;
                labelD.Text = ques.questions[level].answer4;
            }
            else
            {
                MessageBox.Show("You Win");
                Application.Restart();
            }
            

        }//GetQuestion

     

        private void labelA_Click(object sender, EventArgs e)
        {
            AnswerChoice = labelA.Text;
            loop.set_task(true);
        }

        private void labelB_Click(object sender, EventArgs e)
        {
            AnswerChoice = labelB.Text;
            loop.set_task(true);
        }

        private void labelC_Click(object sender, EventArgs e)
        {
            AnswerChoice = labelC.Text;
            loop.set_task(true);
        }

        private void labelD_Click(object sender, EventArgs e)
        {
            AnswerChoice = labelD.Text;
            loop.set_task(true);
        }


        public void CheckAnswer()
        {
            if (AnswerChoice == ques.questions[level].correctAnswer)
            {
                level += 1;
                //MessageBox.Show("correct");

                picture_change();
            }
            else
            {
                string message = "wrong, you only won $"+ SafeFigure;
                MessageBox.Show(message);
                Application.Restart();


            }
        }

        public void picture_change()
        {
            if (level == 1)
            {
                pictureBoxMoney.Image = Millionaire.Properties.Resources.MoneyChartSmall_1;
                
                CurrentWinnings = 100;
                SafeFigure = CurrentWinnings;
            }
                
            else if (level == 2)
            {
                pictureBoxMoney.Image = Millionaire.Properties.Resources.MoneyChartSmall_2;
                CurrentWinnings = 200;
            }
                
            else if (level == 3)
            {
                pictureBoxMoney.Image = Millionaire.Properties.Resources.MoneyChartSmall_3;
                CurrentWinnings = 300;
            }
                
            else if (level == 4)
            {
                pictureBoxMoney.Image = Millionaire.Properties.Resources.MoneyChartSmall_4;
                CurrentWinnings = 500;
            }
                
            if (level == 5)
            {
                pictureBoxMoney.Image = Millionaire.Properties.Resources.MoneyChartSmall_5;
                CurrentWinnings = 1000;
                SafeFigure = CurrentWinnings;
            }
            else if (level == 6)
            {
                pictureBoxMoney.Image = Millionaire.Properties.Resources.MoneyChartSmall_6;
                CurrentWinnings = 2000;
            }
                
            else if (level == 7)
            {
                pictureBoxMoney.Image = Millionaire.Properties.Resources.MoneyChartSmall_7;
                CurrentWinnings = 5000;
            }
                
            else if (level == 8)
            {
                pictureBoxMoney.Image = Millionaire.Properties.Resources.MoneyChartSmall_8;
                CurrentWinnings = 12500;
            }
                
            else if (level == 9) 
            {
                pictureBoxMoney.Image = Millionaire.Properties.Resources.MoneyChartSmall_9;
                CurrentWinnings = 25000;
            }
               
            if (level == 10)
            {
                pictureBoxMoney.Image = Millionaire.Properties.Resources.MoneyChartSmall_10;
                CurrentWinnings = 50000;
                SafeFigure = CurrentWinnings;
            }
            else if (level == 11)
            {
                pictureBoxMoney.Image = Millionaire.Properties.Resources.MoneyChartSmall_11;
                CurrentWinnings = 75000;
            }
                
            else if (level == 12)
            {
                pictureBoxMoney.Image = Millionaire.Properties.Resources.MoneyChartSmall_12;
                CurrentWinnings = 150000;
            }
                
            else if (level == 13)
            {
                pictureBoxMoney.Image = Millionaire.Properties.Resources.MoneyChartSmall_13;
                CurrentWinnings = 325000;
            }
                
            else if (level == 14)
            {
                pictureBoxMoney.Image = Millionaire.Properties.Resources.MoneyChartSmall_14;
                CurrentWinnings = 500000;
            }
                
            if (level == 15)
            {
                pictureBoxMoney.Image = Millionaire.Properties.Resources.MoneyChartSmall_15;
                SafeFigure = 1000000;
            }

        }

        private void pictureBoxWalkAway_Click(object sender, EventArgs e)
        {
            string message = "Walking away? You won $" + CurrentWinnings;
            MessageBox.Show(message);
            Application.Restart();
        }

        private void pictureBox5050_Click(object sender, EventArgs e)
        {
            pictureBoxMoney.Image = Millionaire.Properties.Resources._50_50_used;
            labelB.Visible = false;
            labelC.Visible = false;
        }
    }//MainWindow  
}//Millionaire


