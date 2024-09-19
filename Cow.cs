
using System.Diagnostics;
namespace CowSay;

/// <summary>
/// This class handles the user input, cowsay program, output, and any errors.
/// </summary>
static public class Cow
{
    /// <summary>
    /// This method starts the cowsay process, sends the user input to the cowsay program, and reads the cowsay program's output.
    /// </summary>
    /// <param name="input">User's input</param>
    /// <returns>cowsay output</returns>
    static public string Say(string input)
    {
        try
        {
            using (Process myProcess = new Process())
            {

                myProcess.StartInfo.UseShellExecute = false;
                myProcess.StartInfo.RedirectStandardInput = true;
                myProcess.StartInfo.RedirectStandardOutput = true;
                myProcess.StartInfo.RedirectStandardError = true;

                myProcess.StartInfo.FileName = "/usr/games/cowsay";
                myProcess.Start();


                using (StreamWriter myStreamWriter = myProcess.StandardInput)
                {
                    myStreamWriter.WriteLine(input);
                }

                myProcess.BeginErrorReadLine();
                string output = myProcess.StandardOutput.ReadToEnd();
                return output;

            }
        }
        catch (Exception ex)
        {
            return ex.Message;
        }
    }
}