using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PrisonGame : MonoBehaviour
{
    // configuration parameters
    [SerializeField] Text textComponent;

    // state variables
	enum State
    {
		cell, mirror, sheets_0, lock_0, cell_mirror, sheets_1, lock_1, corridor_0, stairs_0, stairs_1,
		stairs_2, courtyard, floor, corridor_1, corridor_2, corridor_3,closet_door, in_closet
	};
    State currentState;
    
    // Use this for initialization
	void Start ()
    {
	    currentState = State.cell;
	}
	
	// Update is called once per frame
	void Update ()
    {
        CallStateMethod();
    }

    private void CallStateMethod()
    {
        // todo compare to switch
        switch (currentState)
        {
            case State.cell: cell(); break;
            case State.sheets_0: sheets_0(); break;
            case State.sheets_1: sheets_1(); break;
            case State.lock_0: lock_0(); break;
            case State.lock_1: lock_1(); break;
            case State.mirror: mirror(); break;
            case State.cell_mirror: cell_mirror(); break;
            case State.corridor_0: corridor_0(); break;
            case State.stairs_0: stairs_0(); break;
            case State.stairs_1: stairs_1(); break;
            case State.stairs_2: stairs_2(); break;
            case State.courtyard: courtyard(); break;
            case State.floor: floor(); break;
            case State.corridor_1: corridor_1(); break;
            case State.corridor_2: corridor_2(); break;
            case State.corridor_3: corridor_3(); break;
            case State.closet_door: closet_door(); break;
            case State.in_closet: in_closet(); break;
            default: Debug.LogError("In unknown state"); return;
        }
    }

    private void in_closet()
    {
		textComponent.text = "Inside the closet you see a cleaner's uniform that looks about your size! " +
					"Seems like your day is looking-up.\n\n" +
					"Press D to Dress up, or R to Return to the corridor";
		if 		(Input.GetKeyDown(KeyCode.R)) 	{currentState = State.corridor_2;}
		else if (Input.GetKeyDown(KeyCode.D)) 	{currentState = State.corridor_3;}
	}
	
	private void closet_door()
    {
		textComponent.text = "You are looking at a closet door, unfortunately it's locked. " +
					"Maybe you could find something around to help enourage it open?\n\n" +
					"Press R to Return to the corridor";
		if (Input.GetKeyDown(KeyCode.R)) 		{currentState = State.corridor_0;}
	}
	
	private void corridor_3()
    {
		textComponent.text = "You're standing back in the corridor, now convincingly dressed as a cleaner. " +
					"You strongly consider the run for freedom.\n\n" +
					"Press S to take the Stairs, or U to Undress";
		if 		(Input.GetKeyDown(KeyCode.S)) 	{currentState = State.courtyard;}
		else if (Input.GetKeyDown(KeyCode.U))	{currentState = State.in_closet;}
	}
	
	private void corridor_2()
    {
		textComponent.text = "Back in the corridor, having declined to dress-up as a cleaner.\n\n" +
					"Press C to revisit the Closet, and S to climb the stairs";
		if 		(Input.GetKeyDown(KeyCode.C)) 	{currentState = State.in_closet;}
		else if (Input.GetKeyDown(KeyCode.S)) 	{currentState = State.stairs_2;}
	}
	
	private void corridor_1()
    {
		textComponent.text = "Still in the corridor. Floor still dirty. Hairclip in hand. " +
					"Now what? You wonder if that lock on the closet would succumb to " +
					"to some lock-picking?\n\n" +
					"P to Pick the lock, and S to climb the stairs";
		if (Input.GetKeyDown(KeyCode.P)) 		{currentState = State.in_closet;}
		else if (Input.GetKeyDown(KeyCode.S)) 	{currentState = State.stairs_1;}
	}
	
	private void floor () {
		textComponent.text = "Rummagaing around on the dirty floor, you find a hairclip.\n\n" +
					"Press R to Return to the standing, or H to take the Hairclip." ;
		if 		(Input.GetKeyDown(KeyCode.R)) 	{currentState = State.corridor_0;}
		else if (Input.GetKeyDown(KeyCode.H)) 	{currentState = State.corridor_1;}
	}	
	
	private void courtyard ()
    {
		textComponent.text = "You walk through the courtyard dressed as a cleaner. " +
					"The guard tips his hat at you as you waltz past, claiming " +
					"your freedom. You heart races as you walk into the sunset.\n\n" +
					"Press P to Play again." ;
		if (Input.GetKeyDown(KeyCode.P)) 		{currentState = State.cell;}
	}	
	
	private void stairs_0 ()
    {
		textComponent.text = "You start walking up the stairs towards the outside light. " +
					"You realise it's not break time, and you'll be caught immediately. " +
					"You slither back down the stairs and reconsider.\n\n" +
					"Press R to Return to the corridor." ;
		if (Input.GetKeyDown(KeyCode.R)) 		{currentState = State.corridor_0;}
	}
	
	private void stairs_1 ()
    {
		textComponent.text = "Unfortunately weilding a puny hairclip hasn't given you the " +
					"confidence to walk out into a courtyard surrounded by armed guards!\n\n" +
					"Press R to Retreat down the stairs" ;
		if (Input.GetKeyDown(KeyCode.R)) 		{currentState = State.corridor_1;}
	}
	
	private void stairs_2()
    {
		textComponent.text = "You feel smug for picking the closet door open, and are still armed with " +
					"a hairclip (now badly bent). Even these achievements together don't give " +
					"you the courage to climb up the staris to your death!\n\n" +
					"Press R to Return to the corridor";
		if (Input.GetKeyDown(KeyCode.R)) 		{currentState = State.corridor_2;}
	}
	
	private void cell ()
    {
		textComponent.text = "You are in a prison cell, and you want to escape. There are " +
					"some dirty sheets on the bed, a mirror on the wall, and the door " +
					"is locked from the outside.\n\n" +
					"Press S to view Sheets, M to view Mirror and L to view Lock" ;
		if 		(Input.GetKeyDown(KeyCode.S)) 	{currentState = State.sheets_0;}
		else if (Input.GetKeyDown(KeyCode.M)) 	{currentState = State.mirror;}
		else if (Input.GetKeyDown(KeyCode.L)) 	{currentState = State.lock_0;}
    }
    
	private void mirror()
    {
		textComponent.text = "The dirty old mirror on the wall seems loose.\n\n" +
					"Press T to Take the mirror, or R to Return to cell" ;
		if 		(Input.GetKeyDown(KeyCode.T)) 	{currentState = State.cell_mirror;}
		else if (Input.GetKeyDown(KeyCode.R)) 	{currentState = State.cell;}
    }
    
	private void cell_mirror()
    {
		textComponent.text = "You are still in your cell, and you STILL want to escape! There are " +
					"some dirty sheets on the bed, a mark where the mirror was, " +
					"and that pesky door is still there, and firmly locked!\n\n" +
					"Press S to view Sheets, or L to view Lock" ;
		if 		(Input.GetKeyDown(KeyCode.S)) 	{currentState = State.sheets_1;}
		else if (Input.GetKeyDown(KeyCode.L)) 	{currentState = State.lock_1;}
    }
   
    private void sheets_0 ()
    {
		textComponent.text = "You can't believe you sleep in these things. Surely it's " +
					"time somebody changed them. The pleasures of prison life " +
					"I guess!\n\n" +
					"Press R to Return to roaming your cell" ;
        if (Input.GetKeyDown(KeyCode.R)) 		{currentState = State.cell;}
    }
    
	private void sheets_1()
    {
		textComponent.text = "Holding a mirror in your hand doesn't make the sheets look " +
					"any better.\n\n" +
					"Press R to Return to roaming your cell" ;
		if (Input.GetKeyDown(KeyCode.R)) 		{currentState = State.cell_mirror;}
    }
    
    private void lock_0()
    {
		textComponent.text = "This is one of those button locks. You have no idea what the " +
					"combination is. You wish you could somehow see where the dirty " +
					"fingerprints were, maybe that would help.\n\n" +
					"Press R to Return to roaming your cell" ;
		if (Input.GetKeyDown(KeyCode.R)) 		{currentState = State.cell;}
    }
    
	private void lock_1()
    {
		textComponent.text = "You carefully put the mirror through the bars, and turn it round " +
					"so you can see the lock. You can just make out fingerprints around " +
					"the buttons. You press the dirty buttons, and hear a click.\n\n" +
					"Press O to Open, or R to Return to your cell" ;
		if 		(Input.GetKeyDown(KeyCode.O)) 	{currentState = State.corridor_0;}
		else if (Input.GetKeyDown(KeyCode.R)) 	{currentState = State.cell_mirror;}
    }
    
	private void corridor_0()
    {
		textComponent.text = "You're out of your cell, but not out of trouble." +
					"You are in the corridor, there's a closet and some stairs leading to " +
					"the courtyard. There's also various detritus on the floor.\n\n" +
					"C to view the Closet, F to inspect the Floor, and S to climb the stairs";
		if 		(Input.GetKeyDown(KeyCode.S)) 	{currentState = State.stairs_0;}
		else if (Input.GetKeyDown(KeyCode.F)) 	{currentState = State.floor;}
		else if (Input.GetKeyDown(KeyCode.C)) 	{currentState = State.closet_door;}  
	}
}
