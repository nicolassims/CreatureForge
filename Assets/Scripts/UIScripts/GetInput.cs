using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;

public class GetInput : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI inputBox;
    [SerializeField] private GameObject overParent;

    private void Start()
    {
        overParent.transform.localScale = Vector3.zero;
        //state = UIState.Inactive;
        overParent.SetActive(false);
    }

    public static async Task<string> Input()//FIX THIS: Sanitize inputs
    {
        GameObject overParent = GameObject.Find("TextInput");
        TextMeshProUGUI inputBox = FindObjectOfType<TextMeshProUGUI>();

        overParent.SetActive(true);
        overParent.transform.localScale = Vector3.zero;

        while (overParent.transform.localScale.x < 1)
        {
            overParent.transform.localScale += Vector3.one * 0.03f;
            await Task.Delay(5);
        }

        while (overParent.transform.localScale.x > 0)
        {
            overParent.transform.localScale -= Vector3.one * 0.03f;
            await Task.Delay(5);
        }

        overParent.transform.localScale = Vector3.zero;
        overParent.SetActive(false);

        return inputBox.text;
    }
}
