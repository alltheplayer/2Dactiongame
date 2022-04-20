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
            Debug.LogError("�ڳ�����û���ҵ�Canvas");
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
        Debug.LogWarning($"��{panel.name}������û�ҵ�{child_name}����");
            return null;
    }

    public T AddOrGetComponent<T>(GameObject gameObject) where T:Component
    {
   
        if (gameObject.GetComponent<T>()!=null)
        {
            
            return gameObject.GetComponent<T>();
        }
            Debug.LogWarning($"δ���ҵ�{gameObject.name}");
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
        Debug.LogWarning($"��{panel.name}��δ���ҵ�{ComponentName}");
        return null;
    }
}
