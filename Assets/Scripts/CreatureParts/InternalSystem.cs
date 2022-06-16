using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum BodyResources {
    Air,
    Blood,
    Plasma,
    Sunlight,
    Ectoplasm,
    Fire,
    Venom,
    Poison,
    Nutrients
}

public class InternalSystem : BodySystem
{
    Dictionary<BodyResources, float> neededResources;
    Dictionary<BodyResources, float> currentResources;

    public InternalSystem() : base()
    {
        neededResources = new Dictionary<BodyResources, float>();
        currentResources = new Dictionary<BodyResources, float>();
    }

    public override string Print()
    {
        string neededResourcesString = "";
        string currentResourcesString = "";

        foreach (BodyResources resource in neededResources.Keys)
        {
            if (neededResourcesString != "")
            {
                neededResourcesString += ", ";
            }
            neededResourcesString += $"<{resource}, {neededResources[resource]}>";
        }

        foreach (BodyResources resource in currentResources.Keys)
        {
            if (currentResourcesString != "")
            {
                currentResourcesString += ", ";
            }
            currentResourcesString += $"<{resource}, {currentResources[resource]}>";
        }

        return base.Print() + 
            $"    Needed Resources: {neededResourcesString}\n" +
            $"    Current Resources: {currentResourcesString}\n";
    }
}
