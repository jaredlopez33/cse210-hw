using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
    private List<Goal> _goals;
    private int _score;
    private int _level;
    private string _playerName;

    private static readonly int[] LevelThresholds = { 0, 500, 1500, 3000, 5000, 8000, 12000, 17000, 23000, 30000 };
    private static readonly string[] LevelTitles =
    {
        "Wandering Novice",
        "Seeker of Light",
        "Faithful Pilgrim",
        "Brave Adventurer",
        "Keeper of Promises",
        "Champion of Good",
        "Guardian of Virtue",
        "Eternal Warrior",
        "Radiant Sage",
        "Legendary Hero"
    };

    public GoalManager(string playerName)
    {
        _playerName = playerName;
        _goals = new List<Goal>();
        _score = 0;
        _level = 1;
    }

    public void DisplayPlayerInfo()
    {
        UpdateLevel();
        int currentLevel = GetCurrentLevel();
        int nextLevelScore = currentLevel < LevelThresholds.Length ? LevelThresholds[currentLevel] : int.MaxValue;
        string levelTitle = LevelTitles[currentLevel - 1];

        Console.WriteLine($"\n  Player : {_playerName}");
        Console.WriteLine($"  Score  : {_score} pts");
        Console.WriteLine($"  Level  : {currentLevel} — {levelTitle}");

        if (currentLevel < LevelTitles.Length)
        {
            int toNext = nextLevelScore - _score;
            Console.WriteLine($"  Next   : {toNext} pts to level {currentLevel + 1} ({LevelTitles[currentLevel]})");
        }
        else
        {
            Console.WriteLine($"  Status : MAX LEVEL ACHIEVED! ");
        }
    }

    private int GetCurrentLevel()
    {
        int level = 1;
        for (int i = 1; i < LevelThresholds.Length; i++)
        {
            if (_score >= LevelThresholds[i])
                level = i + 1;
            else
                break;
        }
        return Math.Min(level, LevelTitles.Length);
    }

    private void UpdateLevel()
    {
        int newLevel = GetCurrentLevel();
        if (newLevel > _level)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"\n   LEVEL UP! You are now Level {newLevel}: {LevelTitles[newLevel - 1]}! ");
            Console.ResetColor();
            _level = newLevel;
        }
    }

    public void ListGoals()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("  No goals yet. Create one!");
            return;
        }

        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"  {i + 1}. {_goals[i].GetDisplayString()}");
        }
    }

    public void AddGoal(Goal goal)
    {
        _goals.Add(goal);
    }

    public void RecordEvent()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("  No goals to record. Create one first.");
            return;
        }

        ListGoals();
        Console.Write("\n  Which goal did you accomplish? (number): ");

        if (!int.TryParse(Console.ReadLine(), out int choice) || choice < 1 || choice > _goals.Count)
        {
            Console.WriteLine("  Invalid selection.");
            return;
        }

        Goal selected = _goals[choice - 1];
        int earned = selected.RecordEvent();

        if (earned > 0)
        {
            _score += earned;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\n   Great job! You earned {earned} pts. Total score: {_score}");
            Console.ResetColor();
            UpdateLevel();
        }
        else if (earned < 0)
        {
            _score = Math.Max(0, _score + earned);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"\n    Recorded bad habit. Lost {-earned} pts. Total score: {_score}");
            Console.ResetColor();
        }
    }

    public void SaveGoals(string filename)
    {
        try
        {
            using (StreamWriter writer = new StreamWriter(filename))
            {
                writer.WriteLine($"Player:{_playerName}");
                writer.WriteLine($"Score:{_score}");
                writer.WriteLine($"Level:{GetCurrentLevel()}");

                foreach (Goal goal in _goals)
                {
                    writer.WriteLine(goal.GetSaveString());
                }
            }

            Console.WriteLine($"  Goals saved to '{filename}'.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"  Error saving: {ex.Message}");
        }
    }

    public void LoadGoals(string filename)
    {
        if (!File.Exists(filename))
        {
            Console.WriteLine($"  File '{filename}' not found.");
            return;
        }

        try
        {
            _goals.Clear();
            string[] lines = File.ReadAllLines(filename);

            foreach (string line in lines)
            {
                if (line.StartsWith("Player:"))
                    _playerName = line.Substring(7);
                else if (line.StartsWith("Score:"))
                    _score = int.Parse(line.Substring(6));
                else if (line.StartsWith("Level:"))
                    _level = int.Parse(line.Substring(6));
                else
                    ParseGoalLine(line);
            }

            Console.WriteLine($"  Loaded {_goals.Count} goals for {_playerName}. Score: {_score}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"  Error loading: {ex.Message}");
        }
    }

    private void ParseGoalLine(string line)
    {
        string[] parts = line.Split(':');
        if (parts.Length < 1) return;

        string type = parts[0];

        try
        {
            switch (type)
            {
                case "SimpleGoal":
                    _goals.Add(new SimpleGoal(parts[1], parts[2], int.Parse(parts[3]), bool.Parse(parts[4])));
                    break;

                case "EternalGoal":
                    _goals.Add(new EternalGoal(parts[1], parts[2], int.Parse(parts[3]), int.Parse(parts[4])));
                    break;

                case "ChecklistGoal":
                    _goals.Add(new ChecklistGoal(parts[1], parts[2], int.Parse(parts[3]),
                        int.Parse(parts[4]), int.Parse(parts[5]), int.Parse(parts[6])));
                    break;

                case "NegativeGoal":
                    _goals.Add(new NegativeGoal(parts[1], parts[2], int.Parse(parts[3]), int.Parse(parts[4])));
                    break;

                case "ProgressGoal":
                    _goals.Add(new ProgressGoal(parts[1], parts[2], int.Parse(parts[3]),
                        int.Parse(parts[4]), int.Parse(parts[5]), int.Parse(parts[6]),
                        parts[7], int.Parse(parts[8])));
                    break;
            }
        }
        catch
        {
            Console.WriteLine($"  Warning: Could not parse line: {line}");
        }
    }
}