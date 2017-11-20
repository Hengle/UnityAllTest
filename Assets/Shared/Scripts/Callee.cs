using UnityEngine;
using System.Collections;

public class Callee : MonoBehaviour {
	public Callee()
	{
		Debug.Log("Callee.ctor");
	}
	void Awake()
	{
		Debug.Log("Caller.Awake");
	}
	// Use this for initialization
	void Start () {
		
		Debug.Log("Caller.Start");
	}

	public void Func()
	{
		Debug.Log("Caller.Func");
	}

	// Update is called once per frame
	void Update () {
	
	}
}
