// Name: Kevin Davis ,Joseph Williamson, Semeion Stafford
// Class : CMPS4143
// Assignment: Program 4
// Date: 09/28/2020
// Description :Replicate the "Who Wants to be a Millionaire Game
//through the use of multiple c# classes, public and private, and multiple gui demonstrations.

namespace Millionaire
{
    public class Questions
    {
        private string correctAnswer, question, answer1, answer2, answer3, answer4;
        private bool seen;
        public Questions(string Q, string A1, string A2, string A3, string A4)
        {
            this.question = Q;
            this.answer1 = A1;
            this.answer2 = A2;
            this.answer3 = A3;
            this.answer4 = A4;
            this.correctAnswer = A1;
            seen = false;
        }//constructor

        public bool Seen
        {
            get { return seen; }
            set { seen = value; }
        }//Seen

        public string Answer4
        {
            get { return answer4; }
            set { answer4 = value; }
        }//Answer4 
        public string Answer3
        {
            get { return answer3; }
            set { answer3 = value; }
        }//Answer3
        public string Answer2
        {
            get { return answer2; }
            set { answer2 = value; }
        }//Answer2

        public string Answer1
        {
            get { return answer1; }
            set { answer1 = value; }
        }//Answer1

        public string CorrectAnswer
        {
            get { return correctAnswer; }
            set { correctAnswer = value; }
        }//CorrectAnswer

        public string Question
        {
            get { return question; }
            set { question = value; }
        }//Question
    }//Questions
}//Millionaire
