using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class AttackFactory {

    public static async Task<Attack> CreateAttack(Creature creature)
    {

        await ConsoleScript.PrintMessage("Type the name or id of the body part you wish to start the attack from.");

        string bodyparts = "";
        List<Part> parts = creature.GetParts();
        for (int i = 0; i < parts.Count; i++) {
            bodyparts += $"{i} - {parts[i].name}\n";
        }

        await ConsoleScript.PrintMessage(bodyparts);

        string selectedpart = await GetInput.Input();

        return new Attack();
    }
}
