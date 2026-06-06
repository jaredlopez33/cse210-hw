// Program.cs  —  Mindfulness Program  (W05 Project)
// Author: jared Lopez
// Course: CSE 210
using System;
using System.Collections.Generic;
class Program
{
    private static Dictionary<string, int> _sessionLog = new Dictionary<string, int>
    {
        { "Breathing",   0 },
        { "Reflection",  0 },
        { "Listing",     0 },
        { "Gratitude",   0 }
    };
    static void Main(string[] args)
    {
        bool quit = false;
        while (!quit)
        {
            Console.Clear();
            Console.WriteLine("\n  ┌─────────────────────────────────────┐");
            Console.WriteLine("  │        Mindfulness Program          │");
            Console.WriteLine("  ├─────────────────────────────────────┤");
            Console.WriteLine("  │  1. Breathing Activity              │");
            Console.WriteLine("  │  2. Reflection Activity             │");
            Console.WriteLine("  │  3. Listing Activity                │");
            Console.WriteLine("  │  4. Gratitude Activity              │");
            Console.WriteLine("  │  5. Quit                            │");
            Console.WriteLine("  └─────────────────────────────────────┘");
            Console.Write("\n  Select an option: ");

            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    RunActivity(new BreathingActivity(), "Breathing");
                    break;
                case "2":
                    RunActivity(new ReflectionActivity(), "Reflection");
                    break;
                case "3":
                    RunActivity(new ListingActivity(), "Listing");
                    break;
                case "4":
                    RunActivity(new GratitudeActivity(), "Gratitude");
                    break;
                case "5":
                    quit = true;
                    DisplaySessionSummary();
                    break;
                default:
                    Console.WriteLine("\n  Invalid option. Press Enter to try again.");
                    Console.ReadLine();
                    break;
            }
        }
    }
    private static void RunActivity(Activity activity, string key)
    {
        activity.Run();
        _sessionLog[key]++;

        Console.WriteLine("  Press Enter to return to the menu...");
        Console.ReadLine();
    }
    private static void DisplaySessionSummary()
    {
        Console.Clear();
        Console.WriteLine("\n  ┌─────────────────────────────────────┐");
        Console.WriteLine("  │          Session Summary            │");
        Console.WriteLine("  ├─────────────────────────────────────┤");
        foreach (var kvp in _sessionLog)
        {
            Console.WriteLine($"  │  {kvp.Key,-20} {kvp.Value,4} time(s)     │");
        }
        Console.WriteLine("  ├─────────────────────────────────────┤");
        int total = 0;
        foreach (var v in _sessionLog.Values) total += v;
        Console.WriteLine($"  │  Total activities run: {total,-13} │");
        Console.WriteLine("  └─────────────────────────────────────┘");
        Console.WriteLine("\n  Great work today. See you next time!\n");
    }
}