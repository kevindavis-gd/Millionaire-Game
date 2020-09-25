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
        int WalkAwayFigure = 0;


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
        }//GameLoad

        public void displayQuestion()
        {
            labelQuestion.Text = ques.questions[level].question;
            labelA.Text = ques.questions[level].answer1;
            labelB.Text = ques.questions[level].answer2;
            labelC.Text = ques.questions[level].answer3;
            labelD.Text = ques.questions[level].answer4;

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
                MessageBox.Show("correct");

                picture_change();

            }
            else
            {
                string message = "wring, walk away value is $"+ WalkAwayFigure;
                MessageBox.Show(message);
                Application.Restart();


            }
        }

        public void picture_change()
        {
            if (level == 1)
            {
                pictureBoxMoney.Image = Millionaire.Properties.Resources.MoneyChartSmall_1;
                WalkAwayFigure = 100;
            }
                
            else if (level == 2)
                pictureBoxMoney.Image = Millionaire.Properties.Resources.MoneyChartSmall_2;
            else if (level == 3)
                pictureBoxMoney.Image = Millionaire.Properties.Resources.MoneyChartSmall_3;
            else if (level == 4)
                pictureBoxMoney.Image = Millionaire.Properties.Resources.MoneyChartSmall_4;
            if (level == 5)
            {
                pictureBoxMoney.Image = Millionaire.Properties.Resources.MoneyChartSmall_5;
                WalkAwayFigure = 1000;
            }
            else if (level == 6)
                pictureBoxMoney.Image = Millionaire.Properties.Resources.MoneyChartSmall_6;
            else if (level == 7)
                pictureBoxMoney.Image = Millionaire.Properties.Resources.MoneyChartSmall_7;
            else if (level == 8)
                pictureBoxMoney.Image = Millionaire.Properties.Resources.MoneyChartSmall_8;
            else if (level == 9)
                pictureBoxMoney.Image = Millionaire.Properties.Resources.MoneyChartSmall_9;
            if (level == 10)
            {
                pictureBoxMoney.Image = Millionaire.Properties.Resources.MoneyChartSmall_1;
                WalkAwayFigure = 50000;
            }
            else if (level == 11)
                pictureBoxMoney.Image = Millionaire.Properties.Resources.MoneyChartSmall_11;
            else if (level == 12)
                pictureBoxMoney.Image = Millionaire.Properties.Resources.MoneyChartSmall_12;
            else if (level == 13)
                pictureBoxMoney.Image = Millionaire.Properties.Resources.MoneyChartSmall_13;
            else if (level == 14)
                pictureBoxMoney.Image = Millionaire.Properties.Resources.MoneyChartSmall_14;
            if (level == 15)
            {
                pictureBoxMoney.Image = Millionaire.Properties.Resources.MoneyChartSmall_15;
                WalkAwayFigure = 1000000;
            }

        }

        private void pictureBoxWalkAway_Click(object sender, EventArgs e)
        {
            string message = "wring, walk away value is $" + WalkAwayFigure;
            MessageBox.Show(message);
            Application.Restart();
        }
    }//MainWindow  
}//Millionaire


