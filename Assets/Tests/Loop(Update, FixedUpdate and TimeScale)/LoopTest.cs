using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopTest : MonoBehaviour {
    public GameObject prefab;

    public enum InstantiateMode
    {
        InAwake,
        InStart,
        InUpdate
    }
    public InstantiateMode instantiateMode;

    private bool m_instantiated = false;


    void Awake()
    {
        if(instantiateMode == InstantiateMode.InAwake)
        {
            Debug.Log("Awake Instantiate,tick=" + Time.frameCount);
            Instantiate(prefab);
        }
    }

	// Use this for initialization
	void Start () {
        if(instantiateMode == InstantiateMode.InStart)
        {
            Debug.Log("Start Instantiate,tick=" + Time.frameCount);
            Instantiate(prefab);
        }
	}
	
	// Update is called once per frame
	void Update () {

        if(instantiateMode == InstantiateMode.InUpdate && !m_instantiated)
        {
            Debug.Log("Update Instantiate,tick=" + Time.frameCount);
            m_instantiated = true;
            Instantiate(prefab);
        }
	}
}
