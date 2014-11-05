using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TextController : MonoBehaviour {

    public Text text;
    
	private enum States {
		cell, mirror, sheets_0, lock_0, cell_mirror, sheets_1, lock_1,
		corridor_0
		};
	private States myState;
    
    // Use this for initialization
	void Start () {
	    myState = States.cell;
	}
	
	// Update is called once per frame
	void Update () {
		print (myState);
		if 		(myState == States.cell) 		{cell();}
		else if (myState == States.sheets_0) 	{sheets_0();}
		else if (myState == States.sheets_1) 	{sheets_1();}
		else if (myState == States.lock_0) 		{lock_0();}
		else if (myState == States.lock_1) 		{lock_1();}
		else if (myState == States.mirror) 		{mirror();}
		else if (myState == States.cell_mirror) {cell_mirror();}
		else if (myState == States.corridor_0) 	{corridor_0();}
	}
	
	void cell () {
		text.text = "You are in a prison cell, and you want to escape. There are " +
					"some dirty sheets on the bed, a mirror on the wall, and the door " +
					"is locked from the outside.\n\n" +
					"Press S to view Sheets, M to view Mirror and L to view Lock" ;
		if 		(Input.GetKeyDown(KeyCode.S)) 	{myState = States.sheets_0;}
		else if (Input.GetKeyDown(KeyCode.M)) 	{myState = States.mirror;}
		else if (Input.GetKeyDown(KeyCode.L)) 	{myState = States.lock_0;}
    }
    
	void mirror() {
		text.text = "The dirty old mirror on the wall seems loose.\n\n" +
					"Press T to Take the mirror, or R to Return to cell" ;
		if 		(Input.GetKeyDown(KeyCode.T)) 	{myState = States.cell_mirror;}
		else if (Input.GetKeyDown(KeyCode.R)) 	{myState = States.cell;}
    }
    
	void cell_mirror() {
		text.text = "You are still in your cell, and you STILL want to escape! There are " +
					"some dirty sheets on the bed, a mark where the mirror was, " +
					"and that pesky door is still there, and firmly locked!\n\n" +
					"Press S to view Sheets, or L to view Lock" ;
		if 		(Input.GetKeyDown(KeyCode.S)) 	{myState = States.sheets_1;}
		else if (Input.GetKeyDown(KeyCode.L)) 	{myState = States.lock_1;}
    }
   
    void sheets_0 () {
		text.text = "You can't believe you sleep in these things. Surely it's " +
					"time somebody changed them. The pleasures of prison life " +
					"I guess!\n\n" +
					"Press R to Return to roaming your cell" ;
        if (Input.GetKeyDown(KeyCode.R)) 		{myState = States.cell;}
    }
    
	void sheets_1() {
		text.text = "Holding a mirror in your hand doesn't make the sheets look " +
					"any better.\n\n" +
					"Press R to Return to roaming your cell" ;
		if (Input.GetKeyDown(KeyCode.R)) 		{myState = States.cell_mirror;}
    }
    
    void lock_0() {
		text.text = "This is one of those button locks. You have no idea what the " +
					"combination is. You wish you could somehow see where the dirty " +
					"fingerprints were, maybe that would help.\n\n" +
					"Press R to Return to roaming your cell" ;
		if (Input.GetKeyDown(KeyCode.R)) 		{myState = States.cell;}
    }
    
	void lock_1() {
		text.text = "You carefully put the mirror through the bars, and turn it round " +
					"so you can see the lock. You can just make out fingerprints around " +
					"the buttons. You press the dirty buttons, and hear a click.\n\n" +
					"Press O to Open, or R to Return to your cell" ;
		if 		(Input.GetKeyDown(KeyCode.O)) 	{myState = States.corridor_0;}
		else if (Input.GetKeyDown(KeyCode.R)) 	{myState = States.cell_mirror;}
    }
    
	void corridor_0() {
		text.text = "You are in a corridor.\n\n" +
					"Press P to Play again";
		if (Input.GetKeyDown(KeyCode.P)) 		{myState = States.cell;}
    }
}
