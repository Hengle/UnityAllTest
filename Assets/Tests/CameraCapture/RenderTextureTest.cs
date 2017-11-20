using UnityEngine;
using System.Collections;

public class RenderTextureTest : MonoBehaviour
{

		private RenderTexture m_renderTexture;
		private RenderTexture m_renderTextureStart;
		private Camera m_camera;
		public bool useRT = false;

		// Use this for initialization
		IEnumerator Start()
		{
		
				m_camera = GetComponent<Camera>();
				m_renderTextureStart = RenderTexture.GetTemporary((int)m_camera.pixelWidth, (int)m_camera.pixelHeight);

				RenderTexture.active = m_renderTextureStart;
				Debug.Log(gameObject.name + ".Start, " + RenderTexture.active);
				m_renderTexture = RenderTexture.GetTemporary((int)m_camera.pixelWidth, (int)m_camera.pixelHeight);


				while (true)
				{
						yield return new WaitForEndOfFrame ();
						Debug.Log(gameObject.name + ".WaitForEndOfFrame, " + RenderTexture.active);
				}
		}
	
		// Update is called once per frame
		void Update()
		{
	
		}

		void OnPreRender()
		{
				if (useRT)
				{
						m_camera.targetTexture = m_renderTexture;
				}
				else
				{
						m_camera.targetTexture = null;
				}
				Debug.Log(gameObject.name + ".OnPreRender, " + RenderTexture.active);
		}

		void OnPostRender()
		{
				Debug.Log(gameObject.name + ".OnPostRender, " + RenderTexture.active);
		}

		void OnDestroy()
		{
				RenderTexture.ReleaseTemporary(m_renderTexture);
		}


}
