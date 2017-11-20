using UnityEngine;
using System.Collections;

public class ResourcesFindObjectsOfTypeAll : MonoBehaviour {

	// Use this for initialization
	void Start () {
		ResourcesFindObjectsOfTypeAll[] result = Resources.FindObjectsOfTypeAll<ResourcesFindObjectsOfTypeAll>();
		foreach(var one in result)
		{
			Debug.Log(one.gameObject);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
