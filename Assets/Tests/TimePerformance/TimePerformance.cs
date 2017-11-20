using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Profiling;

public class TimePerformance : MonoBehaviour {
    private float m_fStepInv;
    private float m_fTimeStamp;

    private long m_nowTimeStamp;

    private float m_utcNowTimeStamp;

    private long m_step;

    private uint m_fixedTick;
    public int TestCount = 99999;
	// Use this for initialization
	void Start () {
        m_fStepInv = 1f / 0.033f;
        m_fTimeStamp = Time.realtimeSinceStartup;

        m_nowTimeStamp = DateTime.Now.Ticks;
        m_utcNowTimeStamp = DateTime.UtcNow.Ticks;

        m_step = 1000 * 10 * 33;
	}
	
	// Update is called once per frame
	void Update () {

        /// "now" performance comparison (in macbook pro 2017):
        /// realtimeSinceStartup : UtcNow : Now = 10ms : 15ms : 25ms

        /// GC:0Byte; CPU Time:10ms
        /// 因为是sinceStartUp，所以每次调用接口时，不用获取系统时间，Unity自己内部做时间累积就好了，性能更加好
        Profiler.BeginSample("realtimeSinceStartup");
        for(int i = 0; i < TestCount; ++i)
        {
            m_fixedTick = (uint)((Time.realtimeSinceStartup - m_fTimeStamp) * m_fStepInv);
        }
        Profiler.EndSample();

        /// GC:0Byte; CPU Time:13ms
        /// UtcNow拿到系统时区的当前时间。因为是绝对时间，所以每次调用接口时，需获取系统时间，性能比较差
        Profiler.BeginSample("UtcNow");
        for(int i = 0; i < TestCount; ++i)
        {
            m_fixedTick = (uint)((DateTime.UtcNow.Ticks - m_utcNowTimeStamp) / m_step);
        }
        Profiler.EndSample();

        /// GC:0Byte; CPU Time:19ms
        /// Now里面调用了UtcNow，并需要做额外操作：把时区偏移到时区=0的时间，所以性能比UtcNow更差
        Profiler.BeginSample("Now");
        for(int i = 0; i < TestCount; ++i)
        {
            m_fixedTick = (uint)((DateTime.Now.Ticks - m_nowTimeStamp) / m_step);
        }
        Profiler.EndSample();


        /// GC:0Byte; CPU Time:2ms
        for(int i = 0; i < TestCount; ++i)
        {
            m_fixedTick = (uint)Time.frameCount;
        }
        Profiler.EndSample();

	}
}
