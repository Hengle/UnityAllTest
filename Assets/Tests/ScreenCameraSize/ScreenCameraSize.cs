using UnityEngine;
using System.Collections;
using MoreFun;

public class ScreenCameraSize : MonoBehaviour {

	// Use this for initialization
		public float resolutionRatio = 1.0f;
	void Start () {
				Screen.SetResolution((int)(Screen.currentResolution.width * resolutionRatio),
						(int)(Screen.currentResolution.height * resolutionRatio), true);
	}
	
	// Update is called once per frame
	void Update () {
				this.MoreLog("Screen", Screen.width, Screen.height);
				this.MoreLog("Screen.currentResolution", Screen.currentResolution.width, Screen.currentResolution.height);
				this.MoreLog("Camera", Camera.main.pixelWidth, Camera.main.pixelHeight);
	}
}
