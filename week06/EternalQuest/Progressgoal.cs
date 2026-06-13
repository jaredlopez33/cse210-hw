using System;
public class ProgressGoal : Goal
{
    private int _targetUnits; 
    private int _currentUnits;
    private int _milestoneInterval; 
    private int _milestoneBonus;
    private string _unitLabel;

    public ProgressGoal(string name, string description, int pointsPerUnit, int targetUnits,
                        int milestoneInterval, int milestoneBonus, string unitLabel)
        : base(name, description, pointsPerUnit)
    {
        _targetUnits = targetUnits;
        _currentUnits = 0;
        _milestoneInterval = milestoneInterval;
        _milestoneBonus = milestoneBonus;
        _unitLabel = unitLabel;
    }

    public ProgressGoal(string name, string description, int pointsPerUnit, int targetUnits,
                        int milestoneInterval, int milestoneBonus, string unitLabel, int currentUnits)
        : base(name, description, pointsPerUnit)
    {
        _targetUnits = targetUnits;
        _currentUnits = currentUnits;
        _milestoneInterval = milestoneInterval;
        _milestoneBonus = milestoneBonus;
        _unitLabel = unitLabel;
    }

    public override int RecordEvent()
    {
        if (IsComplete())
        {
            Console.WriteLine("  This goal is already complete!");
            return 0;
        }

        Console.Write($"  How many {_unitLabel} to add? ");
        if (!int.TryParse(Console.ReadLine(), out int added) || added <= 0)
        {
            Console.WriteLine("  Invalid amount.");
            return 0;
        }

        int prevUnits = _currentUnits;
        _currentUnits = Math.Min(_currentUnits + added, _targetUnits);
        int earned = (_currentUnits - prevUnits) * _points;

        // Check for milestone crossings
        int prevMilestone = prevUnits / _milestoneInterval;
        int newMilestone = _currentUnits / _milestoneInterval;
        int milestonesHit = newMilestone - prevMilestone;

        if (milestonesHit > 0)
        {
            earned += milestonesHit * _milestoneBonus;
            Console.WriteLine($"   Milestone reached! +{milestonesHit * _milestoneBonus} bonus pts!");
        }

        if (IsComplete())
            Console.WriteLine("   Progress goal complete!");

        return earned;
    }

    public override bool IsComplete() => _currentUnits >= _targetUnits;

    public override string GetDisplayString()
    {
        string status = IsComplete() ? "[X]" : "[ ]";
        double pct = _targetUnits > 0 ? 100.0 * _currentUnits / _targetUnits : 0;
        return $"{status} {_name} ({_description}) — {_points} pts/{_unitLabel} | {_currentUnits}/{_targetUnits} {_unitLabel} ({pct:F0}%)";
    }

    public override string GetSaveString()
    {
        return $"ProgressGoal:{_name}:{_description}:{_points}:{_targetUnits}:{_milestoneInterval}:{_milestoneBonus}:{_unitLabel}:{_currentUnits}";
    }
}