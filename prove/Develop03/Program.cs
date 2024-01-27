// I exceeded the requirements by providing the user with the option to choose and load a different scripture during the program execution from a .txt file.
// Additionally, I implemented the default behavior of loading the scripture from a file named 'scriptures.txt'.
// If you intend to run the code, ensure to properly load the 'scriptures.txt' file to avoid encountering the following error: "Error: No scriptures found in the library. Exiting program."


using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Program
{
    static void Main()
    {
        ScriptureProgram program = new ScriptureProgram();
        program.Start();
    }
}

class ScriptureProgram
{
    private List<Scripture> scriptureLibrary;

    public ScriptureProgram()
    {
        scriptureLibrary = LoadScriptureLibrary();

        if (scriptureLibrary.Any()) // Let Check if the library is not empty
        {
            scripture = GetRandomScripture(); // Let Initialize with a random scripture
        }
        else
        {
            Console.WriteLine("Error: No scriptures found in the library. Exiting program.");
            Environment.Exit(0);
        }
    }

    public void Start()
    {
        do
        {
            Console.Clear();
            Console.WriteLine(scripture.GetVisibleText());
            Console.WriteLine("Press Enter to hide words, type 'quit' to exit, or type 'load' to load a new scripture:");
            string userInput = Console.ReadLine();

            if (userInput.ToLower() == "quit")
                break;
            else if (userInput.ToLower() == "load")
                LoadNewRandomScripture();
            else
            {
                HideRandomWords();
                Console.Clear(); // Clear console after hiding words
            }

        } while (!scripture.AllWordsHidden());
// after hiding all words let write to the user All words hidden. Program ending

        Console.WriteLine("All words hidden. Program ending.");
    }

    private void HideRandomWords()
    {
        scripture.HideRandomWords();
    }

    private List<Scripture> LoadScriptureLibrary()
    {
        List<Scripture> library = new List<Scripture>();
        
        // please load the file scriptures.txt from here by specifying the full path of your scriptures.txt
        string filePath = "C:/Users/troju/RiderProjects/EbenezerOppong4127-cse210-projects/prove/Develop03/bin/Debug/net7.0/scriptures.txt"; // Let  Update the file path as needed

        try
        {
            if (File.Exists(filePath))
            {
                string[] lines = File.ReadAllLines(filePath);
                foreach (string line in lines)
                {
                    string[] parts = line.Split('|');
                    if (parts.Length == 2)
                    {
                        string reference = parts[0].Trim();
                        string text = parts[1].Trim();
                        library.Add(new Scripture(reference, text));
                    }
                }
            }
            else
            {
                Console.WriteLine($"Error: File '{filePath}' not found. Exiting program.");
                Environment.Exit(0);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error loading scriptures: {e.Message}. Exiting program.");
            Environment.Exit(0);
        }

        return library;
    }

    // Let load a scripture from .txt file is user type load
    private void LoadNewRandomScripture()
    {
        if (scriptureLibrary.Any()) // Check if the library is not empty
        {
            scripture = GetRandomScripture(); // Load a new random scripture
            Console.WriteLine("New scripture loaded.");
        }
        else
        {
            Console.WriteLine("Error: No scriptures found in the library.");
        }
    }

    private Scripture GetRandomScripture()
    {
        Random random = new Random();
        return scriptureLibrary[random.Next(scriptureLibrary.Count)];
    }

    private Scripture scripture;
}

class Scripture
{
    private string reference;
    private string text;
    private List<Word> words;
    private Random random;

    public Scripture(string reference, string text)
    {
        this.reference = reference;
        this.text = text;
        InitializeWords();
        random = new Random();
    }

    private void InitializeWords()
    {
        string[] wordArray = text.Split(' ');
        words = wordArray.Select(wordText => new Word(wordText)).ToList();
    }

    public void HideRandomWords()
    {
        int visibleWordCount = words.Count(word => !word.IsHidden);

        if (visibleWordCount > 0)
        {
            int wordsToHideCount = random.Next(2, 4); // Randomly hide between 2 and 3 words
            List<int> visibleIndices = words.Select((word, index) => new { word, index })
                                            .Where(pair => !pair.word.IsHidden)
                                            .Select(pair => pair.index)
                                            .ToList();

            for (int i = 0; i < Math.Min(wordsToHideCount, visibleIndices.Count); i++)
            {
                int randomIndex = random.Next(visibleIndices.Count);
                words[visibleIndices[randomIndex]].Hide();
                visibleIndices.RemoveAt(randomIndex);
            }
        }
    }

    public bool AllWordsHidden()
    {
        return words.All(word => word.IsHidden);
    }

    public string GetVisibleText()
    {
        return $"{reference}: {string.Join(" ", words.Select(word => word.IsHidden ? "___" : word.Text))}";
    }
}

class Word
{
    public string Text { get; private set; }
    public bool IsHidden { get; private set; }

    public Word(string text)
    {
        Text = text;
        IsHidden = false;
    }

    public void Hide()
    {
        IsHidden = true;
    }
}
