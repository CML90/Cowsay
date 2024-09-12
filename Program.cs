// See https://aka.ms/new-console-template for more information
using System;
using System.IO;
using System.Diagnostics;
using System.ComponentModel;

    public class InputEventArgs : EventArgs
    {
        public string? UserInput { get; }

        public InputEventArgs(string? input)
        {
            UserInput = input;
        }
    }
    

class CowStart
{
    static void Main() 
    {
        //subscribe to event, with .Say() as event handler
        Cowsay.InputReceived += new EventHandler<InputEventArgs>(Cowsay.Say);
        Cowsay.Greet();
    }

    static public class Cowsay
    {      
        //declare the event
        public static event EventHandler<InputEventArgs>? InputReceived;

        static public void Greet(){
            Console.WriteLine("Tell me what you want to say: ");
            string? response = Console.ReadLine();
            //raise event and pass response
            InputReceived?.Invoke(null, new InputEventArgs(response));
        }

        //event handler     
        static public void Say(object? sender, InputEventArgs e)
        {
            try
            {
                using (Process myProcess = new Process())
                {
                //The process should be created from the executable file
                myProcess.StartInfo.UseShellExecute = false;
                //Enable stdio redirection
                myProcess.StartInfo.RedirectStandardInput = true;

                //set path and start cowsay
                myProcess.StartInfo.FileName = "/usr/games/cowsay";
                myProcess.Start();

                //Implements a TextWriter for writing chars to a stream = stdio
                StreamWriter myStreamWriter = myProcess.StandardInput;
                //Write to the cowsay app
                myStreamWriter.WriteLine(e.UserInput);
                }
            }
            catch (Exception ex)
            {
            Console.WriteLine(ex.Message);
            }
        }
    }
}



