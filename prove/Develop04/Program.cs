using System;
using System.Collections.Generic;
using System.Threading;

class Program
{
    static void Main(string[] args)
    {
        int choice;

        do
        {
            DisplayMenu();
            Console.Write("Select a choice from the menu: ");

            // Ensure the user enters a valid integer choice
            while (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > 4)
            {
                Console.WriteLine("Invalid choice. Please enter a number between 1 and 4.");
                Console.Write("Select a choice from the menu: ");
            }

            switch (choice)
            {
                case 1:
                    StartActivity(new BreathingAnimationActivity());
                    break;
                case 2:
                    StartActivity(new ReflectionActivity());
                    break;
                case 3:
                    StartActivity(new ListingActivity());
                    break;
                case 4:
                    Console.WriteLine("Goodbye!");
                    break;
            }

        } while (choice != 4);
    }

    static void DisplayMenu()
    {
        Console.WriteLine("Menu Options:");
        Console.WriteLine("1. Start Breathing activity");
        Console.WriteLine("2. Start reflecting activity");
        Console.WriteLine("3. Start listing activity");
        Console.WriteLine("4. Quit");
    }

    static void StartActivity(Activity activity)
    {
        // string message = "";
        // Console.WriteLine(message);
        
        int durationInSeconds;
        Console.Write("How long, in seconds, would you like for your session? ");

        // Ensure the user enters a valid integer duration
        while (!int.TryParse(Console.ReadLine(), out durationInSeconds) || durationInSeconds <= 0)
        {
            Console.WriteLine("Invalid duration. Please enter a positive number for the session duration.");
            Console.Write("How long, in seconds, would you like for your session? ");
        }

        activity.StartActivity(durationInSeconds);
    }

    abstract class Activity
    {
        protected void DisplayStartMessage(int durationInSeconds)
        {
            Console.WriteLine($"Get ready....");
        }

        protected void DisplayCompletionMessage(int durationInSeconds)
        {
            Console.WriteLine("Well Done!!");
            Console.WriteLine($"You have completed another {durationInSeconds} seconds of the Activity.");
            System.Threading.Thread.Sleep(3000);
        }

        public abstract void StartActivity(int durationInSeconds);

        protected static void CountdownAnimation(int seconds)
        {
            for (int i = seconds; i > 0; i--)
            {
                Console.Write($"{i} ");
                Thread.Sleep(1000);
                Console.SetCursorPosition(Console.CursorLeft - 2, Console.CursorTop);
            }

            Console.WriteLine();
        }
    }
    
    class BreathingAnimationActivity : BreathingActivity
{
    private readonly List<string> animationStrings = new List<string> { "|", "/", "-", "\\" };

    private void PlayAnimation(int seconds)
    {
        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(seconds);

        int i = 0;

        while (DateTime.Now < endTime)
        {
            string s = animationStrings[i];
            Console.Write(s);
            Thread.Sleep(1000);
            Console.Write("\b \b");

            i++;

            if (i >= animationStrings.Count)
            {
                i = 0;
            }
        }
    }

    private void RepeatBreathCycle(int duration, int breathCycles)
    {
        for (int cycle = 0; cycle < breathCycles; cycle++)
        {
            Console.Write("Breath in.... ");
            CountdownAnimation(5);

            Console.WriteLine();

            // Simulate pausing after displaying "Breath in...."
            Console.Write("Now breathe out...");
            CountdownAnimation(5);

            // Simulate pausing after displaying "Now breathe out..."
            Console.WriteLine();
            Console.WriteLine();
         

            Thread.Sleep(1000); // Adjust the pause duration
        }
    }

    public override void StartActivity(int durationInSeconds)
    {
        DisplayStartMessage(durationInSeconds);

        int remainingDuration = durationInSeconds;

        while (remainingDuration > 0)
        {
            PlayAnimation(10); // Play the custom animation

            RepeatBreathCycle(Math.Min(remainingDuration, 10), 3);

            remainingDuration -= 10;

            if (remainingDuration > 0)
            {
                Console.WriteLine("Get ready for the next cycle...");
                Thread.Sleep(2000); // Adjust the pause duration before the next cycle
            }
        }

        DisplayCompletionMessage(durationInSeconds);
    }

    static void CountdownAnimation(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write($"{i} ");
            Thread.Sleep(1000);
            Console.SetCursorPosition(Console.CursorLeft - 2, Console.CursorTop);
        }

