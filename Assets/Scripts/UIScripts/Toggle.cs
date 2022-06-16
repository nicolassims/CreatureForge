using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toggle : MonoBehaviour
{
    private enum ToggleState
    {
        Creating,
        Passive,
        Destroying,
        Inactive
    }

    private ToggleState State;

    // Start is called before the first frame update
    private void Start() {
        EndToggling();
    }

    public void StartToggling()
    {
        gameObject.SetActive(true);
        State = ToggleState.Creating;
    }

    public void StopToggling()
    {
        State = ToggleState.Destroying;
    }

    private void EndToggling()
    {
        gameObject.SetActive(false);
        State = ToggleState.Inactive;
    }

    // Update is called once per frame
    private void Update()
    {
        if (State == ToggleState.Creating) {
            if (gameObject.transform.localScale.x < 1) {
                gameObject.transform.localScale += Vector3.one * 0.01f;
            } else {
                State = ToggleState.Passive;
            }
        } else if (State == ToggleState.Passive) {
            gameObject.transform.Translate(Mathf.Sin(Mathf.PI * Time.time) * 0.05f, 0, 0, Space.World);
        } else if (State == ToggleState.Destroying) {
            if (gameObject.transform.localScale.x > 0) {
                gameObject.transform.localScale -= Vector3.one * 0.01f;
            } else {
                StopToggling();
            }
        }
    }
}
