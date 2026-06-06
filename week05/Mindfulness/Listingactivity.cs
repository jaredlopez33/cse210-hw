using System;
using System.Collections.Generic;
public class ListingActivity : Activity
{
    private const int ThinkTime = 5;
    private static readonly List<string> _prompts = new List<string>
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "Who are some of your personal heroes?",
        "What are things in your life you are grateful for?",
        "What positive experiences have you had this month?",
        "What skills have you developed over the past year?"
    };
    private readonly Random _random = new Random();
    public ListingActivity()
        : base(
            "Listing Activity",
            "This activity will help you reflect on the good things in\n" +
            "  your life by having you list as many things as you can\n" +
            "  in a certain area.")
    { }
    public override void Run()
    {
        DisplayStartingMessage();
        string prompt = _prompts[_random.Next(_prompts.Count)];
        Console.WriteLine($"\n  {prompt}\n");
        Console.WriteLine($"  You have {ThinkTime} seconds to think before you begin...");
        ShowCountdown(ThinkTime);
        Console.WriteLine("  Start listing items (press Enter after each one):\n");
        int itemCount  = 0;
        DateTime start = DateTime.Now;
        while ((DateTime.Now - start).TotalSeconds < Duration)
        {
            double remaining = Duration - (DateTime.Now - start).TotalSeconds;
            Console.Write($"\r  ({(int)remaining}s left) > ");
            string? entry = Console.ReadLine();
            if (entry != null && entry.Trim().Length > 0)
                itemCount++;
        }
        Console.WriteLine($"\n\n  Time's up! You listed {itemCount} item{(itemCount == 1 ? "" : "s")}.");
        DisplayEndingMessage();
    }
}