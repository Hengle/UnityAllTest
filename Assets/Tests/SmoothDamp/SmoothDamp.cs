using UnityEngine;
using System.Collections;

public class SmoothDamp : MonoBehaviour {
		public Vector3 targetPos;
		public float smoothTime = 1.0f;
		public float maxSpeed = 1.0f;
		public float deltaTime;
		public bool onUpdate;
	// Use this for initialization
	void Start ()
	{
				Vector3 vel = Vector3.zero;
				transform.position = Vector3.SmoothDamp(transform.position, targetPos, ref vel, smoothTime, maxSpeed, deltaTime);
	}
	
	// Update is called once per frame
	void Update () {
				if(onUpdate)
				{
						Vector3 vel = Vector3.zero;
						transform.position = Vector3.SmoothDamp(transform.position, targetPos, ref vel, smoothTime, maxSpeed, deltaTime);
				}
	}
}
