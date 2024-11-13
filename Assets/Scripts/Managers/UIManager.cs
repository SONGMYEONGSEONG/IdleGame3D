using System;
using System.Collections.Generic;
using UnityEngine;
using Utill;

public class UIManager : Singleton<UIManager>
{
    [SerializeField] private List<UIBase> UIList;

    private Dictionary<string, UIBase> UIDictionary = new Dictionary<string, UIBase>();

    protected override void Awake()
    {
        base.Awake();

        for (int i = 0; i < UIList.Count; i++)
        {
            UIDictionary.Add(UIList[i].UIName, UIList[i]);
        }
    }

    public void UISet(UIBase UI)
    {
        UIDictionary.Add(UI.UIName, UI);
    }

    public T GetUI<T>(string UIName) where T : UIBase
    {
        if(UIDictionary.ContainsKey(UIName))
        {
            return UIDictionary[UIName] as T;
        }
        else
        {
            Debug.Log("해당 UI가 존재하지 않습니다.");
            return null;
        }
        
    }
}

