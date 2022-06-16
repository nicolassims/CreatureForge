using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Part
{
    private List<Part> connectedParts;
    private NervousSystem nervousSystem;
    private InternalSystem internalSystem;
    private ExternalSystem externalSystem;
    private BoneSystem boneSystem;
    private MuscleSystem muscleSystem;
    private Vector3 relativeToCenter;
    private Vector3 dimensions;
    private string name;
    private float density;//given in kg/m^-3

    public Part(List<Part> connectedParts, NervousSystem nervousSystem, InternalSystem internalSystem, ExternalSystem externalSystem, BoneSystem boneSystem, 
            MuscleSystem muscleSystem, Vector3 relativeToCenter, string name, Vector3 dimensions, float density) {
        this.connectedParts = connectedParts;
        this.nervousSystem = nervousSystem;
        this.internalSystem = internalSystem;
        this.externalSystem = externalSystem;
        this.boneSystem = boneSystem;
        this.muscleSystem = muscleSystem;
        this.relativeToCenter = relativeToCenter;
        this.name = name;
        this.dimensions = dimensions;
        this.density = density;
    }

    internal object Print(ref List<string> printedNames)
    {
        printedNames.Add(name);

        string returnable = 
            $"  Name: {name}\n" +
            $"  Dimensions: {dimensions}\n" +
            $"  Density: {density}\n" +
            $"  Local Position: {relativeToCenter}\n" +
            $"  MuscleSystem:\n{(muscleSystem == null ? "    None\n" : muscleSystem.Print())}\n" +
            $"  NervousSystem:\n{(nervousSystem == null ? "    None\n" : nervousSystem.Print())}\n" +
            $"  InternalSystem:\n{(internalSystem == null ? "    None\n" : internalSystem.Print())}\n" +
            $"  ExternalSystem:\n{(externalSystem == null ? "    None\n" : externalSystem.Print())}\n" +
            $"  BoneSystem:\n{(boneSystem == null ? "    None\n" : boneSystem.Print())}\n";

        foreach (Part part in connectedParts) {
            if (!printedNames.Contains(part.name)) { 
                returnable += part.Print(ref printedNames);
            }
        }

        return returnable;
    }
}
