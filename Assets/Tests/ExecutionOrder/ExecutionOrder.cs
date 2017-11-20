using UnityEngine;
using System.Collections;
using MoreFun;

public class ExecutionOrder : MonoBehaviour {

	private static ExecutionOrder me;
	public bool enableOnAwake = true;

	public bool disableOnUpdate = false;

	void Awake()
	{
		this.MoreLog(GetInstanceID(), Time.frameCount);
		if(me == null)
		{
			me = this;

			Instantiate(gameObject);
		}

		enabled = enableOnAwake;
	}
	void Start () {
		this.MoreLog(GetInstanceID(), Time.frameCount);
	}

	void OnEnable()
	{
		this.MoreLog(GetInstanceID(), Time.frameCount);
	}

	void OnDisable()
	{
		this.MoreLog(GetInstanceID(), Time.frameCount);
	}

	void Update()
	{
		if(disableOnUpdate)
		{
			disableOnUpdate = false;

			this.MoreLog(GetInstanceID(), Time.frameCount, "disable on update");
			enabled = false;
		}
	}
}
