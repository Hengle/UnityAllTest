using UnityEngine;
using System.Collections;

public class OnTransformChildrenChangeTest : MonoBehaviour {

	public GameObject prefab;
	// Use this for initialization
	void Start () {
		GameObject instance = Instantiate(prefab) as GameObject;
		instance.transform.SetParent(transform, false);
	}

	void OnTransformChildrenChanged()
	{
		Debug.Log(name + transform.GetInstanceID() + ".OnTransformChildrenChanged");
	}
}
