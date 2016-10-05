using UnityEngine;
using System.Collections;

public class BadObject : MonoBehaviour
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
		if (collider.gameObject.name == "BadObjectShredder") {
			Destroy (this.gameObject);
		} else if (collider.gameObject.name == "PlayerLeft" || collider.gameObject.name == "PlayerRight") {
			pauseController.PauseGame ();
			StartCoroutine (GameOverBlink ());
			if (PlayerPrefs.GetInt ("allowSFXToPlay") == 1) {
				AudioSource.PlayClipAtPoint (clip, this.transform.position, .50f);
			}
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
