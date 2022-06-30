using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Part {
    private string name;

    private Part toCore;
    private List<Part> connectedParts;
    private NervousSystem nervousSystem;
    private InternalSystem internalSystem;
    private ExternalSystem externalSystem;
    private BoneSystem boneSystem;
    private MuscleSystem muscleSystem;
    private Vector3 relativeToCenter;
    private Vector3 dimensions;
    private float density;//given in kg/m^-3

    public Part(List<Part> connectedParts, NervousSystem nervousSystem, InternalSystem internalSystem, ExternalSystem externalSystem, 
            BoneSystem boneSystem, MuscleSystem muscleSystem, Vector3 relativeToCenter, string name, Vector3 dimensions, float density) {
        toCore = null;
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

    public float GetSize() {
        return dimensions.x * dimensions.y * dimensions.z;
    }

    public Vector3 GetRelativeToCenter() {
        return relativeToCenter;
    }

    public string GetName() {
        return name;
    }

    public List<Part> GetConnectedParts() {
        return connectedParts;
    }

    internal void GetParts(ref List<Part> foundParts) {
        if (!foundParts.Contains(this)) {
            foundParts.Add(this);
            foreach (Part part in connectedParts) {
                part.GetParts(ref foundParts);
            }
        }
    }

    public ExternalSystem GetExternalSystem() {
        return externalSystem;
    }

    public Part GetToCore() {
        return toCore;
    }

    public void GetPerception(ref Dictionary<PerceptionType, float> perceptionDictionary, ref List<string> checkedParts) {
        if (!checkedParts.Contains(name)) {
            if (externalSystem != null) {
                checkedParts.Add(name);
                externalSystem.PopulatePerceptionDictionary(ref perceptionDictionary);
            }

            foreach (var part in connectedParts) {
                part.GetPerception(ref perceptionDictionary, ref checkedParts);
            }
        }
    }

    internal float GetStrength() {
        if (muscleSystem != null) {
            return muscleSystem.GetStrength();
        } else {
            return 0;
        }
    }

    internal float GetPrecision() {
        if (muscleSystem != null) {
            return muscleSystem.GetPrecision();
        } else {
            return 1;
        }
    }

    internal void AssignCoreSteps(ref Dictionary<Part, int> pathDict, Part prevPart, int depth) {
        if (!pathDict.ContainsKey(this) || pathDict[this] > depth) {
            pathDict[this] = depth;
            toCore = prevPart;
        }
    }

    internal string Print(ref List<Part> printedNames) {
        string returnable = "";
        if (!printedNames.Contains(this)) {
            printedNames.Add(this);

            returnable =
                $"  Name: {name}\n" +
                $"  Dimensions: {dimensions}\n" +
                $"  Density: {density}\n" +
                $"  Local Position: {relativeToCenter}\n" +
                $"  MuscleSystem:\n{(muscleSystem == null ? "    None\n" : muscleSystem.Print())}" +
                $"  NervousSystem:\n{(nervousSystem == null ? "    None\n" : nervousSystem.Print())}" +
                $"  InternalSystem:\n{(internalSystem == null ? "    None\n" : internalSystem.Print())}" +
                $"  ExternalSystem:\n{(externalSystem == null ? "    None\n" : externalSystem.Print())}" +
                $"  BoneSystem:\n{(boneSystem == null ? "    None\n" : boneSystem.Print())}";

            foreach (Part part in connectedParts) {
                returnable += part.Print(ref printedNames);
            }
        }
        return returnable;
    }
}
