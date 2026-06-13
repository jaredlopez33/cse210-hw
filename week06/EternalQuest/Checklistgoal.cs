using System;
public class ChecklistGoal : Goal
{
    private int _target;
    private int _currentCount;
    private int _bonusPoints;

    public ChecklistGoal(string name, string description, int points, int target, int bonusPoints)
        : base(name, description, points)
    {
        _target = target;
        _currentCount = 0;
        _bonusPoints = bonusPoints;
    }

    public ChecklistGoal(string name, string description, int points, int target, int bonusPoints, int currentCount)
        : base(name, description, points)
    {
        _target = target;
        _bonusPoints = bonusPoints;
        _currentCount = currentCount;
    }

    public override int RecordEvent()
    {
        if (IsComplete())
        {
            Console.WriteLine("  This checklist goal is already complete!");
            return 0;
        }

        _currentCount++;
        int earned = _points;

        if (_currentCount >= _target)
        {
            earned += _bonusPoints;
            Console.WriteLine($"   BONUS! You completed the checklist goal and earned an extra {_bonusPoints} pts!");
        }

        return earned;
    }

    public override bool IsComplete() => _currentCount >= _target;

    public override string GetDisplayString()
    {
        string status = IsComplete() ? "[X]" : "[ ]";
        return $"{status} {_name} ({_description}) — {_points} pts each | Bonus: {_bonusPoints} pts | Progress: {_currentCount}/{_target}";
    }

    public override string GetSaveString()
    {
        return $"ChecklistGoal:{_name}:{_description}:{_points}:{_target}:{_bonusPoints}:{_currentCount}";
    }
}