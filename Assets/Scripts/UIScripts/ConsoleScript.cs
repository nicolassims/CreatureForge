using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ConsoleScript : MonoBehaviour
{
    [SerializeField] private Toggle toggle;
    [SerializeField] private TextMeshProUGUI console;

    private bool continueConsole = false;

    public void ContinueText()
    {
        continueConsole = true;
    }

    public async Task PrintMessage(string msg, bool delayContinue = true, int waittime = 0, Vector3 offset = new Vector3()) {
        while (console.text != "")
        {
            console.text = console.text.Remove(console.text.Length - 1);
            await Task.Delay(20);
        }

        transform.localPosition = offset;

        while (console.text != msg)
        {
            if (msg[console.text.Length] == '<')
            {
                int startingIndex = console.text.Length;
                int distance = 1;
                while (msg[startingIndex + distance] != '>')
                {
                    distance++;
                }
                console.text += msg.Substring(startingIndex, distance);
            }
            console.text += msg[console.text.Length];
            await Task.Delay(50);
        }

        if (delayContinue) { 
            if (waittime == 0) {
                toggle.StartToggling();
            } else {
                await Task.Delay(waittime);
                ContinueText();
            }

            while (!continueConsole)
            {
                await Task.Delay(1);
            }

            continueConsole = false;
        }
    }
}
