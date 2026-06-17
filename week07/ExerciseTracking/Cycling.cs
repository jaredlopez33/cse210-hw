public class Cycling : Activity
{
    private double _speed; 

    public Cycling(DateTime date, int minutes, double speed)
        : base(date, minutes)
    {
        _speed = speed;
    }

    public override double GetDistance() => (_speed / 60) * Minutes;

    public override double GetSpeed() => _speed;

    public override double GetPace() => 60 / _speed;
}