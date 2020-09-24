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
        public List<Questions> questions;
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

                List<Questions> temp = new List<Questions>();
                //read till end of file
                while (file.Peek() > 0)
                {
                    //add the question object to the list
                    temp.Add(
                    new Questions(
                    file.ReadLine(),
                    file.ReadLine(),
                    file.ReadLine(),
                    file.ReadLine(),
                    file.ReadLine()
                    )
                    );
                }//while
                file.Close();
                questions = temp;
            }//if
        }//Store Questions
    }//storage
}//Millionaire
