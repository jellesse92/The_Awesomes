using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LogicSetController : MonoBehaviour {

	//For applying logic
	GameController gc;									//Accesses control script to get variable information
	int currentLap = -1;								//To prevent reset if player turns camera away from gates and board
	public bool[] Answers;								//Applies logic for each gate
	
	Text logicPanelText;								//For changing what displays in the logic text
	int Question = 0;									//Question type
															//0 == Control Raining Condition
															//1 == Change PlayerVar
	
	// Use this for initialization
	void Start () {
		gc = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
		logicPanelText = transform.Find("Logic Board/LogicBoardPanel/LogicBoardText").gameObject.GetComponent<Text>();
	}

	//Called every time an element of the gate becomes visible from the camera view. May reset every time
	//its called without the "if" statement that allows the reset only when the player has made another lap
	public void ActivateLogicSet(){
		if(currentLap != gc.lapCount)
			currentLap = gc.lapCount;
			GenerateFunction();
	}

	//After player passes under the gate, briefly shows the result of the answer
	//For example Raining = Gate[n](player) becomes Raining = False (Assuming Gate[n](player) was a false statement)
	public void ShowResult(){

	}

	public void AnswerQuestion(bool state){
		if(Question == 0)							//If the question was to set Raining state,
			gc.UpdateRainState(state);				//set raining state based on bool answer
		ShowResult();
	}


	//WIP
	//Generates random function for billboard
	void GenerateFunction(){
		int random_num = 0;
		int compareTo = Random.Range(0,10);
		string[] setGateValues = {"","",""};				
		switch(Question){
			case 0:
				logicPanelText.text = string.Format("\tRaining = eval('{0}' + Gate[ n ] + 'Player_Var')",compareTo);
				gc.SetLogicText(string.Format("Raining =\n " +
					                          "\teval('{0}' + Gate[ n ] + '{1}')\n\n" +
					                          "\tGate = [\"<\", \"==\", \">\"]\n" +
											  "\n\tSelect the Index\n",compareTo,gc.playerVar));
				break;
			default: break;
		}
	}
	/***
	gc.SetLogicText(string.Format("Raining =\n " +
	                              "\teval('{0}' + ___ + '{1}')\n" +
	                              "\tGate = [\"<\", \"==\", \">\"]\n" +
	                              "\n\tFill in the Blank:\n" +
	                              "\tGate[0] = '<'\n" +
	                              "\tGate[1] = '=='\n" +
	                              "\tGate[2] = '>'\n",compareTo,gc.playerVar));
	                              ***/




}
