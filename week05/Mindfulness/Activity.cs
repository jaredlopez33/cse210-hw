using System.Threading;
public abstract class Activity
{
    private string _name;
    private string _description;
    private int    _duration;     
    protected Activity(string name, string description)
    {
        _name        = name;
        _description = description;
    }
    protected int    Duration    => _duration;
    protected string Name        => _name;
    protected string Description => _description;
    public void DisplayStartingMessage()
    {
        Console.Clear();
        Console.WriteLine($"\n  ╔══════════════════════════════════╗");
        Console.WriteLine($"  ║  Welcome to the {_name,-16} ║");
        Console.WriteLine($"  ╚══════════════════════════════════╝\n");
        Console.WriteLine($"  {_description}\n");

        Console.Write("  How many seconds would you like? ");
        while (!int.TryParse(Console.ReadLine(), out _duration) || _duration <= 0)
        {
            Console.Write("  Please enter a positive number: ");
        }
        Console.WriteLine("\n  Get ready to begin...");
        ShowSpinner(3);
    }
    public void DisplayEndingMessage()
    {
        Console.WriteLine("\n\n  Good work!");
        ShowSpinner(2);
        Console.WriteLine($"\n  You have completed the {_name}.");
        Console.WriteLine($"  Duration: {_duration} seconds.\n");
        ShowSpinner(3);
    }
    protected static void ShowSpinner(int seconds)
    {
        string[] frames = { "|", "/", "-", "\\" };
        int ticks = seconds * 10;         
        for (int i = 0; i < ticks; i++)
        {
            Console.Write($"\r  {frames[i % frames.Length]} ");
            Thread.Sleep(100);
        }
        Console.Write("\r     \r");      
    }
    protected static void ShowCountdown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write($"\r  {i}  ");
            Thread.Sleep(1000);
        }
        Console.Write("\r     \r");
    }
    protected static void ShowBreathAnimation(int seconds, bool breathingIn)
    {
        string label = breathingIn ? "▶" : "◀";
        int steps     = seconds;
        int half      = Math.Max(1, steps / 2);
        for (int i = 1; i <= steps; i++)
        {
            int size    = breathingIn
                            ? (int)(8.0 * i / steps)       
                            : (int)(8.0 * (steps - i + 1) / steps); 
            string bar  = new string('|', Math.Max(1, size));
            Console.Write($"\r  {label}  {bar,-10}  {steps - i + 1}s ");
            Thread.Sleep(1000);
        }
        Console.Write("\r" + new string(' ', 30) + "\r");
    }
    public abstract void Run();
}