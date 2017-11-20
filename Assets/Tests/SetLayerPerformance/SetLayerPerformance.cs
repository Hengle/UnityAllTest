using UnityEngine;
using System.Collections;
using UnityEngine.Profiling;

public class SetLayerPerformance : MonoBehaviour {
	public int setLayerId = 0;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Profiler.BeginSample("UpdateSetLayer");
		gameObject.layer = setLayerId;
		Profiler.EndSample();
	}
}
