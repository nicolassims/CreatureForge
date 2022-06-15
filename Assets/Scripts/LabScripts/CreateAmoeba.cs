using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;

public class CreateAmoeba : MonoBehaviour
{
    public GameObject ConsoleObj;
    private TextMeshProUGUI Console;

    // Start is called before the first frame update
    async void Start()
    {
        Console = ConsoleObj.GetComponent<TextMeshProUGUI>();
        //Console.text = "";

        await PrintMessage("This is a message, for testing purposes.");


        Debug.Log("finished printing");
    }

    private async Task PrintMessage(string msg)
    {
        while (Console.text != "")
        {
            Console.text = Console.text.Remove(Console.text.Length - 1);
            await Task.Delay(50);
        }

        while (Console.text != msg)
        {
            Console.text += msg[Console.text.Length];
            await Task.Delay(50);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
