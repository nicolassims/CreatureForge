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

        await Console.PrintMessage("Please enter a name for your monocellular pal.", delayContinue: false, offset: Vector3.up * 75);

        string amoebaName = await Input.Input();

        await Console.PrintMessage($"I see. {amoebaName}. A splendid name.");

        Debug.Log(NewAmoeba(amoebaName).Print());


    }

    public Creature NewAmoeba(string name)
    {

        InternalSystem iSys = new InternalSystem();
        ExternalSystem exSys = new ExternalSystem();
        MuscleSystem mSys = new MuscleSystem();


        Part core = new Part(new List<Part>(), null, iSys, exSys, null, mSys, Vector3.zero, "Core", Vector3.one * 0.000001f, 1400);

        iSys.SetPart(core);
        exSys.SetPart(core);
        mSys.SetPart(core);

        return new Creature(core, name, 0.0000005f, 1.0f / 365.0f, 1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
