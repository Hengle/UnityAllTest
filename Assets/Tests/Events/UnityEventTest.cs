using UnityEngine;
using System.Collections;
using UnityEngine.Events;
using System;

public class UnityEventTest : MonoBehaviour {
	public UnityEvent m_event;

	[Serializable]
	public class CustomEvent : UnityEvent<float, int>{}
	[Serializable]
	public class CustomEvent2 : UnityEvent<UnityEventTest>{}

	public CustomEvent m_customEvent;
	public CustomEvent2 m_customEvent2;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		m_customEvent.Invoke(Time.realtimeSinceStartup, Time.frameCount);
	
	}
	
	public void OnCustomeEventFloat(float f)
	{
		Debug.Log("float:" + f);
	}
	public void OnCustomEventInt(int i)
	{
		Debug.Log("int:" + i);
	}
	public void OnCustomeEventFloatInt(float f, int i)
	{
		Debug.Log(string.Format("float={0}, int={1}", f, i));
	}
	public void OnCustomeEvent2(UnityEventTest obj)
	{
		Debug.Log("OnCustomeEvent2");
	}
}
