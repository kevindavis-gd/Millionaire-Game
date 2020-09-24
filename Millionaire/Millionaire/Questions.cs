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
        public string correctAnswer, question, answer1, answer2, answer3, answer4;
        public bool seen;
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
    }
}
