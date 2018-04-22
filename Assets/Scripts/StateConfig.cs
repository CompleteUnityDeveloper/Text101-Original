using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "State")]
public class StateConfig : ScriptableObject
{
    [TextArea(3, 10)] [SerializeField] string storyText;
    [SerializeField] StateConfig[] nextStates;

    public string GetStateStory()
    {
        return storyText;
    }

    public StateConfig[] GetNextStates()
    {
        return nextStates;
    }
}
