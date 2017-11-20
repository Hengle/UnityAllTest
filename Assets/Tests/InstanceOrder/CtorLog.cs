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
public class CtorLog : MonoBehaviour
{
    public CtorLog()
    {

        Debug.Log("CtorLog");
        // even though CtorLog is in not in the scene but in a prefab which is Instantiate, which means in the main thread now
        // gameObject is still NOT accessable
        //Debug.Log("CtorLog, gameObject.name=" + gameObject.name );
    }

    void Awake()
    {
    }

    void Start()
    {
    }
}
