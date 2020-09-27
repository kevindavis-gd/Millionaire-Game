using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
        }

        public string Answer4
        {
            get { return answer4; }
            set { answer4 = value; }
        } 
        public string Answer3
        {
            get { return answer3; }
            set { answer3 = value; }
        }
        public string Answer2
        {
            get { return answer2; }
            set { answer2 = value; }
        }

        public string Answer1
        {
            get { return answer1; }
            set { answer1 = value; }
        }

        public string CorrectAnswer
        {
            get { return correctAnswer; }
            set { correctAnswer = value; }
        }

        public string Question
        {
            get { return question; }
            set { question = value; }
        }
    }
}
