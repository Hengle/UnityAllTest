using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine.Profiling;

public class SendMessagePerformance : MonoBehaviour {
	private Text m_text;

	private ReceiveMessage m_receiver;
	private GameObject m_receiverGo;
	private Dictionary<string, ReceiveMessage> m_dict;

	private float m_timeSendMessage;
	private float m_timeBroadcastMessage;
	private float m_timeDirectCall;
	private float m_timeGetComponentCall;
	private float m_timeDictGetCall;
	private float m_timeDictContainsGetCall;
	private float m_timeDictTryGetCall;
	private float m_timeEventSystemLambdaCall;
	private float m_timeEventSystemMethodCall;
	private float m_timeEventSystemMethodHierachyDownCall;

	public int IterationCount = 9999;
	
	public void OnInstantiateReceiverChildClicked()
	{
		m_receiver.InstantiateChild(10);
	}
	public void On10CountClicked()
	{
		IterationCount = 10;
		ResetTime();
	}

	private void ResetTime()
	{
		m_timeSendMessage = 0.0f;
		m_timeBroadcastMessage = 0.0f;
		m_timeDirectCall = 0.0f;
		m_timeGetComponentCall = 0.0f;
		m_timeDictGetCall = 0.0f;
		m_timeDictContainsGetCall = 0.0f;
		m_timeDictTryGetCall = 0.0f;
		m_timeEventSystemLambdaCall = 0.0f;
		m_timeEventSystemMethodCall = 0.0f;
		m_timeEventSystemMethodHierachyDownCall = 0.0f;
	}

	public void On100CountClicked()
	{
		IterationCount = 100;
		ResetTime();
	}
	public void On1000CountClicked()
	{
		IterationCount = 1000;
		ResetTime();
	}
	public void On10000CountClicked()
	{
		IterationCount = 10000;
		ResetTime();
	}
	// Use this for initialization
	void Start () {
		m_text = GetComponent<Text>();
		m_receiver = GameObject.FindObjectOfType<ReceiveMessage>();
		m_receiverGo = m_receiver.gameObject;

		m_dict = new Dictionary<string, ReceiveMessage>();
		m_dict[ReceiveMessage.MessageName] = m_receiver;
	}
	
