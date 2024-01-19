using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
// Like for creativity and excceding requirements   Let give the possibility to the user to add additional entry
// Also save our journal in an csv format and load the journal in an csv format.
class Program
{
    static void Main()
    {
        Journal journal = new Journal();
        Menu(journal);
    }

    static void Menu(Journal journal)
    {
        while (true)
        {
            // The write prompte information 
            
            Console.WriteLine("1. Write an entry");
            Console.WriteLine("2. Display the journal");
            Console.WriteLine("3. Load the journal from a file (CSV)");
            Console.WriteLine("4. Save the journal to a file (CSV)");
            Console.WriteLine("5. Quit");

            Console.Write("What would you like to do ? ");
            
            // Let get the user input or choice
            string choice = Console.ReadLine();

            // Let make a condition with switch case so that
            // base on the user input we will make an action
            switch (choice)
            {
                case "1":
                    WriteNewEntry(journal);
                    break;
                case "2":
                    DisplayJournal(journal);
                    break;
                case "3":
                    LoadJournalFromCSV(journal);
                    break;
                case "4":
                    SaveJournalToCSV(journal);
                    break;
                case "5":
                    Console.WriteLine("Exiting program...");
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please enter a number between 1 to  5.");
                    break;
            }
        }
    }

    static void WriteNewEntry(Journal journal)
    {
        Console.WriteLine("Writing a new entry...");

        // Get a random prompt
        string prompt = GetRandomPrompt();

        Console.WriteLine($"Prompt: {prompt}");

        Console.Write("Enter your response: ");
        string response = Console.ReadLine();

        Console.Write("Enter additional information: ");
        string additionalInfo = Console.ReadLine();

        // Let Get the current date as a string
        string currentDate = DateTime.Now.ToString("yyyy-MM-dd");

        // Create a new entry with additional information
        Entry newEntry = new Entry(currentDate, prompt, response, additionalInfo);

        // Add the entry to the journal
        journal.AddEntry(newEntry);

        Console.WriteLine("Entry added successfully!\n");
    }

    static void DisplayJournal(Journal journal)
    {
        Console.WriteLine("Displaying the journal...\n");

        foreach (Entry entry in journal.Entries)
        {
            entry.Display();
        }

        Console.WriteLine();
    }

    static void SaveJournalToCSV(Journal journal)
    {
        Console.Write("Enter the filename to save the journal (CSV): ");
        string filename = Console.ReadLine();

        try
        {
            using (StreamWriter outputFile = new StreamWriter(filename))
            {
                // Write CSV header
                outputFile.WriteLine("Date,Prompt,Response,AdditionalInfo");

                // Iterate through entries and write them to the CSV file
                foreach (Entry entry in journal.Entries)
                {
                    outputFile.WriteLine($"{entry.Date},{entry.Prompt},{entry.Response},{entry.AdditionalInfo}");
                }
            }

            Console.WriteLine($"Journal saved to {filename} successfully!\n");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error saving the journal: {ex.Message}\n");
        }
    }

    static void LoadJournalFromCSV(Journal journal)
    {
        Console.Write("Enter the filename to load the journal (CSV): ");
        string filename = Console.ReadLine();

        try
        {
            // Clear existing entries before loading new ones
            journal.ClearEntries();

            // Read lines from the CSV file
            string[] lines = File.ReadAllLines(filename);

            // Skip the header line
            for (int i = 1; i < lines.Length; i++)
            {
                // Split each line into parts
                string[] parts = lines[i].Split(',');

                // Create a new entry and add it to the journal
                journal.AddEntry(new Entry(parts[0], parts[1], parts[2], parts[3]));
            }

            Console.WriteLine($"Journal loaded from {filename} successfully!\n");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading the journal: {ex.Message}\n");
        }
    }

    static string GetRandomPrompt()
    {
        // A list of prompts for the journal
        List<string> prompts = new List<string>
        {
            "Who was the most interesting person I interacted with today?",
            "What was the best part of my day?",
            "How did I see the hand of the Lord in my life today?",
            "What was the strongest emotion I felt today?",
            "If I had one thing I could do over today, what would it be?",
            // Add your own prompts here
        };

        // Get a random prompt from the list
        Random random = new Random();
        int index = random.Next(prompts.Count);
        return prompts[index];
    }
}

class Journal
{
    public List<Entry> Entries { get; private set; }

    public Journal()
    {
        Entries = new List<Entry>();
    }

    public void AddEntry(Entry entry)
    {
        Entries.Add(entry);
    }

    public void DisplayEntries()
    {
        foreach (Entry entry in Entries)
        {
            entry.Display();
        }
    }

    public void ClearEntries()
    {
        Entries.Clear();
    }
}

class Entry
{
    public string Date { get; private set; }
    public string Prompt { get; private set; }
    public string Response { get; private set; }
    public string AdditionalInfo { get; private set; }

    public Entry(string date, string prompt, string response, string additionalInfo)
    {
        Date = date;
        Prompt = prompt;
        Response = response;
        AdditionalInfo = additionalInfo;
    }

    public void Display()
    {
        Console.WriteLine($"Date: {Date}\nPrompt: {Prompt}\nResponse: {Response}\nAdditional Info: {AdditionalInfo}\n");
    }
}
