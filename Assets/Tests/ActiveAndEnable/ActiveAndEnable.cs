using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveAndEnable : MonoBehaviour {
    public MonoBehaviour behaviour;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Debug.Log("behaviour.gameObject.activeInHierarchy=" + behaviour.gameObject.activeInHierarchy + ",behaviour.enabled=" + behaviour.enabled);
	}
}
