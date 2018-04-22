using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class PrisonGame : MonoBehaviour
{
    // configuration parameters
    [SerializeField] Text textComponent;
    [SerializeField] State startingState;
    [SerializeField] State[] gameStates;

    // state variables
    State state;

    // Use this for initialization
    void Start()
    {
        state = startingState;
        textComponent.text = state.GetStateStory();
    }

    // Update is called once per frame
    void Update()
    {
        print("Current state: " + state.name);
        ManageState();
    }

    private void ManageState()
    {
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            var nextStates = state.GetNextStates();
            state = nextStates[0];
            textComponent.text = state.GetStateStory();
        }

    }
}