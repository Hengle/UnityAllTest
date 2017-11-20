using UnityEngine;
using System.Collections;

public class EventListener : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Debug.Log(this.ToString() + this.GetInstanceID ().ToString() + ": AddOnEvent");

		EventDispatcher ed = GetComponent<EventDispatcher>();
		ed.OnEvent += HandleOnEvent;

		StaticEventDispathcer.OnStaticEvent += HandleOnStaticEvent;
	}

	void HandleOnStaticEvent (object sender, System.EventArgs e)
	{
		Debug.Log(this.ToString() + this.GetInstanceID ().ToString() + ": HandleOnStaticEvent");
	}

	void HandleOnEvent (object sender, System.EventArgs e)
	{
		Debug.Log(this.ToString() + this.GetInstanceID ().ToString() + ": HandleOnEvent");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
