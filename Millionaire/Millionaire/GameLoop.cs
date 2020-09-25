using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Timers;
using System.Windows.Forms;
using System.IO;

namespace Millionaire
{
    
    public class GameLoop
    {
        MainWindow window;
        TaskCompletionSource<bool> tcs = null;

        //internal by default, change to public
        public GameLoop(MainWindow win)
        {
            window = win;
            
        }

        public async void Run()
        {
            window.loadQuestions();
            window.Gameload();
            

            //game loop finaly working

            //do while requirement met :)
            
            do
            {
                window.displayQuestion();
                tcs = new TaskCompletionSource<bool>();
                await tcs.Task;

                //tcs?.TrySetResult(true);
                window.CheckAnswer();
                //window.set_level(window.get_level() + 1);
            } while (window.get_isRunning());


        }

        public void set_task(bool x)
        {
            tcs?.TrySetResult(x);
        }

    }
}
