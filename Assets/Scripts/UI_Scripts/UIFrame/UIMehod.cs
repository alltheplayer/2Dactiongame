using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIMehod { 
  
    private static UIMehod instance;

    public static UIMehod GetInstance()
    {
        if(instance == null)
        {
            instance = new UIMehod();
            return instance;
        }else
        {
            return instance;
        }
    }

    public GameObject FindCanvas()
    {
        GameObject gameObject = GameObject.FindObjectOfType<Canvas>().gameObject;
        if(gameObject == null)
        {
            Debug.LogError("在场景中没有找到Canvas");
            return gameObject;
        }
        return gameObject;
    }

    public GameObject FindObjectInChild(GameObject panel,string child_name)
    {
        Transform[] transforms=panel.GetComponentsInChildren<Transform>();
        foreach(Transform t in transforms)
        {
            if(t.gameObject.name == child_name)
            {
                return t.gameObject;
            }
        }
        Debug.LogWarning($"在{panel.name}物体中没找到{child_name}物体");
            return null;
    }

    public T AddOrGetComponent<T>(GameObject gameObject) where T:Component
    {
   
        if (gameObject.GetComponent<T>()!=null)
        {
            
            return gameObject.GetComponent<T>();
        }
            Debug.LogWarning($"未能找到{gameObject.name}");
            return null;
        
    }

    public T GetOrAddSingleComponentInChild<T>(GameObject panel,string ComponentName) where T:Component
    {
        Transform[] transforms = panel.GetComponentsInChildren<Transform>();
        foreach(Transform tra in transforms)
        {
            if(tra.gameObject.name==ComponentName)
            {
                return tra.gameObject.GetComponent<T>();
               
            }
        }
        Debug.LogWarning($"在{panel.name}中未能找到{ComponentName}");
        return null;
    }
}
