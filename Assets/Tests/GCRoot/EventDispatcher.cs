using UnityEngine;
using System.Collections;
using System;

public class EventDispatcher : MonoBehaviour
{

		public event EventHandler OnEvent;

		// Use this for initialization
		void Start ()
		{
				if (null != OnEvent) {
						Debug.Log (this.ToString() + this.GetInstanceID ().ToString() + "Start(): OnEvent)");
						OnEvent (this, null);
				}
		}
	
		// Update is called once per frame
		void Update ()
		{
	
		}

		void OnDestroy ()
		{
				if (null != OnEvent) {
			Debug.Log (this.ToString() + this.GetInstanceID ().ToString() + "OnDestroy(): OnEvent)");
						OnEvent (this, null);
				}
		}
}
