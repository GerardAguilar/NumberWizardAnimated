using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JawScript : MonoBehaviour {

    public NumberWizard numWiz;

	// Use this for initialization
	void Awake () {
        numWiz = GameObject.Find("NumberWizard").GetComponent<NumberWizard>();
        
	}

    public void RestartGame() {
        numWiz.StartGame();
    }
	
}
