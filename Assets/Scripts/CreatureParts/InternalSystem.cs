using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InternalSystem : BodySystem
{
    Dictionary<BodyResources, float> neededResources;
    Dictionary<BodyResources, float> currentResources;

    public InternalSystem() : base()
    {
        neededResources = new Dictionary<BodyResources, float>();
        currentResources = new Dictionary<BodyResources, float>();
    }

    public void SetResources(Dictionary<BodyResources, float> resources)
    {
        neededResources = resources;
        currentResources = resources;
    }

    public void SetResources(BodyResources br, float amount)
    {
        neededResources.Add(br, amount);
        currentResources.Add(br, amount);
    }

    public override string Print()
    {
        string neededResourcesString = "";
        string currentResourcesString = "";

        foreach (BodyResources resource in neededResources.Keys)
        {
            if (neededResourcesString != "")
            {
                neededResourcesString += "\n";
            }
            neededResourcesString += $"      {resource}: {neededResources[resource]}";
        }

        foreach (BodyResources resource in currentResources.Keys)
        {
            if (currentResourcesString != "")
            {
                currentResourcesString += "\n";
            }
            currentResourcesString += $"      {resource}: {currentResources[resource]}";
        }

        return base.Print() +
            $"    Needed Resources:\n" +
            $"{neededResourcesString}\n" +
            $"    Current Resources\n" +
            $"{currentResourcesString}\n";
    }
}
