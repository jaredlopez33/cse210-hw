using System;
public class SimpleGoal : Goal
{
    private bool _isComplete;

    public SimpleGoal(string name, string description, int points)
        : base(name, description, points)
    {
        _isComplete = false;
    }

    public SimpleGoal(string name, string description, int points, bool isComplete)
        : base(name, description, points)
    {
        _isComplete = isComplete;
    }
    public override int RecordEvent()
    {
        if (_isComplete)
        {
            Console.WriteLine("  This goal is already complete!");
            return 0;
        }
        _isComplete = true;
        return _points;
    }
    public override bool IsComplete() => _isComplete;

    public override string GetDisplayString()
    {
        string status = _isComplete ? "[X]" : "[ ]";
        return $"{status} {_name} ({_description}) — {_points} pts";
    }
    public override string GetSaveString()
    {
        return $"SimpleGoal:{_name}:{_description}:{_points}:{_isComplete}";
    }
}