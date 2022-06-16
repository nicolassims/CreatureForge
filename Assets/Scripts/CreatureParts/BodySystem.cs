using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using UnityEngine;

public class BodySystem
{
    private List<BodySystem> connectedSystems;
    private string name;
    private float functionality;

    public BodySystem(List<BodySystem> connectedSystems, string name, float functionality) {
        this.connectedSystems = connectedSystems;
        this.name = name;
        this.functionality = functionality;
    }

    public BodySystem() : this(new List<BodySystem>(), $"Unnamed Part", 0.5f) { }
    
    public virtual string Print()
    {
        string returnable = "";
        string connectedSystemsString = "";

        foreach(BodySystem system in connectedSystems)
        {
            if (connectedSystemsString != "")
            {
                connectedSystemsString += ", ";
            }
            connectedSystemsString += system.name;
        }

        returnable +=
            $"    Connected Systems: {connectedSystemsString}\n" +
            $"    Name: {name}\n" +
            $"    Functionality: {functionality}\n"; 

        return returnable;   
    }
}
