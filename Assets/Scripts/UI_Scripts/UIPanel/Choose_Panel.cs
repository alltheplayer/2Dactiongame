using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Choose_Panel : BasePanel
{
    public static string path = "Canvas_choose";
    public static string name = "Canvas_choose";

    public readonly static UIType uiType = new UIType(path, name);

    public Choose_Panel():base(uiType)
    {

    }

    public override void OnStart()
    {
        base.OnStart();
        GameRoot.isExit = false;
        UIMehod.GetInstance().GetOrAddSingleComponentInChild<Button>(Activeobj, "Button_1").onClick.AddListener(LoadScene1);
        UIMehod.GetInstance().GetOrAddSingleComponentInChild<Button>(Activeobj, "Button_2").onClick.AddListener(LoadScene2);
        UIMehod.GetInstance().GetOrAddSingleComponentInChild<Button>(Activeobj, "Button_3").onClick.AddListener(LoadScene3);
    }

    public void LoadScene1()
    {   
        Scene_level1 scene1=new Scene_level1();
        GameRoot.GetInstance().ScenceControl_Root.LoadScence(scene1.Scene_name, scene1);
    }

    public void LoadScene2()
    {
        Scene_level2 scene2=new Scene_level2();
        GameRoot.GetInstance().ScenceControl_Root.LoadScence(scene2.Scene_name, scene2);
    }

    public void LoadScene3()
    {
        Scene_level3 scene3=new Scene_level3();
        GameRoot.GetInstance().ScenceControl_Root.LoadScence(scene3.Scene_name,scene3);
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
