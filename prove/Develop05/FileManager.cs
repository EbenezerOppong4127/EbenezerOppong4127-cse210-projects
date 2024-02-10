using System;
using System.Collections.Generic;
using System.IO;

public static class FileManager
{
    public static void SaveGoals(List<Goal> goals, int totalPoints, string filename)
    {
        try
        {
            using (StreamWriter sw = new StreamWriter(filename))
            {
                // Let write total points as the first line
                sw.WriteLine(totalPoints);
                // Let write each goal
                foreach (Goal goal in goals)
                {
                    sw.WriteLine(goal.SaveString());
                }
            }
            Console.WriteLine("Goals saved.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error saving goals: {ex.Message}");
        }
    }

    public static void LoadGoals(out List<Goal> goals, out int totalPoints, string filename)
    {
        goals = new List<Goal>();
        totalPoints = 0;

        try
        {
            using (StreamReader sr = new StreamReader(filename))
            {
                // Read total points from the first line
                if (int.TryParse(sr.ReadLine(), out totalPoints))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] parts = line.Split(':');
                        if (parts.Length == 2)
                        {
                            string[] data = parts[1].Split(',');
                            if (data.Length >= 3)
                            {
                                string type = parts[0];
                                string name = data[0].Trim();
                                string description = data[1].Trim();
                                int points;
                                if (int.TryParse(data[2].Trim(), out points))
                                {
                                    if (type.Equals("SimpleGoal"))
                                    {
                                        goals.Add(new SimpleGoal(name, description, points));
                                    }
                                    else if (type.Equals("EternalGoal"))
                                    {
                                        goals.Add(new EternalGoal(name, description, points));
                                    }
                                    else if (type.Equals("ChecklistGoal"))
                                    {
                                        int timesToComplete, bonusPoints, completedTimes;
                                        if (data.Length >= 6 && int.TryParse(data[3].Trim(), out timesToComplete) && int.TryParse(data[4].Trim(), out bonusPoints) && int.TryParse(data[5].Trim(), out completedTimes))
                                        {
                                            ChecklistGoal checklistGoal = new ChecklistGoal(name, description, points, timesToComplete, bonusPoints);
                                            for (int i = 0; i < completedTimes; i++)
                                            {
                                                checklistGoal.Complete();
                                            }
                                            goals.Add(checklistGoal);
                                        }
                                        else
                                        {
                                            Console.WriteLine($"Invalid data format for ChecklistGoal: {line}");
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine($"Unknown goal type: {type}");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine($"Invalid points format: {data[2]}");
                                }
                            }
                            else
                            {
                                Console.WriteLine($"Invalid data format: {line}");
                            }
                        }
                        else
                        {
                            Console.WriteLine($"Invalid line format: {line}");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Invalid total points format.");
                }
            }
            Console.WriteLine("Goals loaded.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading goals: {ex.Message}");
        }
    }
}
