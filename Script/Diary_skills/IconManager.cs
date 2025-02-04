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
            case 9:
                Add(all_icon[9]);
                break;
            case 10:
                Add(all_icon[10]);
                break;
            case 11:
                Add(all_icon[11]);
                break;
            case 12:
                Add(all_icon[12]);
                break;
            case 13:
                Add(all_icon[13]);
                break;
            case 14:
                Add(all_icon[14]);
                break;
            case 15:
                Add(all_icon[15]);
                break;
            case 16:
                Add(all_icon[16]);
                break;
            case 17:
                Add(all_icon[17]);
                break;
            case 18:
                Add(all_icon[18]);
                break;
            case 19:
                Add(all_icon[19]);
                break;
            case 20:
                Add(all_icon[20]);
                break;
            case 21:
                Add(all_icon[21]);
                break;
            case 22:
                Add(all_icon[22]);
                break;
            case 23:
                Add(all_icon[23]);
                break;
            case 24:
                Add(all_icon[24]);
                break;
            case 25:
                Add(all_icon[25]);
                break;
            default:
                Debug.Log("Inventory is full");
                break;
        }

    }
}
