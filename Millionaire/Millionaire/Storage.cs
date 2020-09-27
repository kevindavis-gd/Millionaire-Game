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

    class Storage
    {
        bool importError = false;

        Questions[] questions;
        public Storage()
        {
            StoreQuestions();
        }//constructor

        public void StoreQuestions()
        {

            MessageBox.Show("Get ready to select question file");
            OpenFileDialog fileChooser = new OpenFileDialog();
            fileChooser.Filter = "Text |* .txt";
            //if OK is clicked
            if (fileChooser.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                //Show conformation message with only file name
                MessageBox.Show(fileChooser.SafeFileName);
                //Streamer points to the full path of the file
                StreamReader file = new StreamReader(fileChooser.FileName);

                Questions[] temp = new Questions[15];
                //read till end of file
                for (int x = 0; x < 15; x++)
                {
                    //add the question object to the list
                    temp[x]= 
                    new Questions(
                    file.ReadLine(),
                    file.ReadLine(),
                    file.ReadLine(),
                    file.ReadLine(),
                    file.ReadLine());
                }//while
                file.Close();
                questions = temp;
            }//if
            else
            {
                importError = true;
                MessageBox.Show("ERROR LOADING QUESTIONS", "ERROR");
            }
        }//Store Questions

        public bool ImportError
        {
            get { return importError; }
        }

        public Questions[] Questions
        {
            get { return questions; }
        }

    }//storage
}//Millionaire
