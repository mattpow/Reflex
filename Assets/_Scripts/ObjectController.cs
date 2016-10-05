using UnityEngine;
using System.Collections;

public class ObjectController : MonoBehaviour
{
	public static bool ObjectMovementIsPaused;
	private Transform fallingObject;
	public static float maxObjectVelocity = 1600;	
	public static float currentObjectVelocity = 900;
	
	// Use this for initialization
	void Start ()
	{
		fallingObject = this.transform;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (!ObjectMovementIsPaused) {
			//fallingObject.position -= new Vector3 (0f, currentObjectVelocity * Time.deltaTime);
			fallingObject.position = Vector3.Lerp (fallingObject.position, fallingObject.position - new Vector3 (0f, currentObjectVelocity * Time.deltaTime), 1);
		}
	}
}
