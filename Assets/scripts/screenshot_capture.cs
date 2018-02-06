using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.IO;


public class screenshot_capture : MonoBehaviour {

	int screenshotCounter = 0;
	string fileName;
	string filePath;
	string destination;
	public GameObject UI;
	public int resolutionX;
	public int resolutionY;
	//public GameObject tools;

	// Use this for initialization
	void Start () {

	
	}
	
	// Update is called once per frame
	void Update () {

			
			// maybe use persitent data path larter?

	}

	public void takeScreenshot() {


			//filePath = Application.persistentDataPath + "/eda screenshots";
			filePath = Application.persistentDataPath;
			destination = "/storage/emulated/0/DCIM/";


			if (!System.IO.Directory.Exists (filePath))
				System.IO.Directory.CreateDirectory (filePath);
			
			if (!System.IO.Directory.Exists (destination))
				System.IO.Directory.CreateDirectory (destination);


			fileName = "/Eda-screenshot-" + screenshotCounter+ ".png";
			StartCoroutine (screenshot (destination));
		

	}

	IEnumerator screenshot(string destination) {
		
		yield return null;
		UI.GetComponent<Canvas> ().enabled = false;
		//tools.GetComponent<Canvas> ().enabled = false;
		yield return new WaitForEndOfFrame();
		ScreenCapture.CaptureScreenshot (filePath + fileName);
		//System.IO.File.Move(filePath + fileName, destination + fileName);

		UI.GetComponent<Canvas> ().enabled = true;
		//tools.GetComponent<Canvas> ().enabled = true;

		//print ("Picture saved to " + filePath + fileName);
		//print ("Picture saved to " + destination);
		screenshotCounter = screenshotCounter + 1;

		//GameObject.Find ("CameraButton").GetComponent<screenshotButton_script> ().screenshotUIDisplay ("Picture saved to : " + filePath + fileName);

		refreshGallery ();

	}

	void refreshGallery() {
		
		//REFRESHING THE ANDROID PHONE PHOTO GALLERY IS BEGUN
		AndroidJavaClass classPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
		AndroidJavaObject objActivity = classPlayer.GetStatic<AndroidJavaObject>("currentActivity");     

		AndroidJavaClass classUri = new AndroidJavaClass("android.net.Uri");        
		AndroidJavaObject objIntent = new AndroidJavaObject("android.content.Intent", new object[2]{"android.intent.action.MEDIA_MOUNTED", classUri.CallStatic<AndroidJavaObject>("parse", "file://" + filePath + fileName)});        
		objActivity.Call ("sendBroadcast", objIntent);
		//REFRESHING THE ANDROID PHONE PHOTO GALLERY IS COMPLETE

		//AUTO LAUNCH/VIEW THE SCREENSHOT IN THE PHOTO GALLERY
		Application.OpenURL(filePath + fileName);
		//AFTERWARDS IF YOU MANUALLY GO TO YOUR PHOTO GALLERY, 
		//YOU WILL SEE THE FOLDER WE CREATED CALLED "myFolder"

	}
}
