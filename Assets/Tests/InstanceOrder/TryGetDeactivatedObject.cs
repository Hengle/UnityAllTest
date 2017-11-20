using UnityEngine;
using System.Collections;

public class TryGetDeactivatedObject : MonoBehaviour {
    public string objectPath;
	// Use this for initialization
	void Start () {
        GameObject go = GameObject.Find(objectPath);

        Debug.Log("try to get object " + objectPath + ", result is: " + go);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
