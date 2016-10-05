using UnityEngine;
using System.Collections;

public class BackgroundController : MonoBehaviour
{
	private int deviceWidth;
	private int deviceHeight;
	public Sprite background2by3;
	public Sprite background3by4;
	public Sprite background9by16;
	public Sprite background10by16;
	private SpriteRenderer backgroundSpriteRenderer;
	// Use this for initialization
	void Start ()
	{
		backgroundSpriteRenderer = this.GetComponent<SpriteRenderer> ();

		if ((Camera.main.aspect) < .58f && (Camera.main.aspect) > .55f) { //9:16
			backgroundSpriteRenderer.sprite = background9by16; 
		} else if ((Camera.main.aspect) < .64f && (Camera.main.aspect) > .61f) { //10:16 
			backgroundSpriteRenderer.sprite = background10by16;
		} else if ((Camera.main.aspect) < .67f && (Camera.main.aspect) > .65f) { //2:3
			backgroundSpriteRenderer.sprite = background2by3;
		} else if ((Camera.main.aspect) < .77f && (Camera.main.aspect) > .72f) { //3:4
			backgroundSpriteRenderer.sprite = background3by4;
		} else {
			backgroundSpriteRenderer.sprite = background9by16;
		}
		Camera.main.transform.position = new Vector3 (960 * Camera.main.aspect, Camera.main.transform.position.y, -10f);
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}
}
