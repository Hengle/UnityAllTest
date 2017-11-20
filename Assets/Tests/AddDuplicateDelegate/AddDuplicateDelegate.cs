using UnityEngine;
using System.Collections;
using System;

public class AddDuplicateDelegate : MonoBehaviour {

    public event EventHandler OnEvent;

	// Use this for initialization
    void Awake()
    {
    }

    void Start () {
        Debug.Log("Add 3 times");
        OnEvent += HandleOnEventent;
        OnEvent += HandleOnEventent;
        OnEvent += HandleOnEventent;

        Debug.Log("Dispatch");
        OnEvent(this, null);
        
        Debug.Log("remove 1 time");
        OnEvent -= HandleOnEventent;
        Debug.Log("Dispatch");
        OnEvent(this, null);
        
        Debug.Log("remove 2 time");
        OnEvent -= HandleOnEventent;
        Debug.Log("Dispatch");
        OnEvent(this, null);
        
        Debug.Log("remove 3 time");
        OnEvent -= HandleOnEventent;
        Debug.Log("Dispatch");
        OnEvent(this, null);
	}

    void HandleOnEventent (object sender, EventArgs e)
    {
        Debug.Log("HandleOnEventent, frame=" + Time.frameCount);
    }
	
	// Update is called once per frame
	void Update () {
	
	}


}
