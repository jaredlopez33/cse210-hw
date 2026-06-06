using System;
using System.Collections.Generic;
using System.IO;
public class GratitudeActivity : Activity
{
    private const int PauseBetweenPrompts = 3;
    private static readonly List<string> _starters = new List<string>
    {
        "I am grateful for...",
        "Something that made me smile today was...",
        "A person I appreciate right now is...",
        "A challenge that helped me grow was...",
        "Something I take for granted but shouldn't is...",
        "A small joy I noticed today was...",
        "I feel thankful for this moment because..."
    };
    private readonly Random _random = new Random();
    private readonly string  _logFile = "gratitude_log.txt";
    public GratitudeActivity()
        : base(
            "Gratitude Activity",
            "This activity will guide you through a short gratitude\n" +
            "  journaling session. Complete each sentence stem honestly\n" +
            "  and notice how your mindset shifts.")
    { }
    public override void Run()
    {
        DisplayStartingMessage();
        List<string> entries = new List<string>();
        Queue<string> starterQueue = BuildShuffledQueue(_starters);
        int elapsed = 0;
        while (elapsed < Duration)
        {
            if (starterQueue.Count == 0)
                starterQueue = BuildShuffledQueue(_starters);
            string stem = starterQueue.Dequeue();
            Console.WriteLine($"\n  {stem}");
            Console.Write("  → ");
            string? entry = Console.ReadLine()?.Trim();
            if (!string.IsNullOrEmpty(entry))
                entries.Add($"{stem} {entry}");
            int pause = Math.Min(PauseBetweenPrompts, Duration - elapsed);
            ShowSpinner(pause);
            elapsed += pause;
        }
        SaveLog(entries);
        Console.WriteLine($"\n  You recorded {entries.Count} gratitude entry(s).");
        Console.WriteLine($"  They have been saved to '{_logFile}'.\n");
        DisplayEndingMessage();
    }

    private void SaveLog(List<string> entries)
    {
        try
        {
            using StreamWriter writer = File.AppendText(_logFile);
            writer.WriteLine($"\n--- {DateTime.Now:yyyy-MM-dd HH:mm:ss} ---");
            foreach (string e in entries)
                writer.WriteLine($"  • {e}");
        }
        catch (Exception)
        {
        }
    }
    private Queue<string> BuildShuffledQueue(List<string> source)
    {
        List<string> copy = new List<string>(source);
        for (int i = copy.Count - 1; i > 0; i--)
        {
            int j = _random.Next(i + 1);
            (copy[i], copy[j]) = (copy[j], copy[i]);
        }
        return new Queue<string>(copy);
    }
}