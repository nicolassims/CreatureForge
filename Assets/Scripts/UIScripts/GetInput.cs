using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;

public class GetInput : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI inputBox;
    private static bool returnInput = false;
    

    public void ReturnInput()
    {
        returnInput = true;
    }

    public async Task<string> Input()//FIX THIS: Sanitize inputs
    {
        while (!returnInput)
        {
            await Task.Delay(1);
        }

        return inputBox.text;
    }
}
