// Name: Kevin Davis ,Joseph Williamson, Semeion Stafford
// Class : CMPS4143
// Assignment: Program 4
// Date: 09/28/2020
// Description :Replicate the "Who Wants to be a Millionaire Game
//through the use of multiple c# classes, public and private, and multiple gui demonstrations.
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Media;


namespace Millionaire
{
    public partial class MainWindow : Form
    {
        int level;
        int SafeFigure = 0;
        int CurrentWinnings = 0;
        bool gameRunning;
        bool fiftyfifty = true;
        bool phoneFriend = true;
        string AnswerChoice;
        GameLoop loop;
        Storage ques;
        SoundPlayer correctAns = new SoundPlayer("confirmation_002.wav");
        SoundPlayer wrongAns = new SoundPlayer("error_007.wav");
        private static Random rand = new Random();

        public int get_level() { return level; }
        public void set_level(int x) { level = x; }
        public bool get_isRunning() { return gameRunning; }
        public void set_isRunning(bool x) { gameRunning = x; }

        public MainWindow()
        {
            InitializeComponent();
        }
        private void MainWindow_Load(object sender, EventArgs e)
        {
            //dont need anything to happen on load
        }

        //when the play button is clicked
        private void pictureBoxPlay_Click(object sender, EventArgs e)
        {
            //initilize loop and pass this GUI to the loop
            loop = new GameLoop(this);
            //call the loops run method
            loop.Run();
        }

        public void loadQuestions()
        {
            ques = new Storage();
        }
        //load game method that is called at the start of the game
        public void Gameload()
        {
            //Play sounds once so that they will load into memory and play quickly when required
            correctAns.Play();
            wrongAns.Play();
            //set the game level to 0
            level = 0;
            gameRunning = true;
            pictureBoxPlay.Visible = false;
            pictureBoxBG.Visible = true;
            pictureBox5050.Visible = true;
            buttonInstruction.Visible = true;
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
            pictureBoxMoney.Image = Millionaire.Properties.Resources.MoneyChartSmall_1;
        }//end GameLoad

        public void displayQuestion()
        {
            //if there is an issue with the file import, dont load the questions
            if (level < 15 && !ques.ImportError)
            {
                String[] qArray = { ques.Questions[level].Answer1, ques.Questions[level].Answer2, ques.Questions[level].Answer3, ques.Questions[level].Answer4 };
                //randomize the position of the questions
                Shuffle<string>(qArray);
                labelA.Visible = true;
                labelB.Visible = true;
                labelC.Visible = true;
                labelD.Visible = true;
                labelQuestion.Text = ques.Questions[level].Question;
                labelA.Text = qArray[0];
                labelB.Text = qArray[1];
                labelC.Text = qArray[2];
                labelD.Text = qArray[3];
            }
            else
            {
                set_isRunning(false);
                //if there is not an issue with the import of the file
                if (!ques.ImportError)
                {
                    pictureBoxBG.Image = Millionaire.Properties.Resources.Winner;
                    gameRunning = false;
                    pictureBoxPlay.Visible = false;
                    pictureBox5050.Visible = false;
                    pictureBoxPhoneFriend.Visible = false;
                    pictureBoxWalkAway.Visible = false;
                    pictureBoxMoney.Visible = false;
                    groupBox1.Visible = false;
                    labelQuestion.Visible = false;
                    labelA.Visible = false;
                    labelB.Visible = false;
                    labelC.Visible = false;
                    labelD.Visible = false;
                    MessageBox.Show("You Win");
                }
                Application.Restart();
            }
        }//end DisplayQuestion

        public static void Shuffle<T>(T[] array)
        {
            int n = array.Length;
            while (n > 0)
            {
                n--;
                int k = rand.Next(n + 1);
                T value = array[k];
                array[k] = array[n];
                array[n] = value;
            }
        }//end Shuffle

        private void labelA_Click(object sender, EventArgs e)
        {
            AnswerChoice = labelA.Text;
            //continue from waiting in game loop
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
            if (labelA.Text != ques.Questions[level].CorrectAnswer)
                labelA.Visible = false;
            if (labelB.Text != ques.Questions[level].CorrectAnswer)
                labelB.Visible = false;
            if (labelC.Text != ques.Questions[level].CorrectAnswer)
                labelC.Visible = false;
            if (labelD.Text != ques.Questions[level].CorrectAnswer)
                labelD.Visible = false;
            if (AnswerChoice == ques.Questions[level].CorrectAnswer)

            {
                correctAns.Play();
                //correct answer is displayed
                MessageBox.Show("Correct,  \"" + ques.Questions[level].CorrectAnswer + "\" is the answer");
                level += 1;
                picture_change();
            }
            else
            {
                set_isRunning(false);
                wrongAns.Play();
                //correct answer displayed after incorrrect answer
                string message = "wrong, the correct answer is \"" + ques.Questions[level].CorrectAnswer + "\" you only won $" + SafeFigure;
                MessageBox.Show(message);
                Application.Restart();
            }
        }//end CheckAnswer

