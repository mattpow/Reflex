using UnityEngine;
using System.Collections;

public class SpawnManager : MonoBehaviour
{

	public GameObject goodObjectLeft;
	public GameObject goodObjectRight;
	public GameObject badObjectLeft;
	public GameObject badObjectRight;
	private float cameraWidth;
	private float trackOneXPos;
	private float trackTwoXPos;
	private float trackThreeXPos;
	private float trackFourXPos;
	private float StartingYPos = 3000f;
	public static float maxSpawnWaitTime = .8f;
	public static float minSpawnWaitTime = .45f;
	public static float currentSpawnWaitTime;
	private Vector2 objectPosOne;
	private Vector2 objectPosTwo;
	public static bool SpawnObjectsIsPaused;
	public static bool coroutineActive;
	
	// Use this for initialization
	void Start ()
	{
		cameraWidth = Camera.main.transform.position.x * 2;
		trackOneXPos = cameraWidth * .125f;
		trackTwoXPos = cameraWidth * .375f;
		trackThreeXPos = cameraWidth * .625f;
		trackFourXPos = cameraWidth * .875f;		
	}
	
	void Update ()
	{
		if (!SpawnObjectsIsPaused && !coroutineActive) {
			Spawn ();
			coroutineActive = true;
		} 
	}
	
	public void Spawn ()
	{
		StartCoroutine (SpawnLeftSide ());
		StartCoroutine (SpawnRightSide ());
		
	}
	
	public void Reset ()
	{
		StopCoroutine (SpawnLeftSide ());
		StopCoroutine (SpawnRightSide ());
	}
	
	IEnumerator SpawnLeftSide ()
	{
		while (true) {		
			float randomTrackNumOne = Random.value; //Determining starting track for random object spawn
			float randomObjectTypeNumOne = Random.value; //Determining whether good or bad object will spawn
			
			if (randomTrackNumOne < .5f) {
				objectPosOne = new Vector2 (trackOneXPos, StartingYPos);
			} else if (randomTrackNumOne >= .5f) {
				objectPosOne = new Vector2 (trackTwoXPos, StartingYPos);
			}
			
			yield return new WaitForSeconds (currentSpawnWaitTime);
			if (!SpawnObjectsIsPaused) {
				if (randomObjectTypeNumOne < .5f) {
					Instantiate (goodObjectLeft, objectPosOne, Quaternion.identity);
				} else if (randomObjectTypeNumOne >= .5f) {
					Instantiate (badObjectLeft, objectPosOne, Quaternion.identity);
				}
			}
		}
	}
	
	IEnumerator SpawnRightSide ()
	{
		yield return new WaitForSeconds (.35f);
		while (true) {
			float randomTrackNumTwo = Random.value; //Determining starting track for random object spawn
			float randomObjectTypeNumTwo = Random.value; //Determining whether good or bad object will spawn
			
			if (randomTrackNumTwo < .4f) {
				objectPosTwo = new Vector2 (trackThreeXPos, StartingYPos);
			} else if (randomTrackNumTwo >= .4f) {
				objectPosTwo = new Vector2 (trackFourXPos, StartingYPos);
			}
			
			yield return new WaitForSeconds (currentSpawnWaitTime);
			if (!SpawnObjectsIsPaused) {
				if (randomObjectTypeNumTwo < .4f) {
					Instantiate (goodObjectRight, objectPosTwo, Quaternion.identity);
				} else if (randomObjectTypeNumTwo >= .4f) {
					Instantiate (badObjectRight, objectPosTwo, Quaternion.identity);
				}
			}
		}
	}
}
