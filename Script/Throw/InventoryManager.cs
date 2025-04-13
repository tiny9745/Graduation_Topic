using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    #region Singleton
    public static InventoryManager Instance;
    public GameObject bullet00, bullet01, bullet14_01, bullet43, bullet44;
    public Transform Firepoint;
    public ItemSlot _slot;
    public List<Item> ItemList;
    public delegate void onInventoryChange();
    public onInventoryChange onInventoryCallBack;
    public AudioSource MC_throw_sound;
    public AudioClip[] audioClip; // 音效片段

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
        DontDestroyOnLoad(this);
    }
    #endregion

    private void Update()
    {
        if (ItemList.Count > 0)
        {
            if (Input.GetKeyDown(KeyCode.K) && static_parameters.Ani_state < 3 && static_parameters.teaching_stop >= 2 && static_parameters.isTeaching == false)
            {
                bullet_fire();
            }
        }
    }

    public void Add(Item newItem)
    {
        if (ItemList.Count < 4)
        {
            MC_throw_sound.PlayOneShot(audioClip[1]);
            ItemList.Add(newItem);
        }
    }

    public void Remove(Item oldItem)
    {
        ItemList.Remove(oldItem);
    }

    public void bullet_fire()
    {
        if (static_parameters.MC_HP > 0)
        {
            MC_throw_sound.PlayOneShot(audioClip[0]);
            bullet_into();
            _slot.UseItem();
            if (Skill_public_funtion.skill_14_enter)
            {
                Invoke("bullet_into14", 0.25f);
            }
        }
    }

    private void bullet_into()
    {
        if (_slot.slotID == 2)
        {
            Instantiate(bullet00, Firepoint.position, transform.rotation);
        }
        else if (_slot.slotID == 1)
        {
            Instantiate(bullet01, Firepoint.position, transform.rotation);
        }
        else if (_slot.slotID == 43)//預置物暫時未套用43，目前設為01
        {
            Instantiate(bullet43, Firepoint.position, transform.rotation);
        }
        else if (_slot.slotID == 44)//回血道具
        {
            Instantiate(bullet44, Firepoint.position, transform.rotation);
        }
    }
    public void Clear()
    {
        ItemList.Clear();
    } 

    private void bullet_into14()
    {
        if (_slot.slotID == 1)
        {
            Instantiate(bullet14_01, Firepoint.position, transform.rotation);
        }
        // else if (_slot.slotID == 43)//預置物暫時未套用43，目前設為01
        // {
        //     Instantiate(bullet43, Firepoint.position, transform.rotation);
        // }
    }
}
