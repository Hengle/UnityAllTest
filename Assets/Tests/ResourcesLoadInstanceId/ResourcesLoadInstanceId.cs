using UnityEngine;
using System.Collections;

public class ResourcesLoadInstanceId : MonoBehaviour
{
    public GameObject prefabParam;

    // Use this for initialization
    IEnumerator Start()
    {
        GameObject prefab;

        prefab = prefabParam;
        Debug.Log("prefabParam=" + prefab.ToString() + ", id=" + prefab.GetInstanceID());

        prefab = Resources.Load("PrefabInResources") as GameObject;
        Debug.Log("prefab=Resources.Load(), prefab=" + prefab.ToString() + ", id=" + prefab.GetInstanceID());
        
        prefab = Resources.Load("PrefabInResources") as GameObject;
        Debug.Log("prefab=Resources.Load() 2, prefab=" + prefab.ToString() + ", id=" + prefab.GetInstanceID());

        string abPath = "file://" + Application.persistentDataPath + "/" + prefab.name;
        WWW w3;
        AssetBundle ab;

        w3 = WWW.LoadFromCacheOrDownload(abPath, 0);
        yield return w3;
        ab = w3.assetBundle;
        Debug.Log("abPath=" + abPath);
        Debug.Log("ab=" + ab);
        
        prefab = ab.mainAsset as GameObject;
        Debug.Log("prefab=ab.mainAsset 1, prefab=" + prefab.ToString() + ", id=" + prefab.GetInstanceID());

        ab = w3.assetBundle;
        prefab = ab.mainAsset as GameObject;
        Debug.Log("prefab=ab.mainAsset 2, prefab=" + prefab.ToString() + ", id=" + prefab.GetInstanceID());

        ab.Unload(false);
        Debug.Log("after ab.Unload(unloadAllLoadedObjects=false), prefab=" + prefab.ToString() + ", id=" + prefab.GetInstanceID() +
            ", prefab.transform=" + prefab.transform);
        //prefab = ab.mainAsset as GameObject;
        Debug.Log("after ab.Unload(unloadAllLoadedObjects=false), can NOT call ab anymore");
        
        w3 = WWW.LoadFromCacheOrDownload(abPath, 0);
        yield return w3;
        ab = w3.assetBundle;
        prefab = ab.mainAsset as GameObject;
        Debug.Log("prefab=ab.mainAsset 3, prefab=" + prefab.ToString() + ", id=" + prefab.GetInstanceID());
        ab = w3.assetBundle;
        prefab = ab.mainAsset as GameObject;
        Debug.Log("prefab=ab.mainAsset 4, prefab=" + prefab.ToString() + ", id=" + prefab.GetInstanceID());

        ab.Unload(true);
        string log = "after ab.Unload(unloadAllLoadedObjects=true), prefab=" + prefab.ToString() + ", id=" + prefab.GetInstanceID();
        Debug.Log(log);
        log += ", prefab.transform=" + prefab.transform;
        Debug.Log(log);


    }
    
    // Update is called once per frame
    void Update()
    {
    
    }
}
