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
    void Start()
    {
        P1 = false;
        buttonImage.sprite = none;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && P1)
        {
            isUpgrade = !isUpgrade; UI1();
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
}
