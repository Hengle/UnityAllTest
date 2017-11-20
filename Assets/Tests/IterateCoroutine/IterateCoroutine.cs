using UnityEngine;
using System.Collections;

public class IterateCoroutine : MonoBehaviour {

	// Use this for initialization
	void Start () {
		int i = 0;
		for(i = 0; i < 99; ++i)
		{
			StartCoroutine(MyCoroutine(i));
		}
	}

	private IEnumerator MyCoroutine(int i)
	{
		yield return new WaitForSeconds(Random.Range(1, 2));
		Debug.Log(i + ", time=" + Time.realtimeSinceStartup);
	}

}
