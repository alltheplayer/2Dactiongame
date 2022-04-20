using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Test1_1_Panel : BasePanel
{
    public static string path = "Canvas_Test1_1";
    public static string name = "Canvas_Test1_1";

    public readonly static UIType uiType = new UIType(path, name);

    public Test1_1_Panel() : base(uiType)
    {

    }

    public override void OnStart()
    {
        base.OnStart();
        UIMehod.GetInstance().GetOrAddSingleComponentInChild<Button>(Activeobj, "Button").onClick.AddListener(Back);
    }

    public void Back()
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