        public void picture_change()
        {
            if (level == 1)
            {
                pictureBoxMoney.Image = Millionaire.Properties.Resources.MoneyChartSmall_2;
                CurrentWinnings = 100;
                SafeFigure = CurrentWinnings;
            }
            else if (level == 2)
            {
                pictureBoxMoney.Image = Millionaire.Properties.Resources.MoneyChartSmall_3;
                CurrentWinnings = 200;
            }
            else if (level == 3)
            {
                pictureBoxMoney.Image = Millionaire.Properties.Resources.MoneyChartSmall_4;
                CurrentWinnings = 300;
            }
            else if (level == 4)
            {
                pictureBoxMoney.Image = Millionaire.Properties.Resources.MoneyChartSmall_5;
                CurrentWinnings = 500;
            }
            if (level == 5)
            {
                pictureBoxMoney.Image = Millionaire.Properties.Resources.MoneyChartSmall_6;
                CurrentWinnings = 1000;
                SafeFigure = CurrentWinnings;
            }
            else if (level == 6)
            {
                pictureBoxMoney.Image = Millionaire.Properties.Resources.MoneyChartSmall_7;
                CurrentWinnings = 2000;
            }
            else if (level == 7)
            {
                pictureBoxMoney.Image = Millionaire.Properties.Resources.MoneyChartSmall_8;
                CurrentWinnings = 5000;
            }
            else if (level == 8)
            {
                pictureBoxMoney.Image = Millionaire.Properties.Resources.MoneyChartSmall_9;
                CurrentWinnings = 12500;
            }
            else if (level == 9)
            {
                pictureBoxMoney.Image = Millionaire.Properties.Resources.MoneyChartSmall_10;
                CurrentWinnings = 25000;
            }
            if (level == 10)
            {
                pictureBoxMoney.Image = Millionaire.Properties.Resources.MoneyChartSmall_11;
                CurrentWinnings = 50000;
                SafeFigure = CurrentWinnings;
            }
            else if (level == 11)
            {
                pictureBoxMoney.Image = Millionaire.Properties.Resources.MoneyChartSmall_12;
                CurrentWinnings = 75000;
            }
            else if (level == 12)
            {
                pictureBoxMoney.Image = Millionaire.Properties.Resources.MoneyChartSmall_13;
                CurrentWinnings = 150000;
            }
            else if (level == 13)
            {
                pictureBoxMoney.Image = Millionaire.Properties.Resources.MoneyChartSmall_14;
                CurrentWinnings = 325000;
            }
            else if (level == 14)
            {
                pictureBoxMoney.Image = Millionaire.Properties.Resources.MoneyChartSmall_15;
                CurrentWinnings = 500000;
            }
        }// end PictureChange

        private void pictureBoxWalkAway_Click(object sender, EventArgs e)
        {
            string message = "Walking away? the correct answer was \"" + ques.Questions[level].CorrectAnswer + "\" You won $" + CurrentWinnings;
            MessageBox.Show(message);
            Application.Restart();
        }

        private void pictureBox5050_Click(object sender, EventArgs e)
        {
            if (fiftyfifty)
            {
                pictureBox5050.Image = Millionaire.Properties.Resources._50_50_used;
                fiftyfifty = false;
                int count = 2;
                int position = 0;

                Label Q1 = labelA;
                Label Q2 = labelB;
                Label Q3 = labelC;
                Label Q4 = labelD;
                Label[] quesArr = { Q1, Q2, Q3, Q4 };
                //randomize the labels
                Shuffle<Label>(quesArr);
                while (count > 0)
                {
                    //if the question is not the correct answer and it is visible then consider it
                    //ternary operator
                    bool candidate5050 = quesArr[position].Text != ques.Questions[level].CorrectAnswer && quesArr[position].Visible ? true : false;

                    if (candidate5050)
                    {
                        quesArr[position].Visible = false;
                        //decrement the count of answers removed
                        count--;
                    }
                    //increment the position
                    position++;
                }

            }

        }// end PictureBox5050 click

        private void buttonInstruction_Click(object sender, EventArgs e)
        {
            string info = "There are 15 rounds and three “safe havens.” Round 1, 5, and 10 are safe havens. \n\n" +
                    "In each round, a question is revealed with four choices, A-D.\n\n" +
                    "The contestant clicks an answer.\n\n" +
                    "After an answer is clicked, the game will indicate whether the answer is incorrect or correct.\n\n" +
                    "If the answer is correct, the game will reveal the answer in the appropriate label and highlight the dollar amount one.\n\n" +
                    "If the contestant gets the answer correct, the contestant goes on to the next round. \n\n " +
                    "If a contestant answers all questions correctly, the contestant wins $1 million. \n\n" +
                    "If an answer is incorrect – the game will be over. \n\n." +
                    "The contestant will win the guaranteed amount for the last safe haven, for which they answered the question correctly. \n\n" +
                    "Winning the game: A contestant “wins” by walking away with the dollar amount for the last question answered or when they correctly answer the million dollar questions. \n";

            MessageBox.Show(info);
        }

        private void pictureBoxPhoneFriend_Click(object sender, EventArgs e)
        {
            if (phoneFriend)
            {
                phoneFriend = false;
                pictureBoxPhoneFriend.Image = Millionaire.Properties.Resources.phone_a_friend_used;
                string[] options = { labelA.Text, labelB.Text, labelC.Text, labelD.Text };
                Random rand = new Random();
                int selection = rand.Next(0, 4);
                MessageBox.Show("Your Friend Says '" + options[selection] + "' is the right answer");
            }

        }
    }
}


