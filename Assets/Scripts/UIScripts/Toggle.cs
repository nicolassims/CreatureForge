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
    private UIState State;

    // Start is called before the first frame update
    private void Start() {
        EndToggling();
    }

    public void StartToggling()
    {
        gameObject.SetActive(true);
        State = UIState.Creating;
    }

    public void StopToggling()
    {
        State = UIState.Destroying;
    }

    private void EndToggling()
    {
        gameObject.SetActive(false);
        State = UIState.Inactive;
    }

    // Update is called once per frame
    private void Update()
    {
        if (State == UIState.Creating) {
            if (gameObject.transform.localScale.x < 1) {
                gameObject.transform.localScale += Vector3.one * 0.01f;
            } else {
                State = UIState.Passive;
            }
        } else if (State == UIState.Passive) {
            gameObject.transform.Translate(Mathf.Sin(Mathf.PI * Time.time) * 0.05f, 0, 0, Space.World);
        } else if (State == UIState.Destroying) {
            if (gameObject.transform.localScale.x > 0) {
                gameObject.transform.localScale -= Vector3.one * 0.03f;
            } else {
                EndToggling();
            }
        }
    }
}
