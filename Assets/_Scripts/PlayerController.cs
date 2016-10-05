using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
	Animator anim;
	SpriteRenderer spriteRender;
	private Sprite[] playerSpritesBlack;
	private Sprite[] playerSpritesWhite;
	public RuntimeAnimatorController[] aspectAnimators;
	public bool PlayerIsOnLeft;
	public static bool PlayerMovementIsPaused;
	private int spriteCycleLeft = 0;	
	private int spriteCycleRight = 0;
	private float cameraWidth;
	
	// Use this for initialization
	void Start ()
	{
		cameraWidth = Camera.main.transform.position.x * 2;
		anim = GetComponent<Animator> ();
		spriteRender = GetComponent<SpriteRenderer> ();
		playerSpritesBlack = Resources.LoadAll<Sprite> ("Black");
		playerSpritesWhite = Resources.LoadAll<Sprite> ("White");
		GameObject.Find ("PlayerLeftStartPosition").transform.position = new Vector2 (cameraWidth * .25f, this.transform.position.y);
		GameObject.Find ("PlayerRightStartPosition").transform.position = new Vector2 (cameraWidth * .75f, this.transform.position.y);
		if (this.gameObject.name == "PlayerLeft") {
			this.transform.position = new Vector2 (cameraWidth * .125f, this.transform.position.y);
		} 
		if (this.gameObject.name == "PlayerRight") {
			this.transform.position = new Vector2 (cameraWidth * .875f, this.transform.position.y);
		}
		
		if ((Camera.main.aspect) < .67f && (Camera.main.aspect) > .65f) { //2:3
			anim.runtimeAnimatorController = aspectAnimators [0];
		} else if ((Camera.main.aspect) < .77f && (Camera.main.aspect) > .72f) { //3:4
			anim.runtimeAnimatorController = aspectAnimators [1];
		} else if ((Camera.main.aspect) < .58f && (Camera.main.aspect) > .55f) { //9:16
			anim.runtimeAnimatorController = aspectAnimators [2];
		} else if ((Camera.main.aspect) < .64f && (Camera.main.aspect) > .61f) { //10:16
			anim.runtimeAnimatorController = aspectAnimators [3];
		} else {
			anim.runtimeAnimatorController = aspectAnimators [2];
		}
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (spriteCycleLeft < playerSpritesWhite.Length) {
			if (this.gameObject.name == "PlayerLeft") {
				this.spriteRender.sprite = playerSpritesWhite [spriteCycleLeft];
				spriteCycleLeft++;
			} 	
		} else {
			spriteCycleLeft = 0;
		}
		
		if (spriteCycleRight < playerSpritesBlack.Length) {
			if (this.gameObject.name == "PlayerRight") {
				this.spriteRender.sprite = playerSpritesBlack [spriteCycleRight];
				spriteCycleRight++;
			} 
		} else {
			spriteCycleRight = 0;
		}
	
	}
	
	public void Move ()
	{
		if (!PlayerMovementIsPaused) {
			if (PlayerIsOnLeft) {
				anim.CrossFade ("PlayerMoveToRight", .33f);
				PlayerIsOnLeft = !PlayerIsOnLeft;		
			} else if (!PlayerIsOnLeft) {
				anim.CrossFade ("PlayerMoveToLeft", .33f);
				PlayerIsOnLeft = !PlayerIsOnLeft;
			}
		}
	}
	
	public void ResetPosition (string name)
	{
		if (name.Equals ("Left")) {
			if (!GameObject.Find ("PlayerLeft").GetComponent<PlayerController> ().PlayerIsOnLeft) {
				anim.Play ("PlayerLeftReset");
				anim.Play ("Default");
				GameObject.Find ("PlayerLeft").GetComponent<PlayerController> ().PlayerIsOnLeft = true;
			}
		} else if (name.Equals ("Right")) {
			if (GameObject.Find ("PlayerRight").GetComponent<PlayerController> ().PlayerIsOnLeft) {
				anim.Play ("PlayerRightReset");
				anim.Play ("Default");
				GameObject.Find ("PlayerRight").GetComponent<PlayerController> ().PlayerIsOnLeft = false;
			}
		}
	}
}
