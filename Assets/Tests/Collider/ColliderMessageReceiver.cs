using UnityEngine;
using System.Collections;

public class ColliderMessageReceiver : MonoBehaviour
{
    void OnCollisionEnter()
    {
        Debug.Log(gameObject.name + ".OnCollisionEnter");
    }
    
    void OnTriggerEnter()
    {
        Debug.Log(gameObject.name + ".OnTriggerEnter");
    }
}
