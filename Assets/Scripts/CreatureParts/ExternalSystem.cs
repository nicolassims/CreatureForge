using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExternalSystem : BodySystem
{
    private float sensitivity;//0 is completely immune to stimulus. 1 is perfectly sensitive. Can go above 1.
    private float hardness;//0 is completely impervious to indentation. 1 is completely intangible.
    private float sharpness;//0 is able to slice through everything. 1 is literally unable to cut anything.

    public ExternalSystem() : base()
    {
        sensitivity = 0.5f;
        hardness = 0.5f;
        sharpness = 0.5f;
    }

    public override string Print()
    {
        return base.Print() +
            $"    Sensitivity: {sensitivity}\n" +
            $"    Hardness: {hardness}\n" +
            $"    Sharpness: {sharpness}\n";
    }
}
