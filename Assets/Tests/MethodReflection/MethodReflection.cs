using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;
using System.Reflection;
using UnityEngine.Profiling;

public class MethodReflection : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        for(int i = 0; i < 999; ++i)
        {
            StackTraceTest();
            CurrentMethodTest();
        }
	}

    private string StackTraceTest()
    {
        string name;
        Profiler.BeginSample("StackTrace");
        StackTrace st = new StackTrace(0, false);
        name = st.GetFrame(0).GetMethod().Name;
        Profiler.EndSample();

        return name;
    }

    private string CurrentMethodTest()
    {
        Profiler.BeginSample("CurrentMethod");
        string name = MethodBase.GetCurrentMethod().Name;
        Profiler.EndSample();

        return name;
    }
}
