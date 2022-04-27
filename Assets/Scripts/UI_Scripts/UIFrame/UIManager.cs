using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager {
    //�洢ui_panel��ջ�ṹ
    public Stack<BasePanel> stack_ui;
    //�洢panel����������Ķ�Ӧ��ϵ
    public Dictionary<string, GameObject> dict_uiobject;
    //��ǰ�����µ�Canvas
    public GameObject CanvasObj;
    //����
    private static UIManager instance;
    public static UIManager GetInstance()
    {
        if (instance == null)
        {
            Debug.LogError("UIManager������!");
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


    //��ջ����
    public void Push(BasePanel basePanel)
    {
        Debug.Log($"{basePanel.uIType.Name}��Push��stack");
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
        //�˴����ڿ���ui��������
        AttackScence.GetInstance().Showpanel(basePanel.Activeobj);
        basePanel.OnStart();    
    }

    //��ջ
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
