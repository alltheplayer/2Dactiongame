using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameRoot : MonoBehaviour
{
    private UIManager uIManager;
    public UIManager uIManager_Root { get=>uIManager;}

    private ScenceControl scenceControl;
    public ScenceControl ScenceControl_Root { get => scenceControl; }

    private static GameRoot instance;



    public static bool isExit;

    public static GameRoot GetInstance()
    {
        if (instance == null)
        {
            Debug.LogError("获取GameRoot实例失败");
            return null;
        }
        return instance;
    }

    private void Awake()
    {
        if(instance== null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
        uIManager = new UIManager();
        scenceControl=new ScenceControl();
    }

    private void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        uIManager_Root.CanvasObj=UIMehod.GetInstance().FindCanvas();


        //第一个场景手动加载
        Scene1 scene1 = new Scene1();
        isExit=true;
        ScenceControl_Root.dict_scence.Add(scene1.Scene_name, scene1);



        #region 推入第一个面板
        uIManager_Root.Push(new First_Panel());

        #endregion
    }
    public void Update()
    {
        Exitmenu();
    }


    public void Exitmenu()
    {
        if(Input.GetKeyDown(KeyCode.Escape)&&isExit==false)
        {
            GameRoot.GetInstance().uIManager_Root.Push(new Second_Panel());
            Time.timeScale=0;
            isExit=true;
        }
    }
}
