using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class EndPart : Part {
    public EndPart() : base(null, null, null, null, null, null, Vector3.zero, "EndPart", Vector3.zero, 0) { }
}

public class AttackFactory {

    private static async Task<Part> SelectPart(List<Part> parts, Part changeVar, bool forAttack = false) {

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

        if (int.TryParse(selectedpart.Trim(new char[] { ' ', '\n' }), out int result) && result < parts.Count) {
            changeVar = parts[result];
        } else {
            for (int i = 0; i < parts.Count; i++) {
                if (selectedpart.ToLower().Contains(parts[i].GetName().ToLower())) {
                    changeVar = parts[i];
                    break;
                }
            }
        }

        if (changeVar != null) {
            await ConsoleScript.PrintMessage($"You wish to attack with the \"{changeVar.GetName()}\"? (Y/N)");

            string confirmattack = await GetInput.Input();

            if (confirmattack.ToLower() == "y") {
                await ConsoleScript.PrintMessage($"Confirmed.");
            } else {
                await ConsoleScript.PrintMessage($"Choice canceled.");
                changeVar = null;
            }
        }

        return changeVar;
    }

    public static async Task<Attack> CreateAttack(Creature creature)
    {
        Part firstpart = null;

        while (firstpart == null) {
            await ConsoleScript.PrintMessage("Type the name or id of the body part you wish to start the attack from.");

            await SelectPart(creature.GetParts(), firstpart);
        }

        Attack attack = new Attack(firstpart);

        attack = await ContinueAttack(attack);

        return attack;
    }

    private static async Task<Attack> ContinueAttack(Attack firstattack, AttackStep currentStep = null) {
        if (currentStep == null) {
            currentStep = firstattack.GetAttackStep();
        }

        Part currentPart = currentStep.GetPart();

        await ConsoleScript.PrintMessage($"You are attacking from the {currentPart.GetName()}");

        Part nextPart = null;

        List<Part> possibleNexts = currentPart.GetConnectedParts();
        if (!(possibleNexts == null || possibleNexts.Count == 0)) {

            await ConsoleScript.PrintMessage("It is possible to continue this attack.");
            
            while (nextPart != null) { 

                await ConsoleScript.PrintMessage($"Please type the name or id of the body part would you like to continue this attack from, or type \"End Attack\" to submit the attack.");

                string bodyparts = "";
                for (int i = 0; i < possibleNexts.Count; i++) {
                    bodyparts += $"{i} - {possibleNexts[i].GetName()}\n";
                }
                
                nextPart = await SelectPart(possibleNexts, nextPart);
            }

            //continue adding to the attack here. Give the option for more attacking ability, by having one part lead to multiple others

            if (nextPart is EndPart) {
                //end the attack for this body part.
                return;
            }
        }

        

        throw new NotImplementedException();
    }
}
