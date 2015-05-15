using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

	//In-Game Control Variables
	public int rangeEnd = 5;
	public string breakBool = "==";
	public int breakCondition = 7;				//Condition to break out of loop early

	//In-Game Player Variables
	public int lapCount = 0;					//Counts number of laps player has made
	public int playerVar = 0;
	public bool isRaining = false;

	//In-Game Objects
	GameObject fireWall;						//Prevents player from going over loop iteration


	//GUI Text
	public Text functionText;					//GUI Text for Function
	public Text debugText;						//GUI Text for Debug
	public Text shellText;						//GUI Text for Shell

	//Static Strings
	static string funcStrFor = "for Lap in range ({0}):\n\tKeepRacing (Player_Var)\n" +
		"\tif Player_Var {1} {2}:\n\t\tbreak";
	static string gameVar = "Lap = {0}\nPlayer_Var = {1}\nisRaining = {2}";
	static string printStatement = "Keep going!\n";

	void Awake(){
		fireWall = GameObject.FindWithTag("Firewall");
		fireWall.SetActive(false);
	}

	// Use this for initialization
	void Start () {
		functionText.text = string.Format(funcStrFor,rangeEnd,breakBool,breakCondition);
		UpdateDebugText();
		shellText.text = "";
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		UpdateDebugText();

	
		//BEGIN OF TEST. [REMOVE]
		functionText.text = string.Format(funcStrFor,rangeEnd,breakBool,breakCondition);
		if(lapCount < 3)
			IncLap();
		if(lapCount == rangeEnd)
			fireWall.SetActive(true);
		//END OF TEST
	}

	//Updates GUI text display for the debugger view
	public void UpdateDebugText(){
		debugText.text = string.Format(gameVar,lapCount,playerVar,isRaining);
	}

	//Increments the Lap count and prints the debug string
	public void IncLap(){
		lapCount++;
		shellText.text = shellText.text + printStatement;
	}




}
