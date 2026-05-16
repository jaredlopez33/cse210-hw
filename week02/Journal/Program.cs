using System;
class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();
        PromptGenerator promptGenerator = new PromptGenerator();
        bool running = true;
        Console.WriteLine("     Welcome to the Journal Program");
        while (running)
        {
            DisplayMenu();
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    WriteNewEntry(journal, promptGenerator);
                    break;
                case "2":
                    journal.DisplayAll();
                    break;
                case "3":
                    SaveJournal(journal);
                    break;
                case "4":
                    LoadJournal(journal);
                    break;
                case "5":
                    running = false;
                    Console.WriteLine("\nThank you for using the Journal Program. Goodbye!");
                    break;
                default:
                    Console.WriteLine("\nInvalid choice. Please try again.");
                    break;
            }
        }
    }
    static void DisplayMenu()
    {
        Console.WriteLine("\n========== MENU ==========");
        Console.WriteLine("1. Write a new entry");
        Console.WriteLine("2. Display the journal");
        Console.WriteLine("3. Save the journal to a file");
        Console.WriteLine("4. Load the journal from a file");
        Console.WriteLine("5. Exit");
        Console.Write("Choose an option (1-5): ");
    }
    static void WriteNewEntry(Journal journal, PromptGenerator promptGenerator)
    {
        string prompt = promptGenerator.GetRandomPrompt();
        
        Console.WriteLine("\n" + new string('-', 60));
        Console.WriteLine("WRITE A NEW ENTRY");
        Console.WriteLine(new string('-', 60));
        Console.WriteLine($"Prompt: {prompt}");
        Console.WriteLine("\nYour response (press Enter twice when done):");
        
        string response = "";
        string line;
        
        while ((line = Console.ReadLine()) != null)
        {
            if (line == "")
            {
                if (response.EndsWith("\n"))
                {
                    response = response.TrimEnd('\n');
                    break;
                }
                response += "\n";
            }
            else
            {
                response += line + "\n";
            }
        }
        if (!string.IsNullOrWhiteSpace(response))
        {
            Entry newEntry = new Entry(prompt, response.Trim());
            journal.AddEntry(newEntry);
            Console.WriteLine($"\nEntry saved! (Total entries: {journal.GetEntryCount()})");
        }
        else
        {
            Console.WriteLine("\nNo response entered. Entry not saved.");
        }
    }
    static void SaveJournal(Journal journal)
    {
        Console.Write("\nEnter filename to save to (e.g., myjournal.txt): ");
        string filename = Console.ReadLine();

        if (!string.IsNullOrWhiteSpace(filename))
        {
            journal.SaveToFile(filename);
        }
        else
        {
            Console.WriteLine("Invalid filename.");
        }
    }
    static void LoadJournal(Journal journal)
    {
        Console.Write("\nEnter filename to load from (e.g., myjournal.txt): ");
        string filename = Console.ReadLine();

        if (!string.IsNullOrWhiteSpace(filename))
        {
            journal.LoadFromFile(filename);
        }
        else
        {
            Console.WriteLine("Invalid filename.");
        }
    }
}