using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TextController : MonoBehaviour {

    public Text text;

	// Use this for initialization
	void Start () {
	    text.text = "Hello world";
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Space)) {
			text.text = "You are in a prison cell, and you want to escape. There are " +
						"some dirty sheets on the bed, a mirror on the wall, and the door " +
						"is locked from the outside.\n\n" +
						"Press S to view Sheets, M to view Mirror and L to view Lock" ;
		}
	}
}
