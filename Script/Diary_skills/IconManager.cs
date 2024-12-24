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
        all_icon = Resources.LoadAll<Diary_icon>("Piece/icon_skill");
    }

    public void Add(Diary_icon newIcon)
    {
        IconList.Add(newIcon);
        Debug.Log("newIcon"+newIcon);
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
        Debug.Log("Addicon");
        if (index >= all_icon.Length)
        {
            Debug.Log("Inventory is full");
            return;
        }
        else
        {
            Debug.Log("Addicon2");
            switch (index)
            {
                case 0:
                    Add(all_icon[0]);
                    break;
                case 1:
                    Add(all_icon[1]);
                    break;
                case 2:
                    Add(all_icon[2]);
                    break;
                case 3:
                    Add(all_icon[3]);
                    break;
                case 4:
                    Add(all_icon[4]);
                    break;
                case 5:
                    Add(all_icon[5]);
                    Debug.Log("newIcon"+all_icon[5]);
                    break;
                case 6:
                    Add(all_icon[6]);
                    break;
                case 7:
                    Add(all_icon[7]);
                    break;
                case 8:
                    Add(all_icon[8]);
                    break;
            }
        }
    }
}
