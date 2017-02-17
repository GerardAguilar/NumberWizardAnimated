using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Use Anima2D to have an animated character react to a win.
//Just need to make the teeth turn off after animation

public class NumberWizard : MonoBehaviour {

    GameObject jaw;
    
    int max;
    int min;

    int guess;

	// Use this for initialization
    void Start () {
        jaw = GameObject.Find("Jaw");
        jaw.SetActive(false);
        StartGame();
	}

	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("down"))
        {
            //print("Down arrow was pressed.");
            max = guess;
            NextGuess();
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            //print("Up arrow was pressed.");
            min = guess;
            NextGuess();
        }
        else if (Input.GetKeyDown(KeyCode.Return)) {
            print("I won!");            
            jaw.SetActive(true);
            
            //StartGame(); // placed in the JawScript to be accessible through the Animation Window
        }
    }

    public void StartGame()
    {
        jaw.SetActive(false);
        print("============================");
        print("Welcome to Number Wizard");
        print("Pick a number in your head, but don't tell me!");

        max = 1001;
        min = 1;
        guess = 500;

        print("The highest number you can pick is " + max);
        print("The lowest number you can pick is " + min);

        print("Is the number higher or lower than " + guess + "?");
        print("Up = higher, down = lower, return = equal");
    }

    void NextGuess()
    {
        guess = (max + min) / 2;//binary splitting
        print("Higher or lower than " + guess + "?");
        print("Up = higher, down = lower, return = equal");
    }
}
