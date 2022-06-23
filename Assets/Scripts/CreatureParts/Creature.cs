using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creature
{
    private List<Part> cores;
    private string name;
    private float distanceFromFloor;//measured in meters
    private float age;//measured in years
    private float discipline;//measured from 0 to 1    

    public Creature(List<Part> cores, string name, float distanceFromFloor, float age, float discipline)
    {
        this.cores = cores;
        this.name = name;
        this.distanceFromFloor = distanceFromFloor;
        this.age = age;
        this.discipline = discipline;

        AssignCoreSteps();
    }

    public Creature(Part core, string name, float distanceFromFloor, float age, float discipline) 
        : this(new List<Part>() { core }, name, distanceFromFloor, age, discipline ) { }

    public void AssignCoreSteps() {
        Dictionary<Part, int> pathDict = new Dictionary<Part, int>();
        foreach (Part core in cores)
        {
            core.AssignCoreSteps(ref pathDict, null, 0);
        }
    }

    public List<Part> GetParts()
    {
        List<Part> foundParts = new List<Part>();
        foreach (Part core in cores) {
            core.GetParts(ref foundParts);
        }
        return foundParts;
    }

    public Dictionary<PerceptionType, float> GetPerception()
    {
        Dictionary<PerceptionType, float> PerceptionDictionary = new Dictionary<PerceptionType, float>();
        List<string> checkedParts = new List<string>();
        foreach(Part core in cores) { 
            core.GetPerception(ref PerceptionDictionary, ref checkedParts);
        }
        return PerceptionDictionary;
    }

    public string Print()
    {
        List<Part> PrintedNames = new List<Part>();
        string coreoutput = "No cores!";

        foreach (Part core in cores)
        {
            coreoutput =
            $"Core Part:\n" +
            $"{core.Print(ref PrintedNames)}";
        }

        Dictionary<PerceptionType, float> sensesdict = GetPerception();
        string sensesoutput = sensesdict.Count == 0 ? "  None" : "";
        foreach (PerceptionType pt in sensesdict.Keys) {
            sensesoutput += $"  {pt}: {sensesdict[pt]}\n";
        }

        return 
            $"Name: {name}\n" +
            $"DistanceFromFloor: {distanceFromFloor}\n" +
            $"Age: {age}\n" +
            $"Discipline: {discipline}\n" +
            $"Senses:\n" +
            $"{sensesoutput}" +
            $"{coreoutput}";
    }
}
