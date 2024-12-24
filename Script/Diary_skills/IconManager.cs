using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IconManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static IconManager Instance;
    public D_icon_UI Icon_UI;
    public List<Diary_icon> IconList;
    Diary_icon[] all_icon;
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

    void Start()
    {
        all_icon =Resources.LoadAll<Diary_icon> ("icon_skill");
    }

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
    public void Addicon(int index)
    {
        switch (index)
        {
            case 0:
                Add(all_icon[0]);
                break;
            case 1:
                
                break;
        }

    }
}
