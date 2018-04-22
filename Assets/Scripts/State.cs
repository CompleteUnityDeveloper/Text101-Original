using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "State")]
public class State : ScriptableObject
{
    [TextArea(3, 10)] [SerializeField] string storyText;
    [SerializeField] State[] nextStates;
}
