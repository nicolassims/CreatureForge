using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Part : MonoBehaviour
{
    private List<Part> ConnectedParts;
    private NervousSystem NervousSystem;
    private InternalSystem InternalSystem;
    private ExternalSystem ExternalSystem;
    private BoneSystem BoneSystem;
    private MuscleSystem MuscleSystem;
    private Vector3 RelativeToCenter;
    private string Name;
    private float Length;
    private float Width;
    private float Density;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    internal object Print(ref List<string> printedNames)
    {
        printedNames.Add(Name);

        string returnable = 
            $"  Name: {Name}\n" +
            $"  Length: {Length}\n" +
            $"  Age: {Width}\n" +
            $"  Density: {Density}\n" +
            $"  MuscleSystem: {MuscleSystem.Print(ref printedNames)}\n" +
            $"  NervousSystem: {NervousSystem.Print(ref printedNames)}\n" +
            $"  InternalSystem: {InternalSystem.Print(ref printedNames)}\n" +
            $"  ExternalSystem: {ExternalSystem.Print(ref printedNames)}\n" +
            $"  BoneSystem: {BoneSystem.Print(ref printedNames)}\n";

        foreach (Part part in ConnectedParts) {
            if (!printedNames.Contains(part.Name)) { 
                returnable += part.Print(ref printedNames);
            }
        }

        return returnable;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
