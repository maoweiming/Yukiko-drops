using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class screenshot_capture_custom : MonoBehaviour {

	public int resWidth = 2550; 
	public int resHeight = 3300;

	// UI variables
	public GameObject UI;
	public InputField inputX;
	public InputField inputY;
	public Text currentRes;

	private bool takeHiResShot = false;

	void Start() {
		currentRes.text = "current res : " + resWidth + " x " + resHeight;
	}

	/* SET SCREENSHOT NAME */

	public static string ScreenShotName(int width, int height) {
			return string.Format("{0}/screen_{1}x{2}_{3}.png", 
				Application.dataPath, 
				width, height, 
				System.DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss"));
	}

	/* SET RESOLUTION */

	public void setResX() {
		
			print ("set res x");
			string resInput = inputX.text;
			int i = 0;
			i = System.Convert.ToInt32 (resInput);
			resWidth = i;
			print("resWidth now set to : " + i);
			currentRes.text = "current res : " + resWidth + " x " + resHeight;
			
		}

	public void setResY() {
		
			print ("set res y");
			string resInput = inputY.text;
			int i = 0;
			i = System.Convert.ToInt32 (resInput);
			resHeight = i;
			print("resWidth now set to : " + resHeight);
			currentRes.text = "current res : " + resWidth + " x " + resHeight;
			
		}

	/* SCREENSHOT FUNCTION */

	public void TakeHiResShot() {
		UI.GetComponent<Canvas> ().enabled = false;
		takeHiResShot = true;
	}

	void LateUpdate() {
		
			takeHiResShot |= Input.GetKeyDown("k");
			if (takeHiResShot) {
				RenderTexture rt = new RenderTexture(resWidth, resHeight, 24);
				Camera.main.targetTexture = rt;
				Texture2D screenShot = new Texture2D(resWidth, resHeight, TextureFormat.RGB24, false);
				Camera.main.Render();
				RenderTexture.active = rt;
				screenShot.ReadPixels(new Rect(0, 0, resWidth, resHeight), 0, 0);
				Camera.main.targetTexture = null;
				RenderTexture.active = null; // JC: added to avoid errors
				Destroy(rt);
				byte[] bytes = screenShot.EncodeToPNG();
				string filename = ScreenShotName(resWidth, resHeight);
				System.IO.File.WriteAllBytes(filename, bytes);
				Debug.Log(string.Format("Took screenshot to: {0}", filename));
				takeHiResShot = false;
			}

			UI.GetComponent<Canvas> ().enabled = true;
	}
}
