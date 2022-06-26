using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using UnityEngine;

public class BodySystem
{
    private const float MAXFUNCTIONALITY = 1;

    private Part part;
    private string name;
    private float functionality;

    public BodySystem(string name, float functionality, Part part) {
        this.part = part;
        this.name = name;
        this.functionality = functionality;
    }

    public BodySystem() : this($"BodySystem #{Random.Range(0, 100000)}", 1, null) { }
    
    public void SetPart(Part part)
    {
        this.part = part;
    }

    public Part GetPart()
    {
        return part;
    }

    public float GetFunctionality()
    {
        return functionality;
    }

    public virtual string Print()
    {
        string returnable = "";

        returnable +=
            $"    Part of Part: {part.GetName()}\n" +
            $"    Name: {name}\n" +
            $"    MaxFunctionality: {MAXFUNCTIONALITY}\n" +
            $"    Functionality: {functionality}\n"; 

        return returnable;   
    }
}
