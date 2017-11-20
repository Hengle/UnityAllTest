using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class AssetInitializeTime : MonoBehaviour {

	public bool start = false;

	private GameObject prefab;
	private GameObject prefabInstanced;

	public bool usePreabInstanced = false;
	private List<GameObject> lstActiveCached = new List<GameObject>();
	private List<GameObject> lstDectiveCached = new List<GameObject>();
	public int deactiveAndActiveCount = 0;
	public int destroyAndInstantiateCount = 0;
	public int maxActiveCached = 30;
	public int maxDeactiveCached = 60;

	public Text m_txtMaxActiveCached;
	public Text m_txtDeactiveCached;

	// Use this for initialization
	void Start () {
	}

	public void OnStartClicked()
	{
		start = !start;
	}

	public void OnMaxActiveClicked()
	{
		++maxActiveCached;
	}

	public void OnMaxDeactivatedClicked()
	{
		++maxDeactiveCached;
	}

	// Update is called once per frame
	void Update () {
		if(start)
		{
			if(null == prefab)
			{
				prefab = Resources.Load("UIPrefab") as GameObject;
			}
			GameObject prefabInUse = prefab;
			if(usePreabInstanced)
			{
				if(null != prefabInstanced)
				{
					prefabInUse = prefabInstanced;
				}
			}
			
			GameObject newOne;
			newOne = Instantiate(prefabInUse) as GameObject;
			if(null == prefabInstanced)
			{
				prefabInstanced = newOne;
			}
			newOne.transform.SetParent(transform);
			for(int i = 0; i < deactiveAndActiveCount; ++i)
			{
				newOne.SetActive(false);
				newOne.SetActive(true);
			}
			for(int i = 0; i < destroyAndInstantiateCount; ++i)
			{
				Destroy(newOne);
				newOne = Instantiate(prefabInUse) as GameObject;
            }
			newOne.transform.localPosition = new Vector3(0.0f, 0.0f);
			List<GameObject> lstTransfer = null;
			if(maxActiveCached > 0)
			{
				lstActiveCached.Add(newOne);
				if(lstActiveCached.Count >= maxActiveCached)
				{
					lstTransfer = lstActiveCached;
					lstActiveCached = new List<GameObject>();
				}
			}

			if(null != lstTransfer)
			{
				for(int i = 0; i < lstTransfer.Count; ++i)
				{
					lstTransfer[i].SetActive(false);
				}
			}


			if(null != lstTransfer)
			{
				lstDectiveCached.AddRange(lstTransfer);
				
				if(lstDectiveCached.Count >= maxDeactiveCached)
				{
					for(int i = 0; i < lstDectiveCached.Count; ++i)
					{
						lstDectiveCached[i].SetActive(true);
					}
					
					
					lstDectiveCached = new List<GameObject>();
				}
			}
		}
	}
}
