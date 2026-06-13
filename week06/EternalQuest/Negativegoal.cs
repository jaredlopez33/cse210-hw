public class NegativeGoal : Goal
{
    private int _timesRecorded;

    public NegativeGoal(string name, string description, int points)
        : base(name, description, points)
    {
        _timesRecorded = 0;
    }

    public NegativeGoal(string name, string description, int points, int timesRecorded)
        : base(name, description, points)
    {
        _timesRecorded = timesRecorded;
    }

    public override int RecordEvent()
    {
        _timesRecorded++;
        return -_points;
    }

    public override bool IsComplete() => false; 

    public override string GetDisplayString()
    {
        return $"[⚠] {_name} ({_description}) — -{_points} pts each | Occurred {_timesRecorded}x";
    }

    public override string GetSaveString()
    {
        return $"NegativeGoal:{_name}:{_description}:{_points}:{_timesRecorded}";
    }
}