        Console.WriteLine();
    }
}

    

    class BreathingActivity : Activity
    {
        private readonly List<string> animationStrings = new List<string> { "|", "/", "-", "\\" };

        private void PlayAnimation(int seconds)
        {
            DateTime startTime = DateTime.Now;
            DateTime endTime = startTime.AddSeconds(seconds);

            int i = 0;

            while (DateTime.Now < endTime)
            {
                string s = animationStrings[i];
                Console.Write(s);
                Thread.Sleep(1000);
                Console.Write("\b \b");

                i++;

                if (i >= animationStrings.Count)
                {
                    i = 0;
                }
            }
        }

        private void RepeatBreathCycle(int duration, int breathCycles)
        {
            for (int cycle = 0; cycle < breathCycles; cycle++)
            {
                Console.Write("Breath in.... ");
                CountdownAnimation(5);

                Console.WriteLine();

                // Simulate pausing after displaying "Breath in...."
                Console.Write("Now breathe out...");
                CountdownAnimation(5);

                // Simulate pausing after displaying "Now breathe out..."
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();

                Thread.Sleep(1000); // Adjust the pause duration
            }
        }

        public override void StartActivity(int durationInSeconds)
        {
            DisplayStartMessage(durationInSeconds);

            int remainingDuration = durationInSeconds;

            while (remainingDuration > 0)
            {
                PlayAnimation(10); // Play the custom animation

                //  To show extend on Creation and prove I add in the BreathCycle  to be repeat after a certain time of pause Repeat BreathCycle  By setting the pause duration .
                // Extend and prove Like when the time is too long the code sperate the time so that the breathing activity start and after some time of second pause and display a message Get ready for the next cycle and start again.

                RepeatBreathCycle(Math.Min(remainingDuration, 10), 3);

                remainingDuration -= 10;
// Extend and prove Like when the time is too long the code sperate the time so that the breathing activity start and after some time of second pause and display a message Get ready for the next cycle and start again.
                if (remainingDuration > 0)
                {
                    
                    Console.WriteLine("Get ready for the next cycle...");
                    Thread.Sleep(2000); // Adjust the pause duration before the next cycle
                }
            }

            DisplayCompletionMessage(durationInSeconds);
        }
    }

    class ReflectionActivity : Activity
    {
        private readonly List<string> reflectionAnimation = new List<string> { "|", "/", "-", "\\" };

        public override void StartActivity(int durationInSeconds)
        {
            
            DisplayStartMessage(durationInSeconds);

            PlayReflectionAnimation(10); // Play the custom animation

            Console.WriteLine("--------Think of a time when you did something really difficult.--------");
            Console.WriteLine("When you have something in mind, press Enter to continue.");
            Console.ReadLine();

            Console.WriteLine("Now ponder on each of the following questions as they relate to this experience:");

            // Question 1
            Console.Write("You may Begin in:");
            CountdownAnimation(5);
            Console.WriteLine("");
            Console.WriteLine("");
            Console.Write("How did you feel when it was complete?");
            PlayReflectionAnimation(5);

            Console.WriteLine("");
            
            // Question 2
            Console.WriteLine("What is your favorite thing about this experience?");
            PlayReflectionAnimation(5);

            Console.WriteLine("");
            
            DisplayCompletionMessage(durationInSeconds);
        }

        private void PlayReflectionAnimation(int seconds)
        {
            DateTime startTime = DateTime.Now;
            DateTime endTime = startTime.AddSeconds(seconds);

            int i = 0;

            while (DateTime.Now < endTime)
            {
                string s = reflectionAnimation[i];
                Console.Write(s);
                Thread.Sleep(1000);
                Console.Write("\b \b");

                i++;

                if (i >= reflectionAnimation.Count)
                {
                    i = 0;
                }
            }
        }
    }

    class ListingActivity : Activity
    {
        
        
        public override void StartActivity(int durationInSeconds)
        {
            DisplayStartMessage(durationInSeconds);

            Console.WriteLine("List as many responses you can to the following prompt :");
            Console.WriteLine("-----When have you felt the Holy Ghost this month ?");
            Console.Write("You may begin in:");

            List<string> responses = new List<string>();

            CountdownAnimation(5);

            DateTime startTime = DateTime.Now;
            DateTime endTime = startTime.AddSeconds(durationInSeconds);

            while (DateTime.Now < endTime)
            {
                Console.Write("> ");
                string response = Console.ReadLine();
                responses.Add(response);

                Console.WriteLine();
                Console.WriteLine("You may continue typing positive things:");
                

                Thread.Sleep(1000); // Adjust the pause duration
            }

            Console.WriteLine();
            Console.WriteLine("Well done!");
            Console.WriteLine("Here is the list of positive things you typed during the session:");

            foreach (var response in responses)
            {
                Console.WriteLine(response);
            }

            DisplayCompletionMessage(durationInSeconds);
        }
    }
}
