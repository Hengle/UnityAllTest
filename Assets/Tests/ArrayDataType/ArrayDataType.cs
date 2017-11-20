using UnityEngine;
using System.Collections;

public class ArrayDataType : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        byte[] bytes0 = new byte[10];
        byte[] bytes1 = new byte[30];

        byte[] bytes0_1 = bytes0;

        if(bytes0_1 == bytes0)
        {
            Debug.Log("bytes0_1 == bytes0");
        }
        else
        {
            Debug.Log("bytes0_1 != bytes0");
        }

    }
}
