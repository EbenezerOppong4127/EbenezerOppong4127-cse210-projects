using System;

class Program
{
    static void Main(string[] args)
    {
        // Let print a message
        Console.Write("What is your first name ?");
        
        //Let get  input from the user
        string first = Console.ReadLine();
        
        // Let print a message
        Console.Write("What is your last name ?");
       
        //Let get  input from the user
        string last = Console.ReadLine();
        
        // Let print a message
        Console.WriteLine($"Your name is {last} , {first}  {last}");
    }
}