using System;
using System.Collections.Generic;
public class ReflectionActivity : Activity
{
    private const int QuestionPause = 5;
    private static readonly List<string> _prompts = new List<string>
    {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless.",
        "Think of a time when you overcame a significant challenge.",
        "Think of a time when you showed great patience."
    };
    private static readonly List<string> _questions = new List<string>
    {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times when you were not as successful?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience that applies to other situations?",
        "What did you learn about yourself through this experience?",
        "How can you keep this experience in mind in the future?",
        "Who else was impacted by what you did?",
        "What strengths did you discover in yourself?"
    };
    private readonly Random _random = new Random();
    public ReflectionActivity()
        : base(
            "Reflection Activity",
            "This activity will help you reflect on times in your life when\n" +
            "  you have shown strength and resilience. This will help you\n" +
            "  recognize the power you have and how you can use it in\n" +
            "  other aspects of your life.")
    { }
    public override void Run()
    {
        DisplayStartingMessage();
        string prompt = _prompts[_random.Next(_prompts.Count)];
        Console.WriteLine($"\n  {prompt}\n");
        Console.WriteLine("  When you have a moment in mind, press Enter to continue...");
        Console.ReadLine();
        Queue<string> questionQueue = BuildShuffledQueue(_questions);
        int elapsed = 0;
        while (elapsed < Duration)
        {
            if (questionQueue.Count == 0)
                questionQueue = BuildShuffledQueue(_questions);

            string question = questionQueue.Dequeue();
            Console.WriteLine($"\n  > {question}");
            int pause = Math.Min(QuestionPause, Duration - elapsed);
            ShowSpinner(pause);
            elapsed += pause;
        }
        DisplayEndingMessage();
    }
    private Queue<string> BuildShuffledQueue(List<string> source)
    {
        List<string> copy = new List<string>(source);
        for (int i = copy.Count - 1; i > 0; i--)
        {
            int j = _random.Next(i + 1);
            (copy[i], copy[j]) = (copy[j], copy[i]);
        }
        return new Queue<string>(copy);
    }
}