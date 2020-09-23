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
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
           
        }
        //when the play button is clicked
        private void pictureBox5_Click(object sender, EventArgs e)
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

                labelQuestion.Text = file.ReadLine();
                labelA.Text = file.ReadLine();
                labelB.Text = file.ReadLine();
                labelC.Text = file.ReadLine();
                labelD.Text = file.ReadLine();
            }

            pictureBoxPlay.Visible = false;
            pictureBoxBG.Visible = true;
            pictureBox5050.Visible = true;
            pictureBoxphoneFriend.Visible = true;
            pictureBoxWalkAway.Visible = true;
            pictureBoxMoney.Visible = true;
            groupBox1.Visible = true;
            labelQuestion.Visible = true;
            labelA.Visible = true;
            labelB.Visible = true;
            labelC.Visible = true;
            labelD.Visible = true;
        }
    }
}
