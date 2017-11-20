using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopObject : MonoBehaviour {

	
    // Use this for initialization

    public int targetFrameRate = 30;

    private int m_fixedUpdateCount;
    private float m_lastFixedTimeStamp;
    private float m_lastTimeStamp;
    private int m_updateCount;

    private bool m_fixedUpdateCalled = false;

    void Awake()
    {
        Debug.Log("tick=" + Time.frameCount + ",Awake()");
    }

    void Start () {
        Debug.Log("tick=" + Time.frameCount + ",Start()");
        m_fixedUpdateCount = 0;
        m_updateCount = 0;

        Debug.Log(Time.deltaTime);
        Debug.Log(Time.fixedDeltaTime);

        Application.targetFrameRate = targetFrameRate;

        m_lastFixedTimeStamp = Time.realtimeSinceStartup;
        m_lastTimeStamp = Time.realtimeSinceStartup;
	}
	
    void FixedUpdate()
    {
        ++m_fixedUpdateCount;
        float elapsed = Time.realtimeSinceStartup - m_lastFixedTimeStamp;
        m_lastFixedTimeStamp = Time.realtimeSinceStartup;
        Debug.Log("tick=" + Time.frameCount + ",FixedUpdate(),m_fixedUpdateCount=" + m_fixedUpdateCount + 
            ",fixedElapsed=" + elapsed +
            ",Time.timeScale=" + Time.timeScale +
            ",Time.fixedDeltaTime=" + Time.fixedDeltaTime + ",Time.fixedUnscaledDeltaTime=" + Time.fixedUnscaledDeltaTime +
            ",Time.fixedUnscaledTime=" + Time.fixedUnscaledTime +  ",Time.fixedTime=" + Time.fixedTime);

        m_fixedUpdateCalled = true;
    }

	// Update is called once per frame
	void Update () {
        ++m_updateCount;
        float elapsed = Time.realtimeSinceStartup - m_lastTimeStamp;
        m_lastTimeStamp = Time.realtimeSinceStartup;
        Debug.Log("tick=" + Time.frameCount + ",Update(),m_updateCount=" + m_updateCount + 
            ",elapsed=" + elapsed +
            ",Time.timeScale=" + Time.timeScale +
            ",Time.deltaTime=" + Time.deltaTime + ",Time.unscaledDeltaTime=" + Time.unscaledDeltaTime +
            ",Time.unscaledTime=" + Time.unscaledTime +  ",Time.time=" + Time.time);

        if(!m_fixedUpdateCalled)
        {
            Debug.LogError("FixedUpdate NOT called!");
        }

        m_fixedUpdateCalled = false;
	}
}
