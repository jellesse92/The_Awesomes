using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LogicSetController : MonoBehaviour {

	//For applying logic
	GameController gc;									//Accesses control script to get variable information
	int currentLap = -1;								//To prevent reset if player turns camera away from gates and board
	public bool sameLap = false;						//To prevent reapplying logic for iris triggers on same lap
	public bool[] Answers;								//Applies logic for each gate
	string[] compValues = {"<","==",">"};				//Gate values for comparison
	
	Text logicPanelText;								//For changing what displays in the logic text
	int compareTo;										//Value to compare to player variable
	int wasPlayerVar;									//Gets player var at time question initiated
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


	IEnumerator ShowResult(int state){
		switch(Question){
		case 0:
			gc.SetLogicText(string.Format("RESULT:\n" +
			    "Gate[{4}] = '{1}'\n" +
				"Raining = " +
			    "{0} {1} {2}\n\n" +
			    "Setting Raining to: {3}\n\n", compareTo,compValues[state] ,gc.playerVar,Answers[state],state));
			break;
		default: break;
		}
	
		yield return new WaitForSeconds(6.0f);
		gc.logicPanel.SetActive(false);
	}

	public void AnswerQuestion(int index){
		if(Question == 0)							//If the question was to set Raining state,
			gc.UpdateRainState(Answers[index]);				//set raining state based on bool answer
		sameLap = true;
		StartCoroutine(ShowResult(index));
	}


	//WIP
	//Generates random function for billboard
	void GenerateFunction(){
		Question = Random.Range(0,0);
		compareTo = Random.Range(0,10);
		string[] setGateValues = {"","",""};				
		switch(Question){
			case 0:
				logicPanelText.text = string.Format("\tRaining = eval('{0}' + Gate[ n ] + 'Player_Var')",compareTo);
				gc.SetLogicText(string.Format("eval( Raining = " +
			                              "'{0}' + _ + '{1}')\n" +
			                              "\n\tGate = [\"<\", \"==\", \">\"]\n\n" +
			                              "\tFill in the Blank:\n" +
			                              "\tGate[0] = '{2}'\n" +
			                              "\tGate[1] = '{3}'\n" +
			                              "\tGate[2] = '{4}'\n",compareTo,gc.playerVar,compValues[0],compValues[1],compValues[2]));
				break;
		case 1:
			default: break;
		}
		wasPlayerVar = gc.playerVar;
		GenerateTruthValues();
	}

	void GenerateTruthValues(){
		switch(Question){
			case 0:
				Answers[0] = compareTo < wasPlayerVar;
				Answers[1] = compareTo == wasPlayerVar;
				Answers[2] = compareTo > wasPlayerVar;
				break;
			default: break;
		}
	}




}
