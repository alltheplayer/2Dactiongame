using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasePanel 
{
    public UIType uIType;


    //在panel场景中对应的物体
    public GameObject Activeobj;

    public BasePanel(UIType uitype)
    {
        uIType = uitype;
    }

    public virtual void OnStart()
    {
        Debug.Log($"{uIType.Name}已经开始使用");

        if(Activeobj.GetComponent<CanvasGroup>()== null)
        {
            Activeobj.AddComponent<CanvasGroup>();
        }
        
    }

    public virtual void OnEnable()
    {
        UIMehod.GetInstance().AddOrGetComponent<CanvasGroup>(Activeobj).interactable = true;
    }

    public virtual void OnDisable()
    {
        UIMehod.GetInstance().AddOrGetComponent<CanvasGroup>(Activeobj).interactable=false;
    }

    public virtual void OnDestroy()
    {
        UIMehod.GetInstance().AddOrGetComponent<CanvasGroup>(Activeobj).interactable = false;
    }
}
