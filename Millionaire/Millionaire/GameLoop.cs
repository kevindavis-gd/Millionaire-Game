// Name: Kevin Davis ,Joseph Williamson, Semeion Stafford
// Class : CMPS4143
// Assignment: Program 4
// Date: 09/28/2020
// Description :Replicate the "Who Wants to be a Millionaire Game
//through the use of multiple c# classes, public and private, and multiple gui demonstrations.
using System.Threading.Tasks;

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
        }//constructor

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
            } while (window.get_isRunning());
        }//Run

        //continue from waiting
        public void set_task(bool x)
        {
            tcs?.TrySetResult(x);
        }//set_task
    }//GameLoop
}//Millionaire
