using UnityEngine;
using System.Collections;
using System;

public class StaticEventDispathcer : MonoBehaviour {

	public static event EventHandler OnStaticEvent;

	public static void DispatchEvent()
	{
		if(null != OnStaticEvent)
		{
			OnStaticEvent(null, null);
		}
	}

	private static float m_lastTime;
	private static float m_lastClearTime;

	void Start()
	{
		m_lastTime = Time.time;
		m_lastClearTime = Time.time;
	}

	void Update()
	{
		if(Time.time - m_lastTime > 2.0f)
		{
			m_lastTime = Time.time;
			DispatchEvent();
		}

		if(Time.time - m_lastClearTime > 6.0f)
		{
			m_lastClearTime = Time.time;
			OnStaticEvent = null;
		}
	}
}
