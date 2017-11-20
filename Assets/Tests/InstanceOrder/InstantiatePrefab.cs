using UnityEngine;
using System.Collections;

public class InstantiatePrefab : MonoBehaviour
{

    public GameObject prefab;
    public bool isAwake = false;

    void Awake()
    {
        if (isAwake)
        {
            CreatePrefab("Awake()");
        }
    }

    // Use this for initialization
    void Start()
    {
        
        if (false == isAwake)
        {
            CreatePrefab("Start()");
        }
    }

    private void CreatePrefab(string callerName)
    {
        
        GameObject i = Instantiate(prefab) as GameObject;
        InstanceOrder pn = i.GetComponent<InstanceOrder>();
        Debug.Log("In " + gameObject.name + "'s " + callerName + " it instantiates prefab: " + pn.name + ", its status is: " + pn.status + ", CallIndex=" + InstanceOrder.AutoIncrCallIndex);
    }
    // Update is called once per frame
    void Update()
    {
    
    }
}
