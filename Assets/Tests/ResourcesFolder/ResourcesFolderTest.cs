using UnityEngine;
using System.Collections;

public class ResourcesFolderTest : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GameObject prefab;
        prefab = Resources.Load("PrefabInResources") as GameObject;
        Instantiate(prefab);

        prefab = Resources.Load("1/PrefabInAnotherResources") as GameObject;
        Instantiate(prefab);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
