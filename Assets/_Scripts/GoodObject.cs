using UnityEngine;
using System.Collections;

public class GoodObject : MonoBehaviour
{
	PauseController pauseController;
	Animator anim;
	public AudioClip clip;
	
	// Use this for initialization
	void Start ()
	{
		pauseController = GameObject.Find ("MenuManager").GetComponent<PauseController> ();
		anim = this.GetComponent<Animator> ();
	}
	
	void OnTriggerEnter2D (Collider2D collider)
	{
		if (collider.gameObject.name == "LoseCollider") {
			pauseController.PauseGame ();
			StartCoroutine (GameOverBlink ());
		} else if (collider.gameObject.name == "PlayerLeft" || collider.gameObject.name == "PlayerRight") {
			ScoreController.scoreInt++;
			if (PlayerPrefs.GetInt ("allowSFXToPlay") == 1) {
				AudioSource.PlayClipAtPoint (clip, this.transform.position, .50f);
			}			
			if (ObjectController.currentObjectVelocity < ObjectController.maxObjectVelocity) {
				ObjectController.currentObjectVelocity += 14;
				//print (ObjectController.currentObjectVelocity + "  " + "Turn number: " + ScoreController.scoreInt);
			}	
			if (SpawnManager.currentSpawnWaitTime > SpawnManager.minSpawnWaitTime) {
				SpawnManager.currentSpawnWaitTime -= .007f;
			}
			Destroy (this.gameObject);
		}
	} 
	
	IEnumerator GameOverBlink ()
	{
		anim.Play ("Lose_Blink");
		yield return new WaitForSeconds (0.75f);
		pauseController.HidePauseUI ();
		pauseController.DisplayGameOverUI ();
	}
}
