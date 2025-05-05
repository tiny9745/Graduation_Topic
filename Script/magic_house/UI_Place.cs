using UnityEngine.UI;
using UnityEngine;

public class UI_Place : MonoBehaviour
{
    public Upgrade UP;
    public GameObject Ugrade;
    public SpriteRenderer buttonImage;
    public Sprite F, none;
    public bool isUpgrade, P1 = false;
    public AudioSource Ad;
    public AudioClip Open;
    public Magician_talk magician_talk;
    public GameObject magician_talk_object;
    void Start()
    {
        P1 = false;
        // buttonImage.sprite = none;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && P1 && !Setting_keybroad.ESC_col)
        {
            isUpgrade = !isUpgrade;
            static_parameters.isUpgrade_tmp = true;
            if (isUpgrade)
            {
                magician_talk_object.SetActive(true);
                magician_talk_open();
            }
            else
            {
                magician_talk.close_magician_talk();
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            P1 = true;
            buttonImage.sprite = F;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            P1 = false;
            buttonImage.sprite = none;
        }
    }
    public void UI1()
    {
        if (isUpgrade)
        {
            Ugrade.SetActive(true);
            UP.check(Upgrade.ATK_LV, Upgrade.DEF_LV, Upgrade.HP_LV, Upgrade.Speed_LV, Upgrade.Knockback_LV);
            Ad.PlayOneShot(Open);
            static_parameters.MC_NPC_col_move = false;
        }
        else
        {
            static_parameters.isUpgrade_tmp = false;
            static_parameters.MC_NPC_col_move = true;
            Ugrade.SetActive(false);
        }
    }

    public void magician_talk_open()
    {
        if (Magician_talk.talk_number_M > 2)
        {
            Magician_talk.talk_number_M = Random.Range(3, 15);
        }
        magician_talk.into_talk_step = 0;
        magician_talk.Magician_Talk();
    }
}
