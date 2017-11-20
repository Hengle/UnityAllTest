using UnityEngine;
using System.Collections;

/// <summary>
/// Conclusion: 
/// 1. The order of gameobject's instantiation, is ONLY about the Creation of gameObject in the Editor!!!
/// and NOT about the gameObject order in the Hierachy!!!
/// 
/// 2. In A's Awake() or Start(), A instantiates B, B's Awake() is called immediately. B's Start() is called "next time"
/// 
/// 3. MonoManager's Script Excution Order, can modify one Script(inherited from MonoBehaviour)'s order to other script.
/// </summary>
public class InstanceOrder : MonoBehaviour
{
    private static int ms_callIndex = 0;

    public static int AutoIncrCallIndex
    {
        get
        {
            ++ms_callIndex;
            return ms_callIndex;
        }
    }

    public string status = "n/a";
    public bool showUpdate = false;
    //public bool logInCtor = false; //in ctor, this field is always defult to c# false
    public GameObject CompareGameObject;
    public InstanceOrder CompareComp;

    public InstanceOrder()
    {
        //gameObject, Time.frameCount can only be called from the mainThead
        //Debug.Log(gameObject.name + "instance=" + this.GetInstanceID() + ", Constructor, Frame=" + Time.frameCount + ", CallIndex=" + AutoIncrCallIndex);
        
        Debug.Log("ctor, instance=" + this.GetHashCode() + ", CallIndex=" + AutoIncrCallIndex);
        
        if (object.ReferenceEquals(this, CompareComp))
        {
            
            Debug.Log("ctor, InstanceOrder.ctor, component ref equal!");
        }
    }

    void Awake()
    {
        status = "Awaked";

        Debug.Log(gameObject.name + ", instance=" + this.GetHashCode() + " Awake, Frame=" + Time.frameCount + ", CallIndex=" + AutoIncrCallIndex);

        if (null != CompareComp)
        {
            if (object.ReferenceEquals(this, CompareComp))
            {

                Debug.Log("InstanceOrder.awake, component ref equal!" + CompareComp.name + ", " + CompareComp.GetHashCode() + this.name + ", " + this.GetHashCode());
            }
        }
        if (null != CompareGameObject)
        {
            if (object.ReferenceEquals(this.gameObject, CompareGameObject))
            {
                
                Debug.Log("InstanceOrder.awake, gameobject ref equal!" + CompareGameObject.name + ", " + CompareGameObject.GetHashCode() + this.gameObject.name + ", " + this.gameObject.GetHashCode());
            }
        }
                
    }
    // Use this for initialization
    void Start()
    {
        status = "Started";
        Debug.Log(gameObject.name + ", instance=" + this.GetHashCode() + " Start, Frame=" + Time.frameCount + ", CallIndex=" + AutoIncrCallIndex);
    }
    
    // Update is called once per frame
    void Update()
    {
        if (showUpdate)
        {
            Debug.Log(gameObject.name + " Update, Frame=" + Time.frameCount + ", CallIndex=" + AutoIncrCallIndex);
        }
    }
}
