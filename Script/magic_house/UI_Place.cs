using UnityEngine.UI;
using UnityEngine;

public class UI_Place : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Upgrade;
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
        if (Input.GetKeyDown(KeyCode.F) && P1)
        {
            isUpgrade = !isUpgrade; 
            if (isUpgrade)
            {
                magician_talk_object.SetActive(true);
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
            Upgrade.SetActive(true);
            Ad.PlayOneShot(Open);
        }
        else
        {
            Upgrade.SetActive(false);
        }
    }

    public void magician_talk_open()
    {
        magician_talk.Magician_Talk();
    }
}
