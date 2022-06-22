using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExternalSystem : BodySystem
{

    private Dictionary<PerceptionType, float> perceptionDictionary;
    private float sensitivity;//0 is completely immune to stimulus. 1 is perfectly sensitive. Can go above 1.
    private float hardness;//0 is completely impervious to indentation. 1 is completely intangible.
    private float sharpness;//0 is able to slice through everything. 1 is literally unable to cut anything.

    public ExternalSystem() : base()
    {
        sensitivity = 0.5f;
        hardness = 0.5f;
        sharpness = 0.5f;
        perceptionDictionary = new Dictionary<PerceptionType, float>();
    }

    public void SetPerceptionDictionary(Dictionary<PerceptionType, float> pd)
    {
        perceptionDictionary = pd;
    }

    public void SetPerceptionDictionary(PerceptionType pt, float strength)
    {
        perceptionDictionary.Add(pt, strength);
    }

    public override string Print()
    {
        string sensesdict = perceptionDictionary.Count == 0 ? "      None" : "";
        foreach (PerceptionType pt in perceptionDictionary.Keys) {
            sensesdict += $"      {pt}: {perceptionDictionary[pt]}\n";
        }

        return base.Print() +
            $"    Sensitivity: {sensitivity}\n" +
            $"    Hardness: {hardness}\n" +
            $"    Sharpness: {sharpness}\n" +
            $"    Senses Dictionary:\n" +
            $"{sensesdict}";
    }

    public void PopulatePerceptionDictionary(ref Dictionary<PerceptionType, float> newDict) {
        float multiplier = 1;//set one as the default multiplier
        Part nextPart = GetPart();//get the part this external system is attached to
        while (nextPart != null) {//if the nextPart is not null, which it can never be on the first loop...
            ExternalSystem nextExSys = nextPart.GetExternalSystem();
            if (nextExSys == null) {
                return;
            }
            multiplier *= nextExSys.GetFunctionality();//multiply the multiplier by the functionality of the external system of the nextPart
            nextPart = nextPart.GetToCore();//then set the nextPart to be one step closer to the core
        }

        foreach (PerceptionType perceptionType in perceptionDictionary.Keys) {
            if (newDict.ContainsKey(perceptionType)) {
                newDict[perceptionType] += perceptionDictionary[perceptionType] * multiplier;
            } else {
                newDict[perceptionType] = perceptionDictionary[perceptionType] * multiplier;
            }
        }
    }
}
