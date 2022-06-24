using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;

public class GetInput : MonoBehaviour
{
    private static bool hasInput = false;

    private void Start()
    {
        GameObject overParent = GameObject.Find("TextInput");
        overParent.transform.localScale = Vector3.zero;
    }

    public void HasInput() {
        hasInput = true;
    }

    public static async Task<string> Input()//FIX THIS: Sanitize inputs
    {
        GameObject overParent = GameObject.Find("TextInput");
        TMP_InputField inputBox = overParent.GetComponent<TMP_InputField>();

        overParent.transform.localScale = Vector3.zero;

        while (overParent.transform.localScale.x < 1) {
            overParent.transform.localScale += Vector3.one * 0.03f;
            await Task.Delay(5);
        }

        while (!hasInput) {
            await Task.Delay(1);
        }

        while (overParent.transform.localScale.x > 0) {
            overParent.transform.localScale -= Vector3.one * 0.03f;
            await Task.Delay(5);
        }

        overParent.transform.localScale = Vector3.zero;
        hasInput = false;

        return inputBox.text;
    }
}
