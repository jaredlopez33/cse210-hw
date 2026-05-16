using System;

/// <summary>
/// Represents a single journal entry with a date, prompt, and user response.
/// </summary>
public class Entry
{
    private string _date;
    private string _promptText;
    private string _entryText;

    /// <summary>
    /// Constructor for creating a new journal entry.
    /// </summary>
    public Entry(string promptText, string entryText)
    {
        _date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        _promptText = promptText;
        _entryText = entryText;
    }

    /// <summary>
    /// Constructor for loading an entry from file.
    /// </summary>
    public Entry(string date, string promptText, string entryText)
    {
        _date = date;
        _promptText = promptText;
        _entryText = entryText;
    }

    /// <summary>
    /// Gets the date of the entry.
    /// </summary>
    public string GetDate()
    {
        return _date;
    }

    /// <summary>
    /// Gets the prompt text.
    /// </summary>
    public string GetPromptText()
    {
        return _promptText;
    }

    /// <summary>
    /// Gets the entry text (user's response).
    /// </summary>
    public string GetEntryText()
    {
        return _entryText;
    }

    /// <summary>
    /// Displays the entry to the console.
    /// </summary>
    public void Display()
    {
        Console.WriteLine("\n" + new string('-', 60));
        Console.WriteLine($"Date: {_date}");
        Console.WriteLine($"Prompt: {_promptText}");
        Console.WriteLine($"Entry:\n{_entryText}");
        Console.WriteLine(new string('-', 60));
    }
}
