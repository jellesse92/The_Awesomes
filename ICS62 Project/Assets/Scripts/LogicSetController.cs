using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LogicSetController : MonoBehaviour {

	//For applying logic
	GameController gc;							//Accesses control script to get variable information
	int currentLap = -1;						//To prevent reset if player turns camera away from gates and board

	Text logicPanelText;						//For changing what displays in the logic text
	string logicText = "";						//For setting string display on user incoming logic display and billboard
	bool[] Answers;

	// Use this for initialization
	void Start () {
		gc = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
		logicPanelText = transform.Find("Logic Board/LogicBoardPanel/LogicBoardText").gameObject.GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {


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

	void AnswerQuestion(int index){
		ShowResult();
	}

	void GenerateFunction(){
		int random_num = 0;

		switch(random_num){
			case 0:
				int compareTo = 5;
				logicPanelText.text = string.Format("\tRaining = eval('{0}' + Gate[n] + 'Player_Var')",compareTo);
				gc.SetLogicText(string.Format("Raining =\n " +
			                              "\teval('5' + ___ + '{0}')\n" +
								"\n\tFill in the Blank:\n" +
				                "\tGate[0] = '<'\n" +
				                "\tGate[1] = '=='\n" +
				                "\tGate[2] = '>'\n",gc.playerVar));
				break;

			default: break;
		}
	}


}
