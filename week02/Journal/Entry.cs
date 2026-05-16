using System;


public class Entry
{
    private string _date;
    private string _promptText;
    private string _entryText;

    
    public Entry(string promptText, string entryText)
    {
        _date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        _promptText = promptText;
        _entryText = entryText;
    }

    
    public Entry(string date, string promptText, string entryText)
    {
        _date = date;
        _promptText = promptText;
        _entryText = entryText;
    }

   
    public string GetDate()
    {
        return _date;
    }

    
    public string GetPromptText()
    {
        return _promptText;
    }

   
    public string GetEntryText()
    {
        return _entryText;
    }

    
    public void Display()
    {
        Console.WriteLine("\n" + new string('-', 60));
        Console.WriteLine($"Date: {_date}");
        Console.WriteLine($"Prompt: {_promptText}");
        Console.WriteLine($"Entry:\n{_entryText}");
        Console.WriteLine(new string('-', 60));
    }
}
