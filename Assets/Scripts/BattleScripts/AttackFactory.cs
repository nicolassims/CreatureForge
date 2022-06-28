using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class EndPart : Part {
    public EndPart() : base(null, null, null, null, null, null, Vector3.zero, "EndPart", Vector3.zero, 0) { }
}

public class AttackFactory {

    public static async Task<Attack> CreateAttack(Creature creature) {
        Part firstpart = null;

        while (firstpart == null) {
            await ConsoleScript.PrintMessage("Type the name or id of the body part you wish to start the attack from.");

            firstpart = await SelectPart(creature.GetParts());
        }

        Attack attack = new Attack(firstpart);

        await ContinueAttack(attack);

        return attack;
    }

    private static async Task<Part> SelectPart(List<Part> parts, bool forAttack = false) {

        string bodyparts = "";
        for (int i = 0; i < parts.Count; i++) {
            bodyparts += $"{i} - {parts[i].GetName()}\n";
        }
        if (forAttack) {
            bodyparts += $"End Attack\n";
        }

        await ConsoleScript.PrintMessage(bodyparts, false);
        string selectedpart = await GetInput.Input();

        if (selectedpart.ToLower().Contains("end attack")) {
            return new EndPart();
        }

        Part returnable = null;

        if (int.TryParse(selectedpart.Trim(new char[] { ' ', '\n' }), out int result) && result < parts.Count) {
            returnable = parts[result];
        } else {
            for (int i = 0; i < parts.Count; i++) {
                if (selectedpart.ToLower().Contains(parts[i].GetName().ToLower())) {
                    returnable = parts[i];
                    break;
                }
            }
        }

        if (returnable != null) {
            await ConsoleScript.PrintMessage($"You wish to attack with the \"{returnable.GetName()}\"? (Y/N)", delayContinue: false);
            string confirmattack = await GetInput.Input();

            if (confirmattack.ToLower() == "y") {
                await ConsoleScript.PrintMessage($"Confirmed.");
            } else {
                await ConsoleScript.PrintMessage($"Choice canceled.");
                returnable = null;
            }
        }

        return returnable;
    }

    private static async Task ContinueAttack(Attack firstattack, AttackStep currentStep = null) {
        if (currentStep == null) {
            currentStep = firstattack.GetAttackStep();
        }

        Part currentPart = currentStep.GetPart();

        await ConsoleScript.PrintMessage($"You are attacking from the {currentPart.GetName()}.");

        Part nextPart = null;

        List<Part> possibleNexts = currentPart.GetConnectedParts();
        if (!(possibleNexts == null || possibleNexts.Count == 0)) {

            await ConsoleScript.PrintMessage("It is possible to continue this attack.");

            bool allPartsSelected = false;
            List<Part> selectedParts = new List<Part> { };

            while (!allPartsSelected) {
                while (nextPart != null) {
                    await ConsoleScript.PrintMessage($"Please type the name or id of the body part would you like to continue this attack from, or type \"End Attack\" to submit the attack.");

                    string bodyparts = "";
                    for (int i = 0; i < possibleNexts.Count; i++) {
                        bodyparts += $"{i} - {possibleNexts[i].GetName()}\n";
                    }

                    nextPart = await SelectPart(possibleNexts);
                }

                if (nextPart is EndPart) {
                    return;
                }

                possibleNexts.Remove(nextPart);
                selectedParts.Add(nextPart);

                if (possibleNexts.Count != 0) {
                    await ConsoleScript.PrintMessage("You can also continue this attack from another part, though the effect will be weaker.");
                    await ConsoleScript.PrintMessage("Would you like to do so? (Y/N)", delayContinue: false);
                    string confirmattack = await GetInput.Input();

                    if (confirmattack.ToLower() == "y") {
                        await ConsoleScript.PrintMessage($"Confirmed.");
                        allPartsSelected = true;
                    }
                } else {
                    allPartsSelected = true;
                }
            }

            foreach (Part part in selectedParts) {
                currentStep.AddNextPart(part);
            }

            foreach (AttackStep attackStep in currentStep.GetNextAttacks()) {
                await ContinueAttack(firstattack, attackStep);
            }
        }
    }
}
