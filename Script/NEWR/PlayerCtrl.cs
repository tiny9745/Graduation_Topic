using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerCtrl : MonoBehaviour
{
    float moveSpeed = 2f;
    public float turnSpeed = 40f;
    public float jumpForce = 5f;
    private bool isJumping = false;
    private Rigidbody rb;
    public GameObject objectToShowHide;
    static public bool PlayerSword=false;
    static public int Player_HP = 100;
    public float PlayerAttackTime;
    public Animator animator; // Add animator reference
    public Image HPimg;

    public GameObject Camera_main;
    public GameObject Player_body;

    public GameObject bullet;
    public Transform Firepoint;

    public ItemSlot _slot;
    public GameObject Button_bullet;
    public static int bullet_quantity = 0;

    public GameObject text_win;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();

        animator = GetComponent<Animator>(); // Get animator component
    }
    private void Update()
    {
        Button buttonComponent = Button_bullet.GetComponent<Button>();
        Image buttonImage = buttonComponent.GetComponent<Image>();
        if (bullet_quantity == 0)
        {
            buttonComponent.enabled = false;
            if (buttonImage != null)
            {
                Color color = buttonImage.color;
                color.a = 0.5f;
                buttonImage.color = color;
            }
        }
        else if (bullet_quantity > 0)
        {
            buttonComponent.enabled = true;
            if (buttonImage != null)
            {
                Color color = buttonImage.color;
                color.a = 1;
                buttonImage.color = color;
            }
        }
        Player_body.transform.LookAt(Camera_main.transform.position);
        HPimg.fillAmount = Player_HP*0.01f;
        // Move forward and backward
        float moveInput = Input.GetAxis("Vertical");
        if (Player_HP > 0)
        {
            /*if (Input.GetKeyDown(KeyCode.X))//砲彈射擊 
            {
                Instantiate(bullet,Firepoint.position,Firepoint.rotation);
            }*/
            transform.Translate(Vector3.forward * moveInput * moveSpeed * Time.deltaTime);
            // Turn left and right
            float turnInput = Input.GetAxis("Horizontal");
            transform.Rotate(Vector3.up * turnInput * turnSpeed * Time.deltaTime);
            // Jump

            if (Input.GetButtonDown("Jump") && !isJumping)
            {
                rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                isJumping = true;
                animator.SetTrigger("jump");
                animator.SetInteger("NewInt", 1);
            }
            animator.SetFloat("Blend", moveInput);
            if (Input.GetKeyDown(KeyCode.Z))
            {
                animator.SetTrigger("Attack");
            }

            PlayerAttackTime = animator.GetFloat("Attack Time");
            PlayerSword = PlayerAttackTime > 1 ? true : false;
        }
        else
        {
            animator.SetBool("Playerdie", true);
            Invoke("ReLive", 3f);
        }

        if (transform.position.y < -20.0f)
        {
            Player_HP = 0;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        // Reset jump state when touching the ground
        if (collision.gameObject.CompareTag("Ground"))
        {
            animator.SetInteger("NewInt",0);
            isJumping = false;
        }
        if (collision.gameObject.CompareTag("Coin"))
        {
            Destroy(collision.gameObject);
            moveSpeed += 0.1f;
        }
        if (collision.gameObject.CompareTag("Sword"))
        {
            ToggleShowHideObject();
            Destroy(collision.gameObject);
        }
        print("into");
        if (collision.gameObject.CompareTag("Win"))
        {
            print("Win");
            text_win.SetActive(true);
            Invoke("Win_Back", 3f);
        }
    }

    public void bullet_fire()
    {
        if(Player_HP>0)
        {
            Instantiate(bullet, Firepoint.position, Firepoint.rotation);
            bullet_quantity--;
            _slot.UseItem();
        }
    }
    public void Sward()
    {
        if (Player_HP > 0)
        {
            animator.SetTrigger("Attack");
        }
    }

    private void Win_Back()
    {
        SceneManager.LoadScene("main");
    }

    public void ToggleShowHideObject()
    {
        // 如果物件存在
        if (objectToShowHide != null)
        {
            // 切換物件的顯示/隱藏狀態
            objectToShowHide.SetActive(!objectToShowHide.activeSelf);
        }
        else
        {
            Debug.LogWarning("未指定物件！");
        }
    }

    private void ReLive()
    {
        animator.SetBool("Playerdie", false);
        Player_HP = 100;
        this.transform.position = new Vector3(0, 0.63f, -21f);
    }
}
