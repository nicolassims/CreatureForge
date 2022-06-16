using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuscleSystem : BodySystem
{
    private float Strength;//0 is completely incapable of movement. 1 is Saitama
    private float Reactivity;//0 is totally unresponsive. 1 is Saitama
    private float Precision;//0 is literally incapable of hitting anything, ever. 1 is perfectly accurate

    public MuscleSystem(Part parent) : base(parent)
    {
        Strength = 0.5f;
        Reactivity = 0.5f;
        Precision = 0.5f;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
