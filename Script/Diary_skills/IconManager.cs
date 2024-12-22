using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IconManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static IconManager Instance;
    public D_icon_UI Icon_UI;
    public List<Diary_icon> IconList;
    public delegate void IconInventoryChange();
    public IconInventoryChange IconInventoryCallBack;
    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
        IconInventoryCallBack?.Invoke();
        DontDestroyOnLoad(this);
    }

    // Update is called once per frame
    public void Add(Diary_icon newIcon)
    { 
        IconList.Add(newIcon);
        IconInventoryCallBack?.Invoke();
    }

    public void Remove(Diary_icon oldIcon)
    {
        IconList.Remove(oldIcon);
        IconInventoryCallBack?.Invoke();
    }
    public void Clear()
    {
        IconList.Clear();
        IconInventoryCallBack?.Invoke();
    }
    public void Refresh()
    {
        IconInventoryCallBack?.Invoke();
    }
}
