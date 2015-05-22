using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

	//In-Game Control Variables
	public int rangeEnd = 5;
	public string breakBool = "==";				//Boolean condition to break out of loop early
	public int breakCondition = 7;				//Condition to break out of loop early

	//In-Game Player Variables
	public int lapCount = 0;					//Counts number of laps player has made
	public int playerVar = 0;
	public bool isRaining = false;

	//In-Game Objects
	public GameObject logicPanel;				//For controlling when Logic Gate panel appears
	GameObject fireWall;						//Prevents player from going over loop iteration
	GameObject rain;							//Rain effect that activates if raining
	

	//GUI Text
	public InstantGuiTextArea functionText;		//GUI Text for Function
	public InstantGuiTextArea debugText;		//GUI Text for Debug
	public InstantGuiTextArea shellText;		//GUI Text for Shell
	public InstantGuiTextArea logicText;		//GUI Text for Logic


	//Static Strings
	static string funcStrFor = "for Lap in range ({0}):\n\tKeepRacing (Player_Var)\n" +
		"\tif Player_Var {1} {2}:\n" +
		"\t\tPickUpToBreak ( )\n" +
		"\telse:\n" +
		"\t\tprint('Keep going!')";
	static string gameVar = "Lap = {0}\nPlayer_Var = {1}\nisRaining = {2}";
	static string printStatement = "Keep going!\n";

	//IMPORTANT. Always have the GameObjects with the tag Firewall/Rain if using GameController script in
	//scene
	void Awake(){
		AttachGameObject(ref fireWall, "Firewall");
		AttachGameObject(ref rain, "Rain");
		AttachGameObject(ref logicPanel, "LogicPanel");
	}

	// Use this for initialization
	void Start () {
		functionText.rawText = string.Format(funcStrFor,rangeEnd,breakBool,breakCondition);
		UpdateDebugText();
		shellText.rawText = "";
		logicText.rawText = "";
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		UpdateDebugText();

	
		//BEGIN OF TEST. [REMOVE]
		//Debug.Log(BreakConditionMet());
		UpdateRainState(isRaining);
		functionText.text = string.Format(funcStrFor,rangeEnd,breakBool,breakCondition);
		if(lapCount < 3)
			IncLap();
		if(lapCount == rangeEnd)
			fireWall.SetActive(true);
		//END OF TEST
	}

	//Attaches gameobject with given name to given gameobject. 
	void AttachGameObject(ref GameObject obj, string findName){
		obj = GameObject.FindWithTag(findName);
		obj.SetActive(false);
	}

	//Updates GUI text display for the debugger view
	public void UpdateDebugText(){
		debugText.rawText = string.Format(gameVar,lapCount,playerVar,isRaining);
	}

	public void SetLogicText(string str){
		logicPanel.SetActive(true);
		logicText.rawText = str;
	}

	//Increments the Lap count and prints the debug string
	public void IncLap(){
		lapCount++;
		shellText.text = shellText.text + printStatement;
	}

	public void UpdateRainState(bool state){
		isRaining = state;
		rain.SetActive(state);
		UpdateDebugText();
	}

	//Returns true if break condition is met. False if break condition is not met
	public bool BreakConditionMet(){
		switch(breakBool){
			case "==": return playerVar == breakCondition;
			case ">": return playerVar > breakCondition;
			case "<": return playerVar < breakCondition;
			case ">=": return playerVar >= breakCondition;
			case "<=": return playerVar <= breakCondition;
			case "!=": return playerVar != breakCondition;
			default: return false;
		}
	}


}
