using System;
using Learning02;

class Program
{
    static void Main(string[] args)
    {
        // Create instances of Job
        Job job1 = new Job("Microsoft", "Software Engineer", 2019, 2022);
        Job job2 = new Job("Apple", "Manager", 2022, 2023);

        // Display job details
        job1.Display();
        job2.Display();
        
        // Create instance of Resume
        Resume myResume = new Resume("Allison Rose");

        // Add jobs to the resume
        myResume._jobs.Add(new Job("Microsoft", "Software Engineer", 2019, 2022));
        myResume._jobs.Add(new Job("Apple", "Manager", 2022, 2023));

        // Display resume details
        myResume.Display();
    }
}