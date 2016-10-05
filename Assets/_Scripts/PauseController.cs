using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PauseController : MonoBehaviour
{	
	Animator pauseMenuAnim;
	Animator homeMenuAnim;
	Animator gameOverMenuAnim;
	CanvasGroup playerControl;
	CanvasGroup pauseMenu;
	CanvasGroup homeMenu;
	CanvasGroup gameOverMenu;
	Text inGameScoreText;
	
	void Start ()
	{
		pauseMenuAnim = GameObject.Find ("PauseMenuUIGroup").GetComponent<Animator> ();
		homeMenuAnim = GameObject.Find ("HomeMenuUIGroup").GetComponent<Animator> ();
		gameOverMenuAnim = GameObject.Find ("GameOverMenuUIGroup").GetComponent<Animator> ();
		
		playerControl = GameObject.Find ("PlayerControlUIGroup").GetComponent<CanvasGroup> ();
		pauseMenu = GameObject.Find ("PauseMenuUIGroup").GetComponent<CanvasGroup> ();
		homeMenu = GameObject.Find ("HomeMenuUIGroup").GetComponent<CanvasGroup> ();
		gameOverMenu = GameObject.Find ("GameOverMenuUIGroup").GetComponent<CanvasGroup> ();
		
		inGameScoreText = GameObject.Find ("InGameScoreText").GetComponent<Text> ();
				
		pauseMenu.blocksRaycasts = false;
		pauseMenu.interactable = false;
		homeMenu.blocksRaycasts = false;
		homeMenu.interactable = false;
		gameOverMenu.blocksRaycasts = false;
		gameOverMenu.interactable = false;
		
		DisplayHomeUI ();
		PauseGame ();		
		
		Application.targetFrameRate = 60;
	}
	
	public void PauseGame ()
	{
		ObjectController.ObjectMovementIsPaused = true;
		SpawnManager.SpawnObjectsIsPaused = true;
		PlayerController.PlayerMovementIsPaused = true;
	}
	
	public void UnPauseGame ()
	{
		ObjectController.ObjectMovementIsPaused = false;
		SpawnManager.SpawnObjectsIsPaused = false;
		PlayerController.PlayerMovementIsPaused = false;
	}
	
	public void ResetGame ()
	{
		//Reset Score
		ScoreController.scoreInt = 0;
		
		//Reset Player Locations
		GameObject.Find ("PlayerLeft").GetComponent<PlayerController> ().ResetPosition ("Left");
		GameObject.Find ("PlayerRight").GetComponent<PlayerController> ().ResetPosition ("Right");
		
		//Delete all old objects
		GameObject[] fallingObjects = GameObject.FindGameObjectsWithTag ("Object");
		for (int i = 0; i < fallingObjects.Length; i++) {
			Destroy (fallingObjects [i]);
		}
		
		ObjectController.currentObjectVelocity = 900;
		SpawnManager.currentSpawnWaitTime = SpawnManager.maxSpawnWaitTime;
		
		//Reseting spawn
	}	
	
	public void DisplayPauseUI ()
	{
		pauseMenuAnim.Play ("UIFadeIn");
		playerControl.interactable = false;
		playerControl.blocksRaycasts = false;
		inGameScoreText.enabled = false;
		pauseMenu.blocksRaycasts = true;
		pauseMenu.interactable = true;
	}
	
	public void HidePauseUI ()
	{
		pauseMenuAnim.Play ("UIFadeOut");
		playerControl.interactable = true;
		playerControl.blocksRaycasts = true;	
		inGameScoreText.enabled = true;
		pauseMenu.blocksRaycasts = false;
		pauseMenu.interactable = false;
	}
	
	public void DisplayHomeUI ()
	{
		homeMenuAnim.Play ("UIFadeIn");
		playerControl.interactable = false;
		playerControl.blocksRaycasts = false;
		inGameScoreText.enabled = false;
		homeMenu.blocksRaycasts = true;
		homeMenu.interactable = true;
	}
	
	public void HideHomeUI ()
	{
		homeMenuAnim.Play ("UIFadeOut");
		playerControl.interactable = true;
		playerControl.blocksRaycasts = true;
		inGameScoreText.enabled = true;
		homeMenu.blocksRaycasts = false;
		homeMenu.interactable = false;
	}
	
	public void DisplayGameOverUI ()
	{
		gameOverMenuAnim.Play ("UIFadeIn");
		playerControl.interactable = false;
		playerControl.blocksRaycasts = false;
		inGameScoreText.enabled = false;
		gameOverMenu.blocksRaycasts = true;
		gameOverMenu.interactable = true;
	}
	
	public void HideGameOverUI ()
	{
		gameOverMenuAnim.Play ("UIFadeOut");
		playerControl.interactable = true;
		playerControl.blocksRaycasts = true;
		inGameScoreText.enabled = true;	
		gameOverMenu.blocksRaycasts = false;
		gameOverMenu.interactable = false;
	}
}
