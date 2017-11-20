using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System.Collections.Generic;

public class MoreExecuteEvents : MonoBehaviour
{
	
	private static readonly List<Transform> s_InternalTransformList = new List<Transform>(30);

	// Use 
	public static bool ExecuteHierarchyDown<T>(GameObject root, BaseEventData eventData, UnityEngine.EventSystems.ExecuteEvents.EventFunction<T> callbackFunction) where T : IEventSystemHandler
	{
		GetEventChainDown(root, s_InternalTransformList, true);

		bool executed = false;
		for (var i = 0; i < s_InternalTransformList.Count; i++)
		{
			var transform = s_InternalTransformList[i];
			if (ExecuteEvents.Execute(transform.gameObject, eventData, callbackFunction))
				executed = true;
		}
		return executed;
	}
	
	private static void GetEventChainDown(GameObject root, IList<Transform> eventChain, bool clear)
	{
		if(clear)
		{
			eventChain.Clear();
		}

		if (root == null)
			return;
		
		var t = root.transform;
		if(t != null)
		{
			eventChain.Add(t);

			for(int i = 0; i < t.childCount; ++i)
			{
				GetEventChainDown(t.GetChild(i).gameObject, eventChain, false);
			}
		}
	}
}

