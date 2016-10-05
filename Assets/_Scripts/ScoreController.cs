using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{
	
	private Text inGameScoreText;
	private Text gameOverScoreText;
	private Text gameOverHighScoreText;
	private int highScore;
	public static int scoreInt;
	
	// Use this for initialization
	void Start ()
	{	
		if (!PlayerPrefs.HasKey ("highScore")) { //If player doesn't have a high score then set it to zero
			PlayerPrefs.SetInt ("highScore", 0);
		}
		
		inGameScoreText = GameObject.Find ("InGameScoreText").GetComponent<Text> ();
		gameOverScoreText = GameObject.Find ("GameOverScoreText").GetComponent<Text> ();
		gameOverHighScoreText = GameObject.Find ("GameOverHighScoreText").GetComponent<Text> ();
		scoreInt = 0;
	}
	
	// Update is called once per frame
	void Update ()
	{
		inGameScoreText.text = " " + scoreInt.ToString ();
		gameOverScoreText.text = "Score: " + scoreInt.ToString ();
		
		highScore = PlayerPrefs.GetInt ("highScore"); //Gets the high score and stores it in an int
		gameOverHighScoreText.text = "Best: " + highScore.ToString ();
		if (scoreInt > highScore) {
			PlayerPrefs.SetInt ("highScore", scoreInt);
		}
	}
}
