using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenceControl 
{
    public Dictionary<string, ScenceBase> dict_scence;

    private static ScenceControl instance;

    public static ScenceControl GetInstance()
    {
        if (instance == null)
        {
            Debug.LogError("ScenceControl实体不存在");
            return instance;
        }
        return instance;
    }

    public int scene_num = 1;
    public string[] string_scene;

    public ScenceControl()
    {
        instance = this;

        dict_scence = new Dictionary<string, ScenceBase>();
    }

    public void LoadScence(string scence_name,ScenceBase scenceBase)
    {
        if(scene_num>=2)
        {
            foreach(string scenename in string_scene)
            {  
                if(scenename==scence_name)
                {
                    Debug.Log($"场景{scence_name}已被加载过");
                    break;
                }
                scene_num++;
                string_scene[scene_num] = scence_name;
            }
            
        }
        if(!dict_scence.ContainsKey(scence_name))
        {
            dict_scence.Add(scence_name, scenceBase);
        }


        if(scene_num>=2)
        {
            dict_scence[SceneManager.GetActiveScene().name].ExitScence();
        }

        scenceBase.EnterScence();
        GameRoot.GetInstance().uIManager_Root.Pop(true);
        SceneManager.LoadScene(scence_name);
    }


    public void Exitgame()
    {
     #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
     #else
            Application.Quit();
     #endif
    }

}
