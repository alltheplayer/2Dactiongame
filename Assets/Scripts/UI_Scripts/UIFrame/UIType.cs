using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIType
{
    private string name;
    private string path;


    //�����path,name�ķ��������Ҳ����޸�path,name
    public string Path { get => path; }
    public string Name { get => name; }


    public UIType(string ui_path, string ui_name)
    {
        path = ui_path;
        name = ui_name;
    }
}
