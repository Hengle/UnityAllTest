using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Tests.ExecutionOrder
{
	public class Root : MonoBehaviour {
		public GameObject prefab1;
		public GameObject prefab2;
		public GameObject prefab3;

		private List<GameObject> lst1 = new List<GameObject>();
		private List<GameObject> lst2 = new List<GameObject>();
		private List<GameObject> lst3 = new List<GameObject>();

		public float instantiateChance = 0.5f;
		public int instantiateMinCount = 1;
		public int instantiateMaxCount = 10;
		public float destroyChance = 0.5f;
		public int destroyMinCount = 1;
		public int destroyMaxCount = 10;

		void Awake()
		{
			Debug.Log(gameObject.name + ".Root.Awake");
		}

		void Update () {
			if(Random.Range(0.0f, 1.0f) < instantiateChance)
			{
				InstantiateGo(lst1, prefab1, Random.Range(instantiateMinCount, instantiateMaxCount));
			}
			if(Random.Range(0.0f, 1.0f) < destroyChance)
			{
				DestroyGo(lst1, Random.Range(destroyMinCount, destroyMaxCount));
			}
			if(Random.Range(0.0f, 1.0f) < instantiateChance)
			{
				InstantiateGo(lst2, prefab2, Random.Range(instantiateMinCount, instantiateMaxCount));
			}
			if(Random.Range(0.0f, 1.0f) < destroyChance)
			{
				DestroyGo(lst2, Random.Range(destroyMinCount, destroyMaxCount));
			}
			if(Random.Range(0.0f, 1.0f) < instantiateChance)
			{
				InstantiateGo(lst3, prefab3, Random.Range(instantiateMinCount, instantiateMaxCount));
			}
			if(Random.Range(0.0f, 1.0f) < destroyChance)
			{
				DestroyGo(lst3, Random.Range(destroyMinCount, destroyMaxCount));
			}
		}


		private void InstantiateGo(List<GameObject> lst, GameObject prefab, int count)
		{
			for(int i = 0; i < count; ++i)
			{
				lst.Add(Instantiate(prefab));
			}
		}
		private void DestroyGo(List<GameObject> lst, int count)
		{
			int c = 0;
			List<GameObject> removed = new List<GameObject>();
			for(int i = 0; i < lst.Count && c <= count; ++i, ++c)
			{
				removed.Add(lst[i]);
				Debug.Log("Will Destroy:" + lst[i].GetInstanceID());
				Destroy(lst[i]);
			}

			for(int i = 0; i < removed.Count; ++i)
			{
				lst.Remove(removed[i]);
			}
		}
	}

}