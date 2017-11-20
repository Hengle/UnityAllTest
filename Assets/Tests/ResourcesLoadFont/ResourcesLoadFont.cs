using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ResourcesLoadFont : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Font font = Resources.Load<Font>("lantinghei_GB18030");
		Text text = GetComponent<Text>();

		text.font = font;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
