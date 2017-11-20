using UnityEngine;
using System.Collections;
using MoreFun;

public class CaptureCamera : MonoBehaviour
{
		public int quality = 75;
		public bool doCapture = false;
		private Camera m_cam;
		// Use this for initialization
		void Start ()
		{
				m_cam = GetComponent<Camera> ();
		}
	
		// Update is called once per frame
		void Update ()
		{
	
		}

		void LateUpdate ()
		{
		}

		void OnValidate ()
		{
				if (true == doCapture) {
						doCapture = false;
						CameraUtil.CameraToFile (m_cam, "cameraCaptureTest.jpg");
				}
		}
}
