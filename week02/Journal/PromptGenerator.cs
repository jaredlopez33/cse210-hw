using System;
using System.Collections.Generic;


public class PromptGenerator
{
    private List<string> _prompts;
    private Random _random;

    
    public PromptGenerator()
    {
        _prompts = new List<string>();
        _random = new Random();
        InitializePrompts();
    }

    
    private void InitializePrompts()
    {
        _prompts.Add("Who was the most interesting person I interacted with today?");
        _prompts.Add("What was the best part of my day?");
        _prompts.Add("How did I see the hand of the Lord in my life today?");
        _prompts.Add("What was the strongest emotion I felt today?");
        _prompts.Add("If I had one thing I could do over today, what would it be?");
        _prompts.Add("What am I grateful for today?");
        _prompts.Add("What did I learn today?");
        _prompts.Add("What challenged me today and how did I overcome it?");
        _prompts.Add("What made me smile today?");
        _prompts.Add("How did I grow today, spiritually or personally?");
    }

    
    public string GetRandomPrompt()
    {
        int index = _random.Next(_prompts.Count);
        return _prompts[index];
    }
}
