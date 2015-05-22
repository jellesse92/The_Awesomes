using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LogicSetController : MonoBehaviour {

	//For applying logic
	GameController gc;							//Accesses control script to get variable information
	int currentLap = -1;						//To prevent reset if player turns camera away from gates and board

	Text logicPanelText;						//For changing what displays in the logic text
	string logicText = "";						//For setting string display on user incoming logic display and billboard


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
			gc.SetLogicText("moo");
			logicPanelText.text = " ASDASd";
			GenerateFunction();
	}

	void GenerateFunction(){
		int random_num = 0;

		switch(random_num){
			case 0:
				logicPanelText.text = "\tRaining = Something";
				gc.SetLogicText("Raining = Something\n" +
				                "\tGate1 =");
				break;

			default: break;
		}
	}


}
