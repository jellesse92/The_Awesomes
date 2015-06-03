using UnityEngine;
using System.Collections;

public class PauseController : MonoBehaviour {

	public GameObject PausePanel;
	bool Paused = false;

	// Use this for initialization
	void Awake () {
		PausePanel.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.P)){
			if (Paused){
				Time.timeScale = 1.0f;
				Paused = false;
				PausePanel.SetActive(false);
			}
			else{
				Time.timeScale = 0f;
				Paused = true;
				PausePanel.SetActive(true);
			}
		}
	}
}
