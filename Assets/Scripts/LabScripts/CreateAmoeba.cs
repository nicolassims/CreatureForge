using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;

public class CreateAmoeba : MonoBehaviour
{
    // Start is called before the first frame update
    async void Start() {
        await Task.Delay(1);

        //FIX THIS: Commenting for expediency of testing.

        /*await Console.PrintMessage("Let's make a creature.");

        await Console.PrintMessage("We'll start with a very simple one. A single-celled organism.\nAn <i>Amoeba</i>.");

        await Console.PrintMessage("Please enter a name for your monocellular pal.", delayContinue: false, offset: Vector3.up * 75);

        string amoebaName = await Input.Input();

        await Console.PrintMessage($"I see. {amoebaName}. A splendid name.");*/

        Creature dave = NewAmoeba("Dave");

        Debug.Log(dave.Print());

        await AttackFactory.CreateAttack(dave);

        
    }

    public Creature NewAmoeba(string name) {
        InternalSystem iSys = new InternalSystem();
        ExternalSystem exSys = new ExternalSystem();
        MuscleSystem mSys = new MuscleSystem();


        Part core = new Part(new List<Part>(), null, iSys, exSys, null, mSys, Vector3.zero, "Core", Vector3.one * 0.000001f, 1400);

        iSys.SetPart(core);
        iSys.SetResources(BodyResources.Ooze, 0.005f);
        iSys.SetResources(BodyResources.Air, 0.005f);
        exSys.SetPart(core);
        exSys.SetPerceptionDictionary(PerceptionType.Chemicals, 0.005f);
        exSys.SetPerceptionDictionary(PerceptionType.Touch, 0.005f);
        exSys.SetPerceptionDictionary(PerceptionType.Temperature, 0.005f);
        exSys.SetPerceptionDictionary(PerceptionType.Magnetism, 0.005f);
        mSys.SetPart(core);

        return new Creature(new List<Part>() { core }, name, 0.0000005f, 1.0f / 365.0f, 1);
    }
}
