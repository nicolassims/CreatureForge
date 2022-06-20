using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuscleSystem : BodySystem
{
    private float strength;//0 is completely incapable of movement. 1 is Saitama
    private float reactivity;//0 is totally unresponsive. 1 is Saitama
    private float precision;//0 is literally incapable of hitting anything, ever. 1 is perfectly accurate

    public MuscleSystem() : base()
    {
        strength = 0.5f;
        reactivity = 0.5f;
        precision = 0.5f;
    }

    public override string Print()
    {
        return base.Print() +
            $"    Type: MuscleSystem\n" +
            $"    Strength: {strength}\n" +
            $"    Reactivity: {reactivity}\n" +
            $"    Precision: {precision}\n";
    }
}
