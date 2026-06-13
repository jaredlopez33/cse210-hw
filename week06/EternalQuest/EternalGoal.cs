public class EternalGoal : Goal
{
    private int _timesRecorded;

    public EternalGoal(string name, string description, int points)
        : base(name, description, points)
    {
        _timesRecorded = 0;
    }

    public EternalGoal(string name, string description, int points, int timesRecorded)
        : base(name, description, points)
    {
        _timesRecorded = timesRecorded;
    }

    public override int RecordEvent()
    {
        _timesRecorded++;
        return _points;
    }

    public override bool IsComplete() => false; 

    public override string GetDisplayString()
    {
        return $"[∞] {_name} ({_description}) — {_points} pts each | Recorded {_timesRecorded}x";
    }

    public override string GetSaveString()
    {
        return $"EternalGoal:{_name}:{_description}:{_points}:{_timesRecorded}";
    }
}