using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager {
    //存储ui_panel的栈结构
    public Stack<BasePanel> stack_ui;
    //存储panel名称与物体的对应关系
    public Dictionary<string, GameObject> dict_uiobject;
    //当前场景下的Canvas
    public GameObject CanvasObj;
    //单例
    private static UIManager instance;
    public static UIManager GetInstance()
    {
        if (instance == null)
        {
            Debug.LogError("UIManager不存在!");
            return instance;
        }else
        {
            return instance; 
        }
    }

    public UIManager()
    {
        instance = this;
        stack_ui=new Stack<BasePanel>();
        dict_uiobject=new Dictionary<string, GameObject>();
    }

    public GameObject GetSingleObject(UIType uIType)
    {

        if(dict_uiobject.ContainsKey(uIType.Name))
        {
            return dict_uiobject[uIType.Name];
        }
        if(CanvasObj==null)
        {
            CanvasObj=UIMehod.GetInstance().FindCanvas();

        }
        if(!dict_uiobject.ContainsKey(uIType.Name))
        {
            if(CanvasObj==null)
            {
                return null;
            }else
            {
                GameObject gameObjet = GameObject.Instantiate<GameObject>(Resources.Load<GameObject>(uIType.Path), CanvasObj.transform);
                return gameObjet;
            }

        }

        return null;
    }


    //入栈操作
    public void Push(BasePanel basePanel)
    {
        Debug.Log($"{basePanel.uIType.Name}被Push进stack");
        if(stack_ui.Count > 0)
        {
            stack_ui.Peek().OnDisable();
        }

        GameObject ui_object=GetSingleObject(basePanel.uIType);
        dict_uiobject.Add(basePanel.uIType.Name,ui_object);
        basePanel.Activeobj = ui_object;
        
        if(stack_ui.Count==0)
        {
            stack_ui.Push(basePanel);
        }else
        {
            if(stack_ui.Peek().uIType.Name!=basePanel.uIType.Name)
            {
                stack_ui.Push(basePanel);
            }

        }
        //此处用于控制ui弹出动画
        AttackScence.GetInstance().Showpanel(basePanel.Activeobj);
        basePanel.OnStart();    
    }

    //出栈
    public void Pop(bool isload)
    {
        if(isload==true)
        {
            if(stack_ui.Count>0)
            {
                stack_ui.Peek().OnDisable();
                stack_ui.Peek().OnDestroy();
                GameObject.Destroy(dict_uiobject[stack_ui.Peek().uIType.Name]);
                dict_uiobject.Remove(stack_ui.Peek().uIType.Name);
                stack_ui.Pop();
                Pop(true);
            }
        }
        if(isload==false)
        {
            if(stack_ui.Count>0)
            {
                stack_ui.Peek().OnDisable();
                stack_ui.Peek().OnDestroy();
                GameObject.Destroy(dict_uiobject[stack_ui.Peek().uIType.Name]);
                dict_uiobject.Remove(stack_ui.Peek().uIType.Name);
                stack_ui.Pop();

                if (stack_ui.Count > 0)
                {
                    stack_ui.Peek().OnEnable();
                }

            }
        }
    }
}
