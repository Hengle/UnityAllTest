using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Profiling;

public class GetMissingComponent : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Profiler.BeginSample("GetMissingComponent");
        GetComponent<EventDispatcher>(); // 600Byte GC Alloc, 0.01ms in macbook
        Profiler.EndSample();


        Profiler.BeginSample("GetExistedComponent");
        GetComponent<GetMissingComponent>(); // 0 GC Alloc, 0.00ms in macbook
        Profiler.EndSample();
	}
}
