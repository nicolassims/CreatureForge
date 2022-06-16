using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;

public class CreateAmoeba : MonoBehaviour
{
    public ConsoleScript Console;
    public GetInput Input;

    // Start is called before the first frame update
    async void Start() {
        await Console.PrintMessage("Let's make a creature.");

        await Console.PrintMessage("We'll start with a very simple one. A single-celled organism.\nAn <i>Amoeba</i>.");

        await Console.PrintMessage("Please enter a name for your monocellular pal.", offset: Vector3.up * 100);

        string amoebaName = await Input.Input();

        await Console.PrintMessage($"I see. {amoebaName}. A splendid name.");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
