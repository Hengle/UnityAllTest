using UnityEngine;
using System.Collections;
using System.Text;
using System;
using UnityEngine.Profiling;

public class StringBuilderTest : MonoBehaviour
{
    private StringBuilder m_sb = new StringBuilder(64);
    private char[] m_chars = new char[64];
    private string m_string;
    // Use this for initialization
    void Start()
    {
    }
	
    // Update is called once per frame
    void Update()
    {
        DoTest2();
        DoTestStringBuilder();
        DoTestStringFormat();
        Debug.Log(m_string);
    }

    private void DoTest()
    {
        Profiler.BeginSample("Test");

        m_sb.Length = 0;
        m_sb.Append("Hello").Append("!");
        m_sb.CopyTo(0, m_chars, 0, m_sb.Length);

//        m_string = new string(m_chars);//GC Alloc: 154B, String.ctor()=154B;
//        m_string = new string(m_chars, 0, m_sb.Length); //GC Alloc: 38B, String.ctor()=38B;
        m_string = m_sb.ToString();//GC Alloc: 38B, String.SubstringUnchecked()=38B;

        Profiler.EndSample();
    }


    /// <summary>
    /// Good, 3.5M GC Alloc, 24.42ms
    /// </summary>
    private void DoTestStringBuilder()
    {
        Profiler.BeginSample("string builder append");
        for(int i = 0; i < 9999; ++i)
        {
            m_sb.Length = 0;
            m_sb.Append("She says two words to me: ").Append("Hello").Append(UnityEngine.Random.Range(0f, 1f)).Append("World").Append(UnityEngine.Random.Range(0f, 1f));
            m_sb.ToString();
        }
        Profiler.EndSample();
    }

    /// <summary>
    /// 4Bad, 4.5MB GC Alloc, 35.74ms
    /// </summary>
    private void DoTest2()
    {
        Profiler.BeginSample("string +");

        for(int i = 0; i < 9999; ++i)
        {
            m_string = null;
            m_string = "She says two words to me: " + UnityEngine.Random.Range(0f, 1f) + " " + UnityEngine.Random.Range(0f, 1f) + ".";
            m_string.ToString();
        }

        Debug.Log(m_string);

        Profiler.EndSample();
    }

    /// <summary>
    /// Very bad, 5.2MB GC Alloc, 44.22ms
    /// </summary>
    private void DoTestStringFormat()
    {
        Profiler.BeginSample("string format");
        for(int i = 0; i < 9999; ++i)
        {
            m_string = null;
            m_string = String.Format("She says two words to me: {0} {1}.", UnityEngine.Random.Range(0f, 1f), UnityEngine.Random.Range(0f, 1f));
            m_string.ToString();
        }
        Profiler.EndSample();
    }
}
