namespace CowSay;

/// <summary>
/// This class handles initial output, user input, and final output. 
/// </summary>
public static class CowStart
{
    /// <summary>
    /// This method akss the user for input, and sends that input to the Say method. 
    /// It then receives the cowsay's ouptut and sends it back to the caller.
    /// </summary>
    static public string Greet()
    {
        Console.WriteLine("Tell me what you want to say: ");
        string? response = Console.ReadLine();
        string output = Cow.Say(response!);
        return output;
    }
}