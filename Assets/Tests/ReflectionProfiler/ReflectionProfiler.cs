using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Profiling;
using System;

public class ReflectionProfiler : MonoBehaviour {
    

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        for(int i = 0; i < 999; ++i)
        {

            Profiler.BeginSample("GetType");
            Type type = this.GetType();
            Profiler.EndSample();

            Profiler.BeginSample("ToString");
            string s = type.ToString(); // GC: 60.5K
            Profiler.EndSample();

        }

	}
}
