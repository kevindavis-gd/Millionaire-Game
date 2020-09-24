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
            GameLoop loop = new GameLoop(this);
            loop.Run();

        }
        private void pictureBoxExit_Click(object sender, EventArgs e)
        {
            GameExit();
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
            pictureBoxExit.Visible = true;
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













        public void GameExit()
        {
            pictureBoxPlay.Visible = true;
            pictureBoxBG.Visible = false;
            pictureBox5050.Visible = false;
            pictureBoxPhoneFriend.Visible = false;
            pictureBoxWalkAway.Visible = false;
            pictureBoxMoney.Visible = false;
            pictureBoxExit.Visible = false;
            groupBox1.Visible = false;
            labelQuestion.Visible = false;
            labelA.Visible = false;
            labelB.Visible = false;
            labelC.Visible = false;
            labelD.Visible = false;
        }//GameExit
    }//MainWindow  
}//Millionaire


