using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Profiling;

public class CoroutineProfile : MonoBehaviour {

    private int m_i;
    private WaitForSeconds m_wait = new WaitForSeconds(1.0f);
    void Start()
    {
        
        for(int i = 0; i < 999; ++i)
        {
            Profiler.BeginSample("StartCoroutine");
            StartCoroutine(SomeCoroutine());
            Profiler.EndSample();
        }
    }

    private IEnumerator SomeCoroutine()
    {
        yield return m_wait;
        Debug.Log(m_i++);
    }
}
