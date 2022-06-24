using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class AttackFactory {

    public static async Task<Attack> CreateAttack(Creature creature)
    {
        Part firstpart = null;

        while (firstpart == null) {

            await ConsoleScript.PrintMessage("Type the name or id of the body part you wish to start the attack from.");

            string bodyparts = "";
            List<Part> parts = creature.GetParts();
            for (int i = 0; i < parts.Count; i++) {
                bodyparts += $"{i} - {parts[i].name}\n";
            }

            await ConsoleScript.PrintMessage(bodyparts, false);
            string selectedpart = await GetInput.Input();

            if (int.TryParse(selectedpart.Trim(new char[] { ' ', '\n' }), out int result) && result < parts.Count) {
                firstpart = parts[result];
            } else {
                for (int i = 0; i < parts.Count; i++) {
                    if (selectedpart.ToLower().Contains(parts[i].name.ToLower())) {
                        firstpart = parts[i];
                        break;
                    }
                }
            }

            if (firstpart != null) {
                await ConsoleScript.PrintMessage($"You wish to attack with the \"{firstpart.name}\"? (Y/N)");

                string confirmattack = await GetInput.Input();

                if (confirmattack.ToLower() == "y") {
                    await ConsoleScript.PrintMessage($"Confirmed.");
                } else {
                    await ConsoleScript.PrintMessage($"Choice canceled.");
                    firstpart = null;
                }
            }
        }

        return new Attack();
    }
}
