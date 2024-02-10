using System;
using System.Collections.Generic;

// To improve and extend functionality, I have added the following ideas:
// 1. Implement a feature to edit existing goals.
// 2. Allow users to delete goals from the list.
// 3. Enable users to reset goals points.


public class GoalManager
{
    private List<Goal> goals = new List<Goal>();
    private int totalPoints = 0;
    public GoalManager()
    {
        // Load goals from file or initialize with default goals
    }
    public void CreateGoal()
    {
        Console.WriteLine("The types of Goals are:");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
        Console.Write("Which type of goal would you like to create? ");
        int type;
        if (int.TryParse(Console.ReadLine(), out type))
        {
            Console.Write("What is the name of your goal? ");
            string name = Console.ReadLine();
            Console.Write("What is a short description of it? ");
            string description = Console.ReadLine();
            Console.Write("What is the amount of points associated with this goal? ");
            int points;
            if (int.TryParse(Console.ReadLine(), out points))
            {
                switch (type)
                {
                    case 1:
                        goals.Add(new SimpleGoal(name, description, points));
                        break;
                    case 2:
                        goals.Add(new EternalGoal(name, description, points));
                        break;
                    case 3:
                        Console.Write("How many times does this goal need to be accomplished for bonus? ");
                        int timesToComplete;
                        if (int.TryParse(Console.ReadLine(), out timesToComplete))
                        {
                            Console.Write("What is the bonus for accomplishing it many times? ");
                            int bonusPoints;
                            if (int.TryParse(Console.ReadLine(), out bonusPoints))
                            {
                                goals.Add(new ChecklistGoal(name, description, points, timesToComplete, bonusPoints));
                            }
                            else
                            {
                                Console.WriteLine("Invalid input for bonus points.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid input for times to complete.");
                        }
                        break;
                    default:
                        Console.WriteLine("Invalid goal type.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid input for points.");
            }
        }
        else
        {
            Console.WriteLine("Invalid goal type.");
        }
    }

    public void ListGoals()
    {
        Console.WriteLine("The goals are:");
        for (int i = 0; i < goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {goals[i].DisplayProgress()}");
        }
        Console.WriteLine($"You have {totalPoints} points.");
    }

    public void SaveGoals()
    {
        Console.Write("Enter the filename for the goal file: ");
        string filename = Console.ReadLine();
        FileManager.SaveGoals(goals, totalPoints, filename);
    }

    public void LoadGoals()
    {
        Console.Write("Enter the filename for the goal file: ");
        string filename = Console.ReadLine();
        FileManager.LoadGoals(out goals, out totalPoints, filename);
    }

    public void RecordEvent()
    {
        ListGoals();
        Console.WriteLine("Which goal did you accomplish?");

        int goalNumber;
        if (int.TryParse(Console.ReadLine(), out goalNumber) && goalNumber >= 1 && goalNumber <= goals.Count)
        {
            Goal goal = goals[goalNumber - 1];
            Console.WriteLine($"Congratulations! You have earned {goal.GetPoints()} points!");
            totalPoints += goal.GetPoints();
        }
        else
        {
            Console.WriteLine("Invalid goal number.");
        }
    }
    
    
  
    

    
    // Calculate total points
    public int CalculateTotalPoints()
    {
        // Implement logic to calculate total points
        return totalPoints;
    }

    // Reset total points
    public void ResetTotalPoints()
    {
        Console.WriteLine("Resetting total points...");
        totalPoints = 0;
        Console.WriteLine("Total points reset to 0.");
    }

    
    
    public void EditGoal()
    {
        Console.Write("Enter the index of the goal you want to edit: ");
        if (int.TryParse(Console.ReadLine(), out int editIndex))
        {
            // Let assuming here that we have already created the updated goal
            // This is just a placeholder for demonstration  of the edit
            Goal updatedGoal = new SimpleGoal("Updated Goal", "Updated Description", 50);
            EditGoal(editIndex - 1, updatedGoal);
        }
        else
        {
            Console.WriteLine("Invalid input for goal index.");
        }
    }

    public void EditGoal(int index, Goal updatedGoal)
    {
        if (index >= 0 && index < goals.Count)
        {
            Console.WriteLine($"Editing goal: {goals[index].GetName()}");
            goals[index] = updatedGoal;
            Console.WriteLine("Goal edited successfully.");
        }
        else
        {
            Console.WriteLine("Invalid goal index.");
        }
    }


    public void DeleteGoal()
    {
        Console.WriteLine("Enter the index of the goal to delete: ");
        if (int.TryParse(Console.ReadLine(), out int index))
        {
            if (index >= 0 && index < goals.Count)
            {
                Console.WriteLine($"Deleting goal: {goals[index].GetName()}");
                goals.RemoveAt(index);
                Console.WriteLine("Goal deleted successfully.");
            }
            else
            {
                Console.WriteLine("Invalid goal index.");
            }
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter a valid integer index.");
        }
    }


  



    

   
}
