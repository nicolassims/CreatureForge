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

    public InternalSystem(Part parent) : base(parent)
    {
        neededResources = new Dictionary<BodyResources, float>();
        currentResources = new Dictionary<BodyResources, float>();
    }
}
