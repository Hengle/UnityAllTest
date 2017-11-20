using UnityEngine;
using System.Collections;
using System;

public class BaseComponent : MonoBehaviour {

	void Awake()
	{

		Component c = GetComponent(this.GetType());
		Debug.Log(c);

	}
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
