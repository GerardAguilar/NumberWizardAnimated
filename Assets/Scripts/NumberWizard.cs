using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

//Use Anima2D to have an animated character react to a win.
//Just need to make the teeth turn off after animation

public class NumberWizard : MonoBehaviour {

    GameObject jaw;
    int max;
    int min;
    int guess;
    int maxGuessesAllowed = 7;
    bool start = false;
    bool initial = false;
    Animator anim;

    public Text guessText;
    public Text instructions;
    public GameObject startButton;
    public GameObject higherButton;
    public GameObject lowerButton;
    public GameObject correctButton;



	// Use this for initialization
    void Start () {
        //jaw = GameObject.Find("Jaw");
        //jaw.SetActive(false);
        guessText = GameObject.Find("GuessText").GetComponent<Text>();
        instructions = GameObject.Find("Instructions").GetComponent<Text>();
        startButton = GameObject.Find("StartButton");
        higherButton = GameObject.Find("HigherButton");
        lowerButton = GameObject.Find("LowerButton");
        correctButton = GameObject.Find("CorrectButton");

        anim = GameObject.Find("Computer").GetComponent<Animator>();

        InitialInstructions();
	}

    public void InitialInstructions() {

        //max = 1001;
        max = 1000;
        min = 1;

        //jaw.SetActive(false);
        string str =
        "============================\n" +
        "Welcome to Number Wizard\n" +
        "Pick a number in your head, but don't tell me!\n\n" +

        "The highest number you can pick is " + (max) + "\n" +
        "The lowest number you can pick is " + min;        

        instructions.text = str;

        higherButton.SetActive(false);
        lowerButton.SetActive(false);
        correctButton.SetActive(false);
    }

    public void StartGame()
    {
        startButton.SetActive(false);
        higherButton.SetActive(true);
        lowerButton.SetActive(true);
        correctButton.SetActive(true);
        guess = Random.Range(1, 1000);
        ShowGuess();
        
    }

    void ShowGuess() {
        guessText.text = "Is it " + guess + "?";
    }

    public void GuessIsTooHigh() {
        max = guess;
        anim.SetTrigger("TooHigh");
        //NextGuess();
        RandomGuess();
        ShowGuess();
    }

    public void GuessIsTooLow(){
        min = guess;
        anim.SetTrigger("TooLow");
        //NextGuess();
        RandomGuess();
        ShowGuess();
    }

    public void GuessIsCorrect()
    {
        //will be handled by changing scenes
    }

    void NextGuess()
    {      
        guess = (max + min) / 2;//binary splitting
        CheckGuessCount();
    }

    void RandomGuess() {
        guess = (int)Random.Range(min, max+1);//max param is exclusive, hence the +1
        CheckGuessCount();        
    }

    void CheckGuessCount() {
        maxGuessesAllowed -= 1;
        if (maxGuessesAllowed <= 0)
        {
            SceneManager.LoadScene("Win");
        }
    }
}
