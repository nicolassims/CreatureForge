using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickDetector : MonoBehaviour {

    public void OnMouseUpAsButton() {
        Toggle.StopToggling();
        ConsoleScript.ContinueText();
    }
}
