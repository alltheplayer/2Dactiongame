using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Test1_Pane : BasePanel
{
    public static string path = "Canvas_test1";
    public static string name = "Canvas_test1";

    public readonly static UIType uiType = new UIType(path, name);

    public Test1_Pane():base (uiType)
    {

    }

    public override void OnStart()
    {
        base.OnStart();
        UIMehod.GetInstance().GetOrAddSingleComponentInChild<Button>(Activeobj, "Button_1").onClick.AddListener(Loadtest1);
        UIMehod.GetInstance().GetOrAddSingleComponentInChild<Button>(Activeobj, "Button_2").onClick.AddListener(Loadtest2);
        UIMehod.GetInstance().GetOrAddSingleComponentInChild<Button>(Activeobj, "Button_3").onClick.AddListener(Loadtest3);
        UIMehod.GetInstance().GetOrAddSingleComponentInChild<Button>(Activeobj, "back").onClick.AddListener(Back);
    }

    public void Loadtest1()
    {
        GameRoot.GetInstance().uIManager_Root.Push(new Test1_1_Panel());
    }

    public void Loadtest2()
    {
        GameRoot.GetInstance().uIManager_Root.Push(new Test1_2_Panel());
    }

    public void Loadtest3()
    {
        GameRoot.GetInstance().uIManager_Root.Push(new Test1_3_Panel());
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
