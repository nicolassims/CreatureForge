using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum Resources {
    Air,
    Blood,
    Plasma,
    Sunlight
}

public class InternalSystem : BodySystem
{
    Dictionary<Resources, float> NeededResources;
    Dictionary<Resources, float> CurrentResources;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
