using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class information_Panel : BasePanel
{
    public static string path = "Canvas_information";
    public static string name = "Canvas_information";

    public readonly static UIType uiType = new UIType(path, name);

    public information_Panel():base(uiType)
    {

    }

    public override void OnStart()
    {
        base.OnStart();
        UIMehod.GetInstance().GetOrAddSingleComponentInChild<Button>(Activeobj, "Button").onClick.AddListener(back);
    }

    private void back()
    {
        GameRoot.GetInstance().uIManager_Root.Pop(false);
    }

    public override void OnEnable()
    {
        base.OnEnable();
    }

    public override void OnDisable()
    {
        base.OnDisable();
    }

    public override void OnDestroy()
    {
        base.OnDestroy();
    }
}
