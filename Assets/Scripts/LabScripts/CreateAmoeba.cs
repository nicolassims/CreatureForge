using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;

public class CreateAmoeba : MonoBehaviour
{
    public ConsoleScript Console;

    // Start is called before the first frame update
    async void Start() {
        await Console.PrintMessage("Let's make a creature.");

        await Console.PrintMessage("We'll start with a very simple one. A single-celled organism.\nAn <i>Amoeba</i>.");

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
