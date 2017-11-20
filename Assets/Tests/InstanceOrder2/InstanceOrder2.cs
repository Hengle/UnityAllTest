using UnityEngine;
using System.Collections;

public class InstanceOrder2 : MonoBehaviour {

	public GameObject prefab;
	// Use this for initialization
	void Start () {
		Debug.Log("InstanceOrder2.Start");
		GameObject instance = Instantiate(prefab) as GameObject;
		Callee callee = instance.GetComponent<Callee>();
		callee.Func();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