	// Update is called once per frame
	void Update () {
		int i;
		float time;

		Profiler.BeginSample("m_timeSendMessage");
		time = Time.realtimeSinceStartup;
		for(i = 0; i < IterationCount; ++i)
		{
			m_receiverGo.SendMessage(ReceiveMessage.MessageName);
		}
		Profiler.EndSample();
		if(m_timeSendMessage < float.Epsilon)
		{
			m_timeSendMessage = Time.realtimeSinceStartup - time;
		}
		else
		{
			m_timeSendMessage += Time.realtimeSinceStartup - time;
			m_timeSendMessage *= 0.5f;
		}


		Profiler.BeginSample("m_timeBroadcastMessage");
		time = Time.realtimeSinceStartup;
		for(i = 0; i < IterationCount; ++i)
		{
			m_receiverGo.BroadcastMessage(ReceiveMessage.MessageName);
		}
		Profiler.EndSample();
		if(m_timeBroadcastMessage < float.Epsilon)
		{
			m_timeBroadcastMessage = Time.realtimeSinceStartup - time;
		}
		else
		{
			m_timeBroadcastMessage += Time.realtimeSinceStartup - time;
			m_timeBroadcastMessage *= 0.5f;
		}


		Profiler.BeginSample("m_timeDirectCall");
		time = Time.realtimeSinceStartup;
		for(i = 0; i < IterationCount; ++i)
		{
			m_receiver.OnMessage();
		}
		Profiler.EndSample();
		if(m_timeDirectCall < float.Epsilon)
		{
			m_timeDirectCall = Time.realtimeSinceStartup - time;
		}
		else
		{
			m_timeDirectCall += Time.realtimeSinceStartup - time;
			m_timeDirectCall *= 0.5f;
		}

		Profiler.BeginSample("m_timeGetComponentCall");
		time = Time.realtimeSinceStartup;
		for(i = 0; i < IterationCount; ++i)
		{
			ReceiveMessage obj = m_receiverGo.GetComponent<ReceiveMessage>();
			obj.OnMessage();
		}
		Profiler.EndSample();
		if(m_timeGetComponentCall < float.Epsilon)
		{
			m_timeGetComponentCall = Time.realtimeSinceStartup - time;
		}
		else
		{
			m_timeGetComponentCall += Time.realtimeSinceStartup - time;
			m_timeGetComponentCall *= 0.5f;
		}
		
		Profiler.BeginSample("m_timeDictionaryCall");
		time = Time.realtimeSinceStartup;
		for(i = 0; i < IterationCount; ++i)
		{
			ReceiveMessage obj = m_dict[ReceiveMessage.MessageName];
			obj.OnMessage();
		}
		Profiler.EndSample();
		if(m_timeDictGetCall < float.Epsilon)
		{
			m_timeDictGetCall = Time.realtimeSinceStartup - time;
		}
		else
		{
			m_timeDictGetCall += Time.realtimeSinceStartup - time;
			m_timeDictGetCall *= 0.5f;
		}
		
		Profiler.BeginSample("m_timeDictContainsGetCall");
		time = Time.realtimeSinceStartup;
		for(i = 0; i < IterationCount; ++i)
		{
			if(m_dict.ContainsKey(ReceiveMessage.MessageName))
			{
				ReceiveMessage obj = m_dict[ReceiveMessage.MessageName];
                obj.OnMessage();
			}
		}
		Profiler.EndSample();
		if(m_timeDictContainsGetCall < float.Epsilon)
		{
			m_timeDictContainsGetCall = Time.realtimeSinceStartup - time;
		}
		else
        {
			m_timeDictContainsGetCall += Time.realtimeSinceStartup - time;
			m_timeDictContainsGetCall *= 0.5f;
		}
		
		Profiler.BeginSample("m_timeDictionaryCall");
		time = Time.realtimeSinceStartup;
		for(i = 0; i < IterationCount; ++i)
		{
			ReceiveMessage obj = null;
			m_dict.TryGetValue(ReceiveMessage.MessageName, out obj);
			obj.OnMessage();
		}
		Profiler.EndSample();
		if(m_timeDictTryGetCall < float.Epsilon)
		{
			m_timeDictTryGetCall = Time.realtimeSinceStartup - time;
		}
		else
		{
			m_timeDictTryGetCall += Time.realtimeSinceStartup - time;
			m_timeDictTryGetCall *= 0.5f;
        }
		
		Profiler.BeginSample("m_timeEventSystemLambdaCall");
		time = Time.realtimeSinceStartup;
		for(i = 0; i < IterationCount; ++i)
		{
			ExecuteEvents.Execute<IReceiveMessage>(m_receiverGo, null, (iReceiveMessage, param) => iReceiveMessage.OnMessage());
		}
		Profiler.EndSample();
		if(m_timeEventSystemLambdaCall < float.Epsilon)
		{
			m_timeEventSystemLambdaCall = Time.realtimeSinceStartup - time;
		}
		else
		{
			m_timeEventSystemLambdaCall += Time.realtimeSinceStartup - time;
			m_timeEventSystemLambdaCall *= 0.5f;
		}
		
		Profiler.BeginSample("m_timeEventSystemMethodCall");
		time = Time.realtimeSinceStartup;
		for(i = 0; i < IterationCount; ++i)
		{
			ExecuteEvents.Execute<IReceiveMessage>(m_receiverGo, null, DispatchReceiverEvent);
		}
		Profiler.EndSample();
		if(m_timeEventSystemMethodCall < float.Epsilon)
		{
			m_timeEventSystemMethodCall = Time.realtimeSinceStartup - time;
		}
		else
		{
			m_timeEventSystemMethodCall += Time.realtimeSinceStartup - time;
			m_timeEventSystemMethodCall *= 0.5f;
		}
		
		
		Profiler.BeginSample("m_timeEventSystemMethodHierachyDownCall");
		time = Time.realtimeSinceStartup;
		for(i = 0; i < IterationCount; ++i)
		{
			MoreExecuteEvents.ExecuteHierarchyDown<IReceiveMessage>(m_receiverGo, null, DispatchReceiverEvent);
		}
		Profiler.EndSample();
		if(m_timeEventSystemMethodHierachyDownCall < float.Epsilon)
		{
			m_timeEventSystemMethodHierachyDownCall = Time.realtimeSinceStartup - time;
		}
		else
		{
			m_timeEventSystemMethodHierachyDownCall += Time.realtimeSinceStartup - time;
			m_timeEventSystemMethodHierachyDownCall *= 0.5f;
		}

		string enableProfile = "disableProfiler";
#if ENABLE_PROFILER
		enableProfile = "enableProfiler";
#endif
		float minTime = Mathf.Min(m_timeBroadcastMessage, m_timeDirectCall, m_timeGetComponentCall, m_timeSendMessage, m_timeDictGetCall,
		                          m_timeEventSystemLambdaCall, m_timeEventSystemMethodCall, m_timeEventSystemMethodHierachyDownCall,
		                          m_timeDictContainsGetCall, m_timeDictTryGetCall);
		m_text.text = 
			enableProfile + "\n" +
			"IterationCount=" + IterationCount + "\n" +
				"ReceiverChildCount=" + m_receiver.transform.childCount + "\n" +
			"m_timeSendMessage=" + (m_timeSendMessage * 1000).ToString() + "ms, (" + (m_timeSendMessage / minTime).ToString()+ ")\n" +
				"m_timeBroadcastMessage=" + (m_timeBroadcastMessage * 1000).ToString() + "ms, (" + (m_timeBroadcastMessage / minTime).ToString()+ ")\n" +
				"m_timeDirectCall=" + (m_timeDirectCall * 1000).ToString() + "ms, (" + (m_timeDirectCall / minTime).ToString()+ ")\n" +
				"m_timeGetComponentCall=" + (m_timeGetComponentCall * 1000).ToString() + "ms, (" + (m_timeGetComponentCall / minTime).ToString()+ ")\n" +
				"m_timeDictionaryCall=" + (m_timeDictGetCall * 1000).ToString() + "ms, (" + (m_timeDictGetCall / minTime).ToString()+ ")\n" +
				"m_timeDictContainsGetCall=" + (m_timeDictContainsGetCall * 1000).ToString() + "ms, (" + (m_timeDictContainsGetCall / minTime).ToString()+ ")\n" +
				"m_timeDictTryGetCall=" + (m_timeDictTryGetCall * 1000).ToString() + "ms, (" + (m_timeDictTryGetCall / minTime).ToString()+ ")\n" +
				"m_timeEventSystemLambdaCall=" + (m_timeEventSystemLambdaCall * 1000).ToString() + "ms, (" + (m_timeEventSystemLambdaCall / minTime).ToString()+ ")\n" +
				"m_timeEventSystemMethodCall=" + (m_timeEventSystemMethodCall * 1000).ToString() + "ms, (" + (m_timeEventSystemMethodCall / minTime).ToString()+ ")\n" +
				"m_timeEventSystemMethodHierachyDownCall=" + (m_timeEventSystemMethodHierachyDownCall * 1000).ToString() + "ms, (" + (m_timeEventSystemMethodHierachyDownCall / minTime).ToString()+ ")\n" ;

	}

	private void DispatchReceiverEvent(IReceiveMessage ir, object param)
	{
		ir.OnMessage();
	}
}
