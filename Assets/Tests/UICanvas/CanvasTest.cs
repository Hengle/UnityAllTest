using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class CanvasTest : MonoBehaviour {
    private Canvas m_canvas;
    public float referencePixelsPerUnit;
    public float scaleFactor;
	// Use this for initialization
	void Start () {
        m_canvas = GetComponent<Canvas>();
        referencePixelsPerUnit = m_canvas.referencePixelsPerUnit;
        scaleFactor = m_canvas.scaleFactor;
	}
	
	// Update is called once per frame
	void Update () {
        m_canvas.referencePixelsPerUnit = referencePixelsPerUnit;
        m_canvas.scaleFactor = scaleFactor;
	}
}
