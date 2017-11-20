using MoreFun;
using UnityEngine;

/// <summary>
/// Global functions wihout namespace for easy access.
/// Do NOT add functions here UNLESS it's very useful.
/// </summary>
public static class MoreGlobal
{
    #region IsValid
    public static bool IsValid(this object obj)
	{
		bool ret = false;
        if(null != obj)
        {
			ret = true;
        }
        else
        {
			ret = false;
		}
		Debug.Log("IsValid(this object obj): " + ret);
		return ret;
    }

    public static bool IsValid(this Object obj)
    {
		bool ret = false;
        if(null != obj)
        {
			ret = true;
        }
        else
        {
			ret = false;
		}
		Debug.Log("IsValid(this Object obj): " + ret);
		return ret;
    }
    
    public static bool IsValid(this string obj)
	{
		bool ret = !(string.IsNullOrEmpty(obj));
		Debug.Log("IsValid(this string obj): " + ret);
		return ret;
    }

    public static bool IsValid(this Component obj)
    {
		bool ret = false;
        if(null != obj && null != obj.gameObject)
        {
			ret = true;
        }
        else
        {
			ret = false;
        }
		
		Debug.Log("IsValid(this Component obj): " + ret);
		return ret;
    }
    
    public static bool IsValid(this System.Collections.IList collection, int index)
    {
		bool ret = false;
		Debug.Log("");
		if(collection != null)
		{
			if(0 <= index && index < collection.Count)
			{
				ret = true;
			}
		}
		
		Debug.Log("IsValid(this System.Collections.IList collection, int index): " + ret);
		return ret;
    }

    /// <summary>
    /// <para>Check a chain of objects for their validation.</para>
    /// <para>Note, you can call <c>IsValid(obj1, obj2)</c>.  
    /// <para>But do NOT call like this: </para>
    /// <para><c>IsValid(obj1, obj1.obj2)</c></para>, 
    /// because when you call <c>obj1.obj2</c>, it's NOT guaranteed that <c>obj1</c> is not null, 
    /// and may cause exception!</para>
    /// </summary>
    /// <returns><c>true</c> if is valid the specified list; otherwise, <c>false</c>.</returns>
    /// <param name="list">List.</param>
    public static bool IsValid(params object[] list)
	{
		bool ret = false;
        if(null != list)
        {
            for(int i = 0; i < list.Length; ++i)
            {
                if(null == list[i])
                {
					ret = false;
                }
            }
            
			ret = true;
        }
        else
        {
			ret = false;
		}
		
		Debug.Log("IsValid(params object[] list): " + ret);
		return ret;
    }
    #endregion
}

