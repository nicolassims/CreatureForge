using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creature
{
    private Part core;
    private string name;
    private float distanceFromFloor;//measured in meters
    private float age;//measured in years
    private float discipline;//measured from 0 to 1
    //private float Perception;Can be calculated on the fly

    public Creature(Part core, string name, float distanceFromFloor, float age, float discipline)
    {
        this.core = core;
        this.name = name;
        this.distanceFromFloor = distanceFromFloor;
        this.age = age;
        this.discipline = discipline;
    }

    //public Creature(string name, float distanceFromFloor, float age, float discipline) : this(new Part(), name, distanceFromFloor, age, discipline) { }

    public string Print()
    {
        List<string> PrintedNames = new List<string>();

        return 
            $"Name: {name}\n" +
            $"DistanceFromFloor: {distanceFromFloor}\n" +
            $"Age: {age}\n" +
            $"Discipline: {discipline}\n" +
            $"Core Part:\n" +
            $"{core.Print(ref PrintedNames)}";
    }
}
