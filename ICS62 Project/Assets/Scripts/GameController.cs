﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

	//In-Game Control Variables
	public int rangeEnd = 5;
	public string breakBool = "==";				//Boolean condition to break out of loop early
	public int breakCondition = 7;				//Condition to break out of loop early
	VehicleMovement vm;							//For controlling exit for player
	bool breakOnce;									//For triggering break condition only once

	//In-Game Player Variables
	public int lapCount = 0;					//Counts number of laps player has made
	public int playerVar = 0;
	public bool isRaining = false;

	//In-Game Track Objects
	public GameObject logicPanel;				//For controlling when Logic Gate panel appears
	GameObject fireWall;						//Prevents player from going over loop iteration
	GameObject rain;							//Rain effect that activates if raining
	GameObject startLine;						//Controls if startLine is still a trigger
	GameObject vehicle;
	

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
	static string gameVar = "Lap = {0}\nPlayer_Var = {1}\nisRaining = {2}\nTime = {3:0.0}";
	static string printStatement = "Keep going!\n";

	//IMPORTANT. Always have the GameObjects with the tag Firewall/Rain if using GameController script in
	//scene
	void Awake(){
		AttachGameObject(ref rain, "Rain");
		AttachGameObject(ref logicPanel, "LogicPanel");
		fireWall = GameObject.FindGameObjectWithTag("Firewall");
		startLine = GameObject.FindGameObjectWithTag("StartLine");
		vm = GameObject.FindGameObjectWithTag("Player").GetComponent<VehicleMovement>();
		vehicle = GameObject.FindGameObjectWithTag("Player");
	}

	// Use this for initialization
	void Start () {
		functionText.rawText = string.Format(funcStrFor,rangeEnd,breakBool,breakCondition);
		UpdateDebugText();
		shellText.rawText = "";
		logicText.rawText = "";
		vm.escape = false;
		breakOnce = false;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		UpdateDebugText();
		UpdateTrackState();
		UpdateRainState(isRaining);
	}

	void UpdateTrackState(){
		if (lapCount >= rangeEnd || BreakConditionMet()){
			startLine.GetComponent<MeshCollider>().isTrigger = false;
			fireWall.SetActive(false);
			vm.escape = true;
		}
		if (BreakConditionMet() && breakOnce == false){
			vm.escape = true;
			vehicle.transform.position = GameObject.Find("BreakPortal").transform.position;
			vehicle.transform.eulerAngles = new Vector3(358.0f, 233.0f ,6.0f);
			breakOnce = true;
		}
	}

	//Attaches gameobject with given name to given gameobject. 
	void AttachGameObject(ref GameObject obj, string findName){
		obj = GameObject.FindWithTag(findName);
		obj.SetActive(false);
	}

	//Updates GUI text display for the debugger view
	public void UpdateDebugText(){
		debugText.rawText = string.Format(gameVar,lapCount,playerVar,isRaining,Time.fixedTime);
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
