using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum BodyResources {
    Air,
    Blood,
    Plasma,
    Sunlight
}

public class InternalSystem : BodySystem
{
    Dictionary<BodyResources, float> NeededResources;
    Dictionary<BodyResources, float> CurrentResources;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
