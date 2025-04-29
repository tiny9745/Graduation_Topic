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
            case 1:
                Add(all_icon[5]);
                static_parameters.diary_number++;
                break;
            case 2:
                Add(all_icon[6]);
                static_parameters.diary_number++;
                break;
            case 3:
                Add(all_icon[7]);
                static_parameters.diary_number++;
                break;
            case 4:
                Add(all_icon[8]);
                static_parameters.diary_number++;
                break;
            case 5:
                Add(all_icon[9]);
                static_parameters.diary_number++;
                break;
            case 11:
                Add(all_icon[15]);
                static_parameters.diary_number++;
                break;
            case 12:
                Add(all_icon[16]);
                static_parameters.diary_number++;
                break;
            case 13:
                Add(all_icon[17]);
                static_parameters.diary_number++;
                break;
            case 14:
                Add(all_icon[18]);
                static_parameters.diary_number++;
                break;
            case 15:
                Add(all_icon[19]);
                static_parameters.diary_number++;
                break;
            case 21:
                Add(all_icon[0]);
                static_parameters.diary_number++;
                break;
            case 22:
                Add(all_icon[1]);
                static_parameters.diary_number++;
                break;
            case 23:
                Add(all_icon[2]);
                static_parameters.diary_number++;
                break;
            case 24:
                Add(all_icon[3]);
                static_parameters.diary_number++;
                break;
            case 25:
                Add(all_icon[4]);
                static_parameters.diary_number++;
                break;
            case 31:
                Add(all_icon[10]);
                static_parameters.diary_number++;
                break;
            case 32:
                Add(all_icon[11]);
                static_parameters.diary_number++;
                break;
            case 33:
                Add(all_icon[12]);
                static_parameters.diary_number++;
                break;
            case 34:
                Add(all_icon[13]);
                static_parameters.diary_number++;
                break;
            case 35:
                Add(all_icon[14]);
                static_parameters.diary_number++;
                break;
            case 41:
                Add(all_icon[20]);
                static_parameters.diary_number++;
                break;
            case 42:
                Add(all_icon[21]);
                static_parameters.diary_number++;
                break;
            case 43:
                Add(all_icon[22]);
                static_parameters.diary_number++;
                break;
            case 44:
                Add(all_icon[23]);
                static_parameters.diary_number++;
                break;
            case 45:
                Add(all_icon[24]);
                static_parameters.diary_number++;
                break;
            default:
                break;
        }

    }
}
