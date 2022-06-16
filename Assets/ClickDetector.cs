using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickDetector : MonoBehaviour {
    public Toggle toggle;
    public ConsoleScript consoleScript;

    public void OnMouseUpAsButton()
    {
        toggle.StopToggling();
        consoleScript.ContinueText();
    }
}
