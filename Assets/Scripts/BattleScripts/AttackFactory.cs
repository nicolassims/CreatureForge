using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;

public class AttackFactory : MonoBehaviour {

    public ConsoleScript Console;

    public async Task<Attack> CreateAttack(Creature creature)
    {
        await Console.PrintMessage("Select the body part you wish to start the attack from.");

        foreach (Part part in creature.GetParts())
        {
            await Console.PrintMessage(part.name);
        }

        return new Attack();
    }
}
