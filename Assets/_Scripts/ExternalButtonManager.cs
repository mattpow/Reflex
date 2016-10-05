using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ExternalButtonManager : MonoBehaviour
{
	public Sprite IOSShareSprite;
	public Texture2D _logo;
	public Diffusion diffusion;
	
	void Start ()
	{
		#if UNITY_IOS
		GameObject.Find ("ShareButton").GetComponent<Button> ().GetComponent<Image> ().sprite = IOSShareSprite;
		diffusion.eventReceiver = gameObject;
		#endif
	}

	public void RateLink ()
	{
		#if UNITY_ANDROID
		Application.OpenURL ("http://www.play.google.com/store/apps/details?id=xyz.mattpowell.reflex");
		#elif UNITY_IOS
		Application.OpenURL ("https://itunes.apple.com/us/app/reflex-test-your-reflexes/id1041878617");
		#endif
		
		
	}
	

	public void shareText ()
	{
		//execute the below lines if being run on a Android device
		#if UNITY_ANDROID
		string subject = "Reflex";
		string body = "I scored " + ScoreController.scoreInt + " points in Reflex! Get it on the play store and try to beat me? \n\n http://www.play.google.com/store/apps/details?id=xyz.mattpowell.reflex";
		
		//Refernece of AndroidJavaClass class for intent
		AndroidJavaClass intentClass = new AndroidJavaClass ("android.content.Intent");
		//Refernece of AndroidJavaObject class for intent
		AndroidJavaObject intentObject = new AndroidJavaObject ("android.content.Intent");
		//call setAction method of the Intent object created
		intentObject.Call<AndroidJavaObject> ("setAction", intentClass.GetStatic<string> ("ACTION_SEND"));
		//set the type of sharing that is happening
		intentObject.Call<AndroidJavaObject> ("setType", "text/plain");
		//add data to be passed to the other activity i.e., the data to be sent
		intentObject.Call<AndroidJavaObject> ("putExtra", intentClass.GetStatic<string> ("EXTRA_SUBJECT"), subject);
		intentObject.Call<AndroidJavaObject> ("putExtra", intentClass.GetStatic<string> ("EXTRA_TEXT"), body);
		//get the current activity
		AndroidJavaClass unity = new AndroidJavaClass ("com.unity3d.player.UnityPlayer");
		AndroidJavaObject currentActivity = unity.GetStatic<AndroidJavaObject> ("currentActivity");
		//start the activity by sending the intent data
		currentActivity.Call ("startActivity", intentObject);
		#elif UNITY_IOS
		diffusion.Share ("I scored " + ScoreController.scoreInt + " points in Reflex! Can you beat me?", "https://itunes.apple.com/us/app/reflex-test-your-reflexes/id1041878617", null);
		#endif	
	}
}
