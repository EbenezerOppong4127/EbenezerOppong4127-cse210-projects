using System;

// Base class for all types of goals
public abstract class Goal
{
    protected string name;
    protected string description;
    protected int points;

    public Goal(string name, string description, int points)
    {
        this.name = name;
        this.description = description;
        this.points = points;
    }

    public string GetName()
    {
        return name;
    }

    public int GetPoints()
    {
        return points;
    }

    public abstract string DisplayProgress();

    public abstract string SaveString();
}

// Simple Goal class
public class SimpleGoal : Goal
{
    public SimpleGoal(string name, string description, int points) : base(name, description, points)
    {
    }

    public override string DisplayProgress()
    {
        return $"[ ] {name} ({description})";
    }

    public override string SaveString()
    {
        return $"SimpleGoal: {name}, {description}, {points}";
    }
}

// Eternal Goal class
public class EternalGoal : Goal
{
    public EternalGoal(string name, string description, int points) : base(name, description, points)
    {
    }

    public override string DisplayProgress()
    {
        return $"[ ] {name} ({description})";
    }

    public override string SaveString()
    {
        return $"EternalGoal: {name}, {description}, {points}";
    }
}


public class ChecklistGoal : Goal
{
    private int timesToComplete;
    private int bonusPoints;
    private int completedTimes;
    private int initialPoints;

    public ChecklistGoal(string name, string description, int points, int timesToComplete, int bonusPoints) : base(name, description, points)
    {
        this.timesToComplete = timesToComplete;
        this.bonusPoints = bonusPoints;
        this.completedTimes = 0;
        this.initialPoints = points; // Store initial points
    }

    public void Complete()
    {
        completedTimes++;
    }

    public bool IsBonusAchieved()
    {
        return completedTimes >= timesToComplete;
    }

    public override string DisplayProgress()
    {
        string progress = $"[{(completedTimes >= timesToComplete ? "X" : " ")}] {name} ({description}) ";
        progress += $"{completedTimes}/{bonusPoints}";
        return progress;
    }

    public override string SaveString()
    {
        return $"ChecklistGoal: {name}, {description}, {points}, {bonusPoints}, {timesToComplete}, {completedTimes}";
    }

    public void ResetCompletion()
    {
        completedTimes = 0;
    }

    public void IncrementCompletion()
    {
        completedTimes++;
    }

    public int GetTimesToComplete()
    {
        return timesToComplete;
    }
}



