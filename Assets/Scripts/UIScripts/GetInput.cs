using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;

public class GetInput : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI inputBox;
    [SerializeField] private GameObject overParent;
    //private UIState state;
    private bool returnInput;

    private void Start()
    {
        overParent.transform.localScale = Vector3.zero;
        //state = UIState.Inactive;
        overParent.SetActive(false);
        returnInput = false;
    }

    public void ReturnInput()
    {
        returnInput = true;
    }

    public async Task<string> Input()//FIX THIS: Sanitize inputs
    {
        overParent.SetActive(true);
        overParent.transform.localScale = Vector3.zero;

        while (overParent.transform.localScale.x < 1)
        {
            overParent.transform.localScale += Vector3.one * 0.03f;
            await Task.Delay(5);
        }

        while (!returnInput)
        {
            await Task.Delay(1);
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
