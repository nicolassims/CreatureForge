using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creature : MonoBehaviour
{
    private Part Core;
    private string Name;
    private float DistanceFromFloor;
    private float Age;
    private float Discipline;
    private float Perception;

    public string PrintCreature()
    {
        return $"Name: {Name}\n" +
            $"DistanceFromFloor: {DistanceFromFloor}\n" +
            $"Age: {Age}\n" +
            $"Discipline: {Discipline}\n" +
            $"Perception: {Perception}";
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
