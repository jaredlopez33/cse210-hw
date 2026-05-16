using System;
using System.Collections.Generic;
using System.IO;


public class Journal
{
    private List<Entry> _entries;
    private const string SEPARATOR = "~|~";

        public Journal()
    {
        _entries = new List<Entry>();
    }

    
    public void AddEntry(Entry newEntry)
    {
        _entries.Add(newEntry);
    }

    
    public void DisplayAll()
    {
        if (_entries.Count == 0)
        {
            Console.WriteLine("\nNo entries found in the journal.");
            return;
        }

        Console.WriteLine($"\n\n========== JOURNAL ({_entries.Count} entries) ==========");
        foreach (Entry entry in _entries)
        {
            entry.Display();
        }
        Console.WriteLine("==========================================\n");
    }

    
    public void SaveToFile(string filename)
    {
        try
        {
            using (StreamWriter writer = new StreamWriter(filename))
            {
                foreach (Entry entry in _entries)
                {
                    string line = $"{entry.GetDate()}{SEPARATOR}{entry.GetPromptText()}{SEPARATOR}{entry.GetEntryText()}";
                    writer.WriteLine(line);
                }
            }
            Console.WriteLine($"\nJournal saved successfully to '{filename}'");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"\nError saving file: {ex.Message}");
        }
    }

    
    public void LoadFromFile(string filename)
    {
        try
        {
            if (!File.Exists(filename))
            {
                Console.WriteLine($"\nFile '{filename}' not found.");
                return;
            }

            _entries.Clear();

            using (StreamReader reader = new StreamReader(filename))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] parts = line.Split(new string[] { SEPARATOR }, StringSplitOptions.None);
                    
                    if (parts.Length == 3)
                    {
                        Entry entry = new Entry(parts[0], parts[1], parts[2]);
                        _entries.Add(entry);
                    }
                }
            }

            Console.WriteLine($"\nJournal loaded successfully from '{filename}' ({_entries.Count} entries)");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"\nError loading file: {ex.Message}");
        }
    }

    
    public int GetEntryCount()
    {
        return _entries.Count;
    }
}
