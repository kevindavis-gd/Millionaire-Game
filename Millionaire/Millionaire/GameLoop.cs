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
            //create a window object so that we can access our GUI within the loop
            window = win;
        }
        // make this async so that it wont freez the GUI
        public async void Run()
        {
            //load all the questions into our structure
            window.loadQuestions();
            //load the GUI
            window.Gameload();
            //Game loop
            do
            {
                //Display the question on screen
                window.displayQuestion();
                tcs = new TaskCompletionSource<bool>();
                //wait for something to happen (the selection of an answer)
                await tcs.Task;
                //when the button is clicked check answer
                window.CheckAnswer();
                //window.set_level(window.get_level() + 1);
            } while (window.get_isRunning());
        }
        //continue from waiting
        public void set_task(bool x)
        {
            tcs?.TrySetResult(x);
        }
    }
}
