using UnityEngine;
using System.Collections;
using UnityEditor;

public class BuildAB
{
    [MenuItem("Assets/BuildAB_Selected")]
    public static void BuildAB_Selected()
    {
        if(null != Selection.activeGameObject)
        {
            string path = Application.persistentDataPath + "/" + Selection.activeGameObject.name;
            Debug.Log(path);
						/*
            BuildPipeline.BuildAssetBundle(Selection.activeGameObject, Selection.gameObjects, path,
                                           BuildAssetBundleOptions.CollectDependencies | BuildAssetBundleOptions.CompleteAssets);
                                           */
        }
    }
}
