using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum UIState
{
    Creating,
    Passive,
    Destroying,
    Inactive
}

public class Toggle : MonoBehaviour
{
    private static UIState State;
    private static GameObject GameObject;

    // Start is called before the first frame update
    private void Start() {
        GameObject = GameObject.Find("Toggle");
        EndToggling();
    }

    public static void StartToggling()
    {
        GameObject.SetActive(true);
        State = UIState.Creating;
    }

    public static void StopToggling()
    {
        State = UIState.Destroying;
    }

    private static void EndToggling()
    {
        GameObject.SetActive(false);
        State = UIState.Inactive;
    }

    // Update is called once per frame
    private static void Update() {
        if (State == UIState.Creating) {
            if (GameObject.transform.localScale.x < 1) {
                GameObject.transform.localScale += Vector3.one * 0.01f;
            } else {
                State = UIState.Passive;
            }
        } else if (State == UIState.Passive) {
            GameObject.transform.Translate(Mathf.Sin(Mathf.PI * Time.time) * 0.05f, 0, 0, Space.World);
        } else if (State == UIState.Destroying) {
            if (GameObject.transform.localScale.x > 0) {
                GameObject.transform.localScale -= Vector3.one * 0.03f;
            } else {
                EndToggling();
            }
        }
    }
}
