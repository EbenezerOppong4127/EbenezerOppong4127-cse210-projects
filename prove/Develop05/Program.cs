using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        GoalManager goalManager = new GoalManager();
        int choice;

        do
        {
            Console.WriteLine("Menu Options:");
            Console.WriteLine("1. Create new Goal");
            Console.WriteLine("2. Edit Goal");
            Console.WriteLine("3. Delete Goal");
            Console.WriteLine("4. List Goals");
            Console.WriteLine("5. Record Event");
            Console.WriteLine("6. Reset Total Points");
            Console.WriteLine("7. Load Goals");
            Console.WriteLine("8. Save Goals");
            Console.WriteLine("9. Quit");
            Console.Write("Select a choice from the menu: ");

            if (int.TryParse(Console.ReadLine(), out choice))
            {
                switch (choice)
                {
                    case 1:
                        goalManager.CreateGoal();
                        break;
                    case 2:
                        goalManager.EditGoal();
                        break;
                    case 3:
                        goalManager.DeleteGoal();
                        break;
                    case 4:
                        goalManager.ListGoals();
                        break;
                    case 5:
                        goalManager.RecordEvent();
                        break;
                    case 6:
                        goalManager.ResetTotalPoints();
                        break;
                    case 7:
                        goalManager.LoadGoals();
                        break;
                    
                    case 8:
                        goalManager.SaveGoals();
                        break;
                    case 9:
                        Console.WriteLine("Exiting program...");
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid choice. Please enter a number.");
            }
        } while (choice != 9);
    }
}
