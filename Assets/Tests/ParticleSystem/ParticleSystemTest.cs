using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Profiling;

public class ParticleSystemTest : MonoBehaviour {
    private ParticleSystem m_ps;
	// Use this for initialization
	void Start () {
        m_ps = gameObject.AddComponent<ParticleSystem>();
	}
	
	// Update is called once per frame
	void Update () {
        Profiler.BeginSample("ParticleSystem.PlayIfNotPlaying");
        for(int i = 0; i < 999; ++i)
        {
            if(!m_ps.isPlaying)
            {
                m_ps.Play();
            }
        }
        Profiler.EndSample();
	}
}
