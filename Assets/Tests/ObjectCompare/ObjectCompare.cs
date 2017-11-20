using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ObjectCompare : MonoBehaviour {
	public GameObject prefab;
	private GameObject m_go;
	private Transform m_trans;
	public Text m_text;
	// Use this for initialization
	IEnumerator Start () {
		m_go = Instantiate(prefab) as GameObject;
		m_trans = m_go.transform;
		yield return null;
		Destroy(m_go);
		yield return null;
	}
	
	// Update is called once per frame
	void Update () {

		string str;
		if(m_go.IsValid())
		{
			str = "m_go.IsValid();";
		}
		else
		{
			str = "false == m_go.IsValid();";
		}
		Debug.Log(str);
		m_text.text = m_text.text + str;

		
		if(m_trans.IsValid())
		{
			str = "m_trans.IsValid();";
		}
		else
		{
			str = "false == m_trans.IsValid();";
		}
		Debug.Log(str);
		m_text.text = m_text.text + str;


		object obj = m_go;
		if(obj.IsValid())
		{
			str = "obj.IsValid();";
		}
		else
		{
			str = "false == obj.IsValid();";
		}
		Debug.Log(str);
		m_text.text = m_text.text + str;

	}
}
