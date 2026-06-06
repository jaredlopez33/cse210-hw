using System;
public class BreathingActivity : Activity
{
    private const int CycleDuration = 4;
    public BreathingActivity()
        : base(
            "Breathing Activity",
            "This activity will help you relax by walking you through\n" +
            "  breathing in and out slowly. Clear your mind and\n" +
            "  focus on your breathing.")
    { }
    public override void Run()
    {
        DisplayStartingMessage();
        int elapsed = 0;
        bool breathingIn = true;

        while (elapsed < Duration)
        {
            int remaining = Duration - elapsed;
            int thisCycle = Math.Min(CycleDuration, remaining);

            if (breathingIn)
            {
                Console.WriteLine("\n  Breathe in...");
            }
            else
            {
                Console.WriteLine("\n  Breathe out...");
            }
            ShowBreathAnimation(thisCycle, breathingIn);
            elapsed      += thisCycle;
            breathingIn   = !breathingIn;
        }
        DisplayEndingMessage();
    }
}