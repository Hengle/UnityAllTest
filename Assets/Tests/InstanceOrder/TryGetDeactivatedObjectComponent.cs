using UnityEngine;
using System.Collections;

public class TryGetDeactivatedObjectComponent : MonoBehaviour
{
    [Tooltip("I can comment this field in Inspector")]
    public bool includeInactivate;
    public GameObject CompareObject;
    public InstanceOrder CompareComp;
    // Use this for initialization
    void Start()
    {
        Debug.Log("try to get inactivate component with includeInactivate= " + includeInactivate);
        InstanceOrder[] comps = gameObject.GetComponentsInChildren<InstanceOrder>(includeInactivate);
        foreach(InstanceOrder oneComp in comps)
        {
            Debug.Log("oneComp.gameObject.name=" + oneComp.gameObject.name + ", oneComp.gameObject.GetInstanceID()=" + oneComp.gameObject.GetHashCode());

            if(null != CompareObject)
            {
                if (object.ReferenceEquals(oneComp.gameObject, CompareObject))
                {
                    Debug.Log("GameObject ref equal!" + CompareObject.name + ", " + CompareObject.GetHashCode() + oneComp.gameObject.name + ", " + oneComp.gameObject.GetHashCode());
                }
            }
            if(null != CompareComp)
            {
                if (object.ReferenceEquals(oneComp, CompareComp))
                {
                    Debug.Log("Component ref equal!" + CompareComp.name + ", " + CompareComp.GetHashCode() + oneComp.name + ", " + oneComp.GetHashCode());
                }
            }
        }
        Debug.Log("try to get inactivate component end");
    }
    
    // Update is called once per frame
    void Update()
    {
    
    }
}
