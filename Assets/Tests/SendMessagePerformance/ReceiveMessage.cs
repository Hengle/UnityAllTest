using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public interface IReceiveMessage : IEventSystemHandler
{
	void OnMessage();
}

public class ReceiveMessage : MonoBehaviour, IEventSystemHandler {
	public GameObject prefabChild;

	public const string MessageName = "OnMessage";

	public void InstantiateChild(int count = 1)
	{
		GameObject newChild;

		for(int i = 0; i < count; ++i)
		{
			newChild = Instantiate(prefabChild) as GameObject;
			newChild.transform.SetParent(transform);
		}
	}

	public void OnMessage()
	{
		int i = 0;
		++i;
	}
}
