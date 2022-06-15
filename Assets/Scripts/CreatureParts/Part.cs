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
            $"  MuscleSystem: {MuscleSystem.Print()}\n" +
            $"  NervousSystem: {NervousSystem.Print()}\n" +
            $"  InternalSystem: {InternalSystem.Print()}\n" +
            $"  ExternalSystem: {ExternalSystem.Print()}\n" +
            $"  BoneSystem: {BoneSystem.Print()}\n";

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
