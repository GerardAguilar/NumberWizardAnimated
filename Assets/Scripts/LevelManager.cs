using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour{

    public void LoadLevel(string name) {
        //Debug.Log("Level load requested for : "+name);
        //Application.LoadLevel(name);
        SceneManager.LoadScene(name);
    }

    public void QuitRequest() {
        Debug.Log("Quit requested.");
        Application.Quit();//doesn't work on web
        //works on pc and consoles
    }


}