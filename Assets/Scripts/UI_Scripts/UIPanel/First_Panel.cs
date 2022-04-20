using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class First_Panel : BasePanel
{
    public static string name = "Canvas_1";
    public static string path = "Canvas_1";

    public static readonly UIType uiType = new UIType(path, name);

    public First_Panel():base(uiType)
    {

    }

    public override void OnStart()
    {
        base.OnStart();
        
        UIMehod.GetInstance().GetOrAddSingleComponentInChild<Button>(Activeobj, "Button_1").onClick.AddListener(LoadScene2);
        UIMehod.GetInstance().GetOrAddSingleComponentInChild<Button>(Activeobj, "Button_2").onClick.AddListener(ShowInformation);
        UIMehod.GetInstance().GetOrAddSingleComponentInChild<Button>(Activeobj, "Button_3").onClick.AddListener(ShowTest1_panel);
        UIMehod.GetInstance().GetOrAddSingleComponentInChild<Button>(Activeobj, "Button_4").onClick.AddListener(Exitgame);
    }

    public void ShowInformation()
    {
        GameRoot.GetInstance().uIManager_Root.Push(new information_Panel());
    }

    public void LoadScene2()
    {
        Scene2 scene2 = new Scene2();

        GameRoot.GetInstance().ScenceControl_Root.LoadScence(scene2.Scene_name, scene2);
        
        GameRoot.GetInstance().uIManager_Root.Push(new Choose_Panel());
        
    }

    public void ShowTest1_panel()
    {
        GameRoot.GetInstance().uIManager_Root.Push(new Test1_Pane());   
    }


    public void Exitgame()
    {
        GameRoot.GetInstance().ScenceControl_Root.Exitgame();
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
