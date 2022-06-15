using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class BodySystem : MonoBehaviour
{
    private List<BodySystem> ConnectedSystems;
    private Part Part;
    private string Name;
    private float Functionality;
    
    public string Print(ref List<string> printedNames)
    {

        string returnable = "";
        foreach (PropertyDescriptor descriptor in TypeDescriptor.GetProperties(this))
        {
            string name = descriptor.Name;
            object value = descriptor.GetValue(this);
            returnable += $"    {name}: {value}";
        }

        return returnable;

        /*return
            $"    Name: {Name}\n" +
            $"    Functionality: {Functionality}";*/        
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
