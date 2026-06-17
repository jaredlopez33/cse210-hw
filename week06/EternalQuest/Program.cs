using System;
class Program
{
    static GoalManager _manager = new GoalManager("Player");
    static string _saveFile = "goals.txt";
    static void Main(string[] args)
    {
        TryClearScreen();
        ShowBanner();
        Console.Write("  Enter your name: ");
        string name = Console.ReadLine()?.Trim();
        if (string.IsNullOrWhiteSpace(name)) name = "Adventurer";
        _manager = new GoalManager(name);
        Console.Write("  Load saved goals? (y/n): ");
        if (Console.ReadLine()?.Trim().ToLower() == "y")
        {
            Console.Write("  Filename (press Enter for 'goals.txt'): ");
            string f = Console.ReadLine()?.Trim();
            if (!string.IsNullOrWhiteSpace(f)) _saveFile = f;
            _manager.LoadGoals(_saveFile);
        }
        bool running = true;
        while (running)
        {
            ShowMenu();
            Console.Write("  Choose an option: ");
            string choice = Console.ReadLine()?.Trim();
            if (choice == null)
            {
                Console.WriteLine("\n  No more input detected. Exiting Eternal Quest.");
                break;
            }
            Console.WriteLine();

            switch (choice)
            {
                case "1": _manager.DisplayPlayerInfo(); break;
                case "2": _manager.ListGoals(); break;
                case "3": CreateGoal(); break;
                case "4": _manager.RecordEvent(); break;
                case "5": SaveGoals(); break;
                case "6": LoadGoals(); break;
                case "7":
                    Console.WriteLine("  May your quest be eternal. Farewell! ");
                    running = false;
                    break;
                default:
                    Console.WriteLine("  Invalid option. Please choose 1–7.");
                    break;
            }
            if (running)
            {
                Console.WriteLine();
                Console.Write("  Press Enter to continue...");
                if (Console.ReadLine() == null)
                {
                    Console.WriteLine("\n  No more input detected. Exiting Eternal Quest.");
                    break;
                }
                TryClearScreen();
                ShowBanner();
            }
        }
    }
    static void TryClearScreen()
    {
        try
        {
            Console.Clear();
        }
        catch (System.IO.IOException)
        {
        }
    }
    static void ShowBanner()
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("  ╔══════════════════════════════════════╗");
        Console.WriteLine("  ║          ETERNAL QUEST               ║");
        Console.WriteLine("  ║    Your Journey to Become Better     ║");
        Console.WriteLine("  ╚══════════════════════════════════════╝");
        Console.ResetColor();
        Console.WriteLine();
    }
    static void ShowMenu()
    {
        Console.WriteLine("  ──────────────────────────────────────");
        Console.WriteLine("  MAIN MENU");
        Console.WriteLine("  ──────────────────────────────────────");
        Console.WriteLine("  1. View Score & Level");
        Console.WriteLine("  2. List Goals");
        Console.WriteLine("  3. Create New Goal");
        Console.WriteLine("  4. Record Goal Event");
        Console.WriteLine("  5. Save Goals");
        Console.WriteLine("  6. Load Goals");
        Console.WriteLine("  7. Quit");
        Console.WriteLine("  ──────────────────────────────────────");
    }
    static void CreateGoal()
    {
        Console.WriteLine("  Goal Types:");
        Console.WriteLine("  1. Simple Goal      — complete once for points");
        Console.WriteLine("  2. Eternal Goal     — earns points every time, never ends");
        Console.WriteLine("  3. Checklist Goal   — complete N times, earn bonus at end");
        Console.WriteLine("  4. Negative Goal    — bad habit tracker (loses points)");
        Console.WriteLine("  5. Progress Goal    — track incremental units toward a target");
        Console.Write("\n  Choose goal type (1–5): ");
        string typeChoice = Console.ReadLine()?.Trim();

        Console.Write("  Goal name: ");
        string name = Console.ReadLine()?.Trim() ?? "Unnamed";

        Console.Write("  Short description: ");
        string desc = Console.ReadLine()?.Trim() ?? "";

        Console.Write("  Points value: ");
        if (!int.TryParse(Console.ReadLine(), out int pts) || pts < 0)
        {
            Console.WriteLine("  Invalid points value.");
            return;
        }

        switch (typeChoice)
        {
            case "1":
                _manager.AddGoal(new SimpleGoal(name, desc, pts));
                Console.WriteLine($"   Simple goal '{name}' created!");
                break;

            case "2":
                _manager.AddGoal(new EternalGoal(name, desc, pts));
                Console.WriteLine($"   Eternal goal '{name}' created!");
                break;

            case "3":
                Console.Write("  How many times must it be completed? ");
                if (!int.TryParse(Console.ReadLine(), out int target) || target < 1)
                {
                    Console.WriteLine("  Invalid target count.");
                    return;
                }
                Console.Write("  Bonus points for finishing: ");
                if (!int.TryParse(Console.ReadLine(), out int bonus) || bonus < 0)
                {
                    Console.WriteLine("  Invalid bonus.");
                    return;
                }
                _manager.AddGoal(new ChecklistGoal(name, desc, pts, target, bonus));
                Console.WriteLine($"   Checklist goal '{name}' created (complete {target}x, +{bonus} bonus)!");
                break;

            case "4":
                _manager.AddGoal(new NegativeGoal(name, desc, pts));
                Console.WriteLine($"     Negative goal '{name}' created (will deduct {pts} pts each time).");
                break;

            case "5":
                Console.Write("  Target units (e.g. miles, pages, sessions): ");
                if (!int.TryParse(Console.ReadLine(), out int targetUnits) || targetUnits < 1)
                {
                    Console.WriteLine("  Invalid target.");
                    return;
                }
                Console.Write("  Unit label (e.g. miles, pages): ");
                string unitLabel = Console.ReadLine()?.Trim() ?? "units";
                Console.Write("  Milestone interval (bonus every N units): ");
                if (!int.TryParse(Console.ReadLine(), out int mInterval) || mInterval < 1)
                    mInterval = targetUnits;
                Console.Write("  Bonus points per milestone: ");
                if (!int.TryParse(Console.ReadLine(), out int mBonus) || mBonus < 0)
                    mBonus = 0;
                _manager.AddGoal(new ProgressGoal(name, desc, pts, targetUnits, mInterval, mBonus, unitLabel));
                Console.WriteLine($"   Progress goal '{name}' created (target: {targetUnits} {unitLabel})!");
                break;

            default:
                Console.WriteLine("  Invalid goal type.");
                break;
        }
    }
    static void SaveGoals()
    {
        Console.Write($"  Filename (Enter for '{_saveFile}'): ");
        string f = Console.ReadLine()?.Trim();
        if (!string.IsNullOrWhiteSpace(f)) _saveFile = f;
        _manager.SaveGoals(_saveFile);
    }
    static void LoadGoals()
    {
        Console.Write($"  Filename (Enter for '{_saveFile}'): ");
        string f = Console.ReadLine()?.Trim();
        if (!string.IsNullOrWhiteSpace(f)) _saveFile = f;
        _manager.LoadGoals(_saveFile);
    }
}