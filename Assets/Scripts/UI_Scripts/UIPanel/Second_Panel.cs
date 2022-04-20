using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Second_Panel : BasePanel
{
    public static string path = "Canvas_2";
    public static string name = "Canvas_2";

    public static readonly UIType uitype = new UIType(path,name);

    public Second_Panel() : base(uitype)
    {

    }

    public override void OnStart()
    {
        base.OnStart();
        UIMehod.GetInstance().GetOrAddSingleComponentInChild<Button>(Activeobj,"Button3").onClick.AddListener(BackMenu);
        UIMehod.GetInstance().GetOrAddSingleComponentInChild<Button>(Activeobj, "Button_1").onClick.AddListener(Loadinformation);
        UIMehod.GetInstance().GetOrAddSingleComponentInChild<Button>(Activeobj, "Back").onClick.AddListener(Back);
    }

    public void Back()
    {
        GameRoot.GetInstance().uIManager_Root.Pop(false);
        GameRoot.isExit = false;
        Time.timeScale = 1;
    }

    public void Loadinformation()
    {
        GameRoot.GetInstance().uIManager_Root.Push(new information_Panel());
    }

    public void BackMenu()
    {
        Scene1 scene1=new Scene1();
        GameRoot.GetInstance().uIManager_Root.Pop(true);
        GameRoot.isExit=false;
        Time.timeScale = 1;
        GameRoot.GetInstance().ScenceControl_Root.LoadScence(scene1.Scene_name, scene1);
        GameRoot.isExit=true;
        GameRoot.GetInstance().uIManager_Root.Push(new First_Panel());
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
