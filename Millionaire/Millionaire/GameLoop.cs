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
    
    public class GameLoop
    {
        MainWindow window;
        //internal by default, change to public
        public GameLoop(MainWindow win)
        {
            window = win;
            
        }

        public void Run()
        {
            window.loadQuestions();
            window.Gameload();

            
            while(true)
            {
                window.set_level(1);
                window.displayQuestion();
            }
           


        }

    }
}
