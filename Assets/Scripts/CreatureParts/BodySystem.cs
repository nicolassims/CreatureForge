using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class BodySystem
{
    private List<BodySystem> connectedSystems;
    private Part parent;
    private string name;
    private float functionality;

    public BodySystem(List<BodySystem> connectedSystems, Part parent, string name, float functionality) {
        this.connectedSystems = connectedSystems;
        this.parent = parent;
        this.name = name;
        this.functionality = functionality;
    }

    public BodySystem(Part parent) : this(new List<BodySystem>(), parent, $"Unnamed Part", 0.5f) { }
    
    public string Print()
    {
        string returnable = "";
        foreach (PropertyDescriptor descriptor in TypeDescriptor.GetProperties(this))
        {
            string name = descriptor.Name;
            object value = descriptor.GetValue(this);
            returnable += $"    {name}: {value}";
        }

        return returnable;

        /*return
            $"    Name: {Name}\n" +
            $"    Functionality: {Functionality}";*/        
    }
}
