using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ConsoleScript : MonoBehaviour
{
    [SerializeField] private Toggle Toggle;
    [SerializeField] private TextMeshProUGUI Console;

    private bool Continue = false;

    public void ContinueText()
    {
        Continue = true;
    }

    public async Task PrintMessage(string msg, int waittime = 0)
    {
        while (Console.text != "")
        {
            Console.text = Console.text.Remove(Console.text.Length - 1);
            await Task.Delay(20);
        }

        while (Console.text != msg)
        {
            if (msg[Console.text.Length] == '<')
            {
                int startingIndex = Console.text.Length;
                int distance = 1;
                while (msg[startingIndex + distance] != '>')
                {
                    distance++;
                }
                Console.text += msg.Substring(startingIndex, distance);
            }
            Console.text += msg[Console.text.Length];
            await Task.Delay(50);
        }

        if (waittime == 0) {
            Toggle.StartToggling();
        } else {
            await Task.Delay(waittime);
            Continue = true;
        }

        while (!Continue)
        {
            await Task.Delay(1);
        }
    }
}
