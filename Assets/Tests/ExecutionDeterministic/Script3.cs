using UnityEngine;
using System.Collections;

namespace Tests.ExecutionOrder
{
	public class Script3 : MonoBehaviour {

		void Awake()
		{
			Debug.Log(this.gameObject.GetInstanceID() + "," + this.GetInstanceID() + "," + this + ".Awake");
		}
		void Start () {

			Debug.Log(this.gameObject.GetInstanceID() + "," + this.GetInstanceID() + "," + this + ".Start");
		}

		private bool m_didFixUpdate = false;
		void FixedUpdate()
		{
			if(!m_didFixUpdate)
			{
				m_didFixUpdate = true;
				Debug.Log(this.gameObject.GetInstanceID() + "," + this.GetInstanceID() + "," + this + ".FixedUpdate");
			}
		}

		private bool m_didUpdate = false;
		void Update () {
			if(!m_didUpdate)
			{
				m_didUpdate = true;
				Debug.Log(this.gameObject.GetInstanceID() + "," + this.GetInstanceID() + "," + this + ".Update");
			}
		}

		void OnDestroy()
		{
			Debug.Log(this.gameObject.GetInstanceID() + "," + this.GetInstanceID() + "," + this + ".OnDestroy");
		}
	}

}