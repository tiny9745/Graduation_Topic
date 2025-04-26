using System.Collections;
using UnityEngine;

public class Boss_col : MonoBehaviour
{
    public Animator Boss_Animator;
    private GameObject TargetObj, Boss_Skill;
    public GameObject Demo_End;
    static public float BOSS_Atk_time = 0;
    public float BOSS_in_open_time = 0;
    static public bool BOSS_Atk_bool = false, BOSS_live = true;
    static public int BOSS_Atk_state = 1;
    static public bool BOSS_Atk02_ready03_waring = false;
    static public bool BOSS_Atk02_ready01 = false, BOSS_Atk02_ready03 = false;
    public float BOSS_HP_Max = 3600, BOSS_DEF = 16, BOSS_HP, BOSS_HP_tmp, Winning_HP;
    public BOSS_Blood boss_blood; public BOSS01_effect effect;
    public bool stun = false;
    public int NPC_angle = 0;
    public Transform spriteTransform;
    public AudioSource audioSource;
    public AudioClip BOSS_Loop, BOSS_laugh, BOSS_hit, BOSS_Die;
    public AudioClip[] BOSS_Atk01_sound;
    public AudioClip[] BOSS_Atk02_sound;
    public AudioClip[] BOSS_Atk03_sound;

    private bool boss_open = false;

    void Start()
    {
        BOSS_Atk_time = 0;
        BOSS_Atk_bool = false;
        BOSS_live = true;
        spriteRenderer = spriteTransform.GetComponent<SpriteRenderer>();
        originalColor = spriteRenderer.color; // 儲存原始顏色
        BOSS_HP = BOSS_HP_Max;
        BOSS_HP_tmp = BOSS_HP_Max;
        TargetObj = GameObject.Find("Player_S");
        static_parameters.Change_enemy++;
        Boss_Animator.SetBool("open_before", true);
    }
    void Update()
    {
        if (boss_open == false)
        {
            if (BOSS_in_open_time >= 6)
            {
                Boss_Animator.SetBool("open_before", false);
                Boss_Animator.SetTrigger("open");
                BOSS_in_open_time = 0;
                boss_open = true;
            }
            return;
        }
        if (BOSS_HP <= 0)
        {
            if (BOSS_live)
            {
                BOSS_HP = 0;
                BOSS_live = false;
                Boss_Animator.SetTrigger("die");
                Destroy(Boss_Skill);
                static_parameters.invincible = true;
                Winning_HP = static_parameters.MC_HP;
                static_parameters.Change_enemy = 0;
                StartCoroutine(Dead_after(1.5f));
            }
            static_parameters.MC_HP = Winning_HP;
            return;
        }

        if (BOSS_Atk_time < 3 && BOSS_Atk_bool == false)
        {
            BOSS_Atk_time += Time.deltaTime;
        }
        if (BOSS_Atk_time >= 3 && BOSS_Atk_bool == false && BOSS_Atk_state != 2)
        {
            BOSS_Atk_bool = true;
            BOSS_Atk_time = 0;
            Boss_Animator.SetTrigger("aup");
            Boss_Animator.SetBool("atk_end", true);
            audioSource.clip = BOSS_Loop;
            audioSource.loop = true;
            audioSource.Play();

            switch (BOSS_Atk_state)
            {
                case 1:
                    BOSS_Atk02_ready03_waring = true;
                    Boss_Atk01();
                    break;
                case 3:
                    Boss_Atk03();
                    break;
            }
        }
        if (BOSS_Atk_bool && BOSS_Atk_state == 2)
        {
            Boss_Animator.SetTrigger("aup");
            Boss_Animator.SetBool("atk_end", true);
            audioSource.clip = BOSS_Loop;
            audioSource.loop = true;
            audioSource.Play();
            Boss_Atk02();
        }

        if (BOSS_Atk02_ready01)
        {
            BOSS_Atk02_ready01 = false;
            audioSource.PlayOneShot(BOSS_Atk02_sound[0]);
        }
        if (BOSS_Atk02_ready03)
        {
            BOSS_Atk02_ready03 = false;
            if (BOSS_Atk02_ready03_waring)
            {
                BOSS_Atk02_ready03_waring = false;
                Boss_Animator.SetBool("atk_end", false);
                audioSource.loop = false;
                audioSource.clip = BOSS_Atk02_sound[1];
                audioSource.Play();
            }
            audioSource.PlayOneShot(BOSS_Atk02_sound[2]);
        }

        if (TargetObj != null)
        {
            Vector3 direction = TargetObj.transform.position - transform.position;
            Vector3 directionOnXZ = new Vector3(direction.x, 0, direction.z);
            Vector3 forwardOnXZ = new Vector3(transform.forward.x, 0, transform.forward.z);

            NPC_angle = Mathf.RoundToInt(Vector3.SignedAngle(forwardOnXZ, directionOnXZ, Vector3.up));
            if (NPC_angle < 0)
            {
                NPC_angle += 360;
            }
        }
    }
    public Collider[] BOSS_Atk01_Tips_Tip;
    public Animator[] BOSS_Atk01_clockwise;
    public Animator[] BOSS_Atk01_clockwise_cards;
    public Animator[] BOSS_Atk01_inOutside;
    private int random; private float BOSS_Atk01_delay = 0.167f;

    private void Boss_Atk01()
    {
        random = Random.Range(0, 4);
        StartCoroutine(BOSS_Atk01_ready01());
        StartCoroutine(BOSS_Atk01_ready02(3f));
    }

    IEnumerator BOSS_Atk01_ready01()
    {
        random = Random.Range(0, 3);
        switch (random)
        {
            case 0://逆時針
                for (int i = 0; i < BOSS_Atk01_Tips_Tip.Length; i++)
                {
                    BOSS_Atk01_Tips_Tip[i].gameObject.SetActive(true);
                    yield return new WaitForSeconds(BOSS_Atk01_delay);
                }
                for (int i = 0; i < BOSS_Atk01_clockwise.Length; i++)
                {
                    BOSS_Atk01_clockwise[i].SetTrigger("ready_area");
                    BOSS_Atk01_clockwise[i].SetBool("ready_area_wait", true);
                    switch (i)
                    {
                        case 2:
                        case 5:
                        case 9:
                        case 12:
                            yield return new WaitForSeconds(BOSS_Atk01_delay);
                            break;
                    }
                }
                break;
            case 1://順時針
                for (int i = BOSS_Atk01_Tips_Tip.Length - 1; i >= 0; i--)
                {
                    BOSS_Atk01_Tips_Tip[i].gameObject.SetActive(true);
                    yield return new WaitForSeconds(BOSS_Atk01_delay);
                }
                for (int i = BOSS_Atk01_clockwise.Length - 1; i >= 0; i--)
                {
                    BOSS_Atk01_clockwise[i].SetTrigger("ready_area");
                    BOSS_Atk01_clockwise[i].SetBool("ready_area_wait", true);
                    switch (i)
                    {
                        case 3:
                        case 6:
                        case 10:
                        case 13:
                            yield return new WaitForSeconds(BOSS_Atk01_delay);
                            break;
                    }
                }
                break;
            case 2://由內向外
                for (int i = 0; i < (BOSS_Atk01_Tips_Tip.Length - 1) / 2 + 1 + 1; i++)
                {
                    BOSS_Atk01_Tips_Tip[i].gameObject.SetActive(true);
                    BOSS_Atk01_Tips_Tip[BOSS_Atk01_Tips_Tip.Length - 1 - i].gameObject.SetActive(true);
                    yield return new WaitForSeconds(BOSS_Atk01_delay);
                }
                for (int i = 0; i < (BOSS_Atk01_clockwise.Length - 1) / 2 + 1; i++)
                {
                    BOSS_Atk01_clockwise[i].SetTrigger("ready_area");
                    BOSS_Atk01_clockwise[i].SetBool("ready_area_wait", true);
                    BOSS_Atk01_clockwise[BOSS_Atk01_clockwise.Length - 1 - i].SetTrigger("ready_area");
                    BOSS_Atk01_clockwise[BOSS_Atk01_clockwise.Length - 1 - i].SetBool("ready_area_wait", true);
                    switch (i)
                    {
                        case 2:
                        case 5:
                            yield return new WaitForSeconds(BOSS_Atk01_delay);
                            break;
                    }
                }
                break;
        }
    }
    IEnumerator BOSS_Atk01_ready02(float wait)
    {
        yield return new WaitForSeconds(wait);
        Boss_Animator.SetBool("atk_end", false);
        audioSource.loop = false;
        audioSource.clip = BOSS_laugh;
        audioSource.Play();

        yield return new WaitForSeconds(0.2f);
        int j = 0;
        switch (random)
        {
            case 0://逆時針
                for (int i = 0; i < BOSS_Atk01_clockwise_cards.Length; i++)
                {
                    int card_style = Random.Range(0, 6);
                    BOSS_Atk01_clockwise_cards[i].SetTrigger($"Atk{card_style}");

                    switch (i)
                    {
                        case 2:
                        case 5:
                        case 9:
                        case 12:
                            BOSS_Atk01_Tips_Tip[j].enabled = true;
                            audioSource.PlayOneShot(BOSS_Atk01_sound[j]);
                            j++;
                            yield return new WaitForSeconds(BOSS_Atk01_delay);
                            break;
                    }
                }
                yield return new WaitForSeconds(1.8f - BOSS_Atk01_delay * 4);
                j = 0;
                for (int i = 0; i < BOSS_Atk01_clockwise.Length; i++)
                {
                    BOSS_Atk01_clockwise[i].SetBool("ready_area_wait", false);

                    switch (i)
                    {
                        case 0:
                        case 2:
                        case 5:
                        case 9:
                        case 12:
                            BOSS_Atk01_Tips_Tip[j].enabled = false;
                            BOSS_Atk01_Tips_Tip[j].gameObject.SetActive(false);
                            j++;
                            yield return new WaitForSeconds(BOSS_Atk01_delay);
                            break;
                    }
                }
                break;
            case 1://順時針
                for (int i = BOSS_Atk01_clockwise_cards.Length - 1; i >= 0; i--)
                {
                    int card_style = Random.Range(0, 6);
                    BOSS_Atk01_clockwise_cards[i].SetTrigger($"Atk{card_style}");

                    switch (i)
                    {
                        case 3:
                        case 6:
                        case 10:
                        case 13:
                            BOSS_Atk01_Tips_Tip[j].enabled = true;
                            audioSource.PlayOneShot(BOSS_Atk01_sound[j]);
                            j++;
                            yield return new WaitForSeconds(BOSS_Atk01_delay);
                            break;
                    }
                }
                yield return new WaitForSeconds(1.8f - BOSS_Atk01_delay * 4);
                j = 0;
                for (int i = BOSS_Atk01_clockwise_cards.Length - 1; i >= 0; i--)
                {
                    BOSS_Atk01_clockwise[i].SetBool("ready_area_wait", false);

                    switch (i)
                    {
                        case 0:
                        case 3:
                        case 6:
                        case 10:
                        case 13:
                            BOSS_Atk01_Tips_Tip[j].enabled = false;
                            BOSS_Atk01_Tips_Tip[j].gameObject.SetActive(false);
                            j++;
                            yield return new WaitForSeconds(BOSS_Atk01_delay);
                            break;
                    }
                }
                break;
            case 2://由內向外
                for (int i = 0; i < (BOSS_Atk01_clockwise.Length - 1) / 2 + 1; i++)
                {
                    int card_style = Random.Range(0, 6);
                    BOSS_Atk01_clockwise_cards[i].SetTrigger($"Atk{card_style}");
                    card_style = Random.Range(0, 6);
                    BOSS_Atk01_clockwise_cards[BOSS_Atk01_clockwise_cards.Length - 1 - i].SetTrigger($"Atk{card_style}");
                    switch (i)
                    {
                        case 2:
                        case 5:
                            BOSS_Atk01_Tips_Tip[j].enabled = true;
                            BOSS_Atk01_Tips_Tip[BOSS_Atk01_Tips_Tip.Length - 1 - j].enabled = true;
                            audioSource.PlayOneShot(BOSS_Atk01_sound[j]);
                            j++;
                            yield return new WaitForSeconds(BOSS_Atk01_delay);
                            break;
                    }
                }
                yield return new WaitForSeconds(1.8f - BOSS_Atk01_delay * 4);
                j = 0;
                for (int i = 0; i < (BOSS_Atk01_clockwise.Length - 1) / 2 + 1; i++)
                {
                    BOSS_Atk01_clockwise[i].SetBool("ready_area_wait", false);
                    BOSS_Atk01_clockwise[BOSS_Atk01_clockwise.Length - 1 - i].SetBool("ready_area_wait", false);
                    switch (i)
                    {
                        case 0:
                        case 2:
                        case 5:
                            BOSS_Atk01_Tips_Tip[j].enabled = false;
                            BOSS_Atk01_Tips_Tip[BOSS_Atk01_Tips_Tip.Length - 1 - j].enabled = false;
                            BOSS_Atk01_Tips_Tip[j].gameObject.SetActive(false);
                            BOSS_Atk01_Tips_Tip[BOSS_Atk01_Tips_Tip.Length - 1 - j].gameObject.SetActive(false);
                            j++;
                            yield return new WaitForSeconds(BOSS_Atk01_delay);
                            break;
                    }
                }
                break;
        }
        BOSS_Atk_state = 2;
        BOSS_Atk_bool = false;
    }

    static public bool BOSS_Atk02_ready_bool = false;
    private void Boss_Atk02()
    {
        if (BOSS_Atk02_ready_bool)
        {
            BOSS_Atk02_ready_bool = false;
            Boss_Animator.SetBool("atk_end", false);
        }
    }

    public GameObject[] BOSS_Atk03_Tips;
    public Collider[] BOSS_Atk03_GC;
    public Animator[] BOSS_Atk03_Ani_ground;
    public Animator[] BOSS_Atk03_Ani_cards;
    private bool BOSS_Atk03_isFacingRight = true;
    int BOSS_Atk03_random = 0;
    private void Boss_Atk03()
    {
        StartCoroutine(BOSS_Atk03_ready01(0.167f));
        StartCoroutine(BOSS_Atk03_ready02());
    }
    IEnumerator BOSS_Atk03_ready01(float wait)
    {
        BOSS_Atk03_random = Random.Range(0, 2);
        switch (BOSS_Atk03_random)
        {
            case 0:
                if (!BOSS_Atk03_isFacingRight)
                {
                    Flip();
                }
                for (int i = 0; i < BOSS_Atk03_Tips.Length - 1; i++)
                {
                    BOSS_Atk03_Tips[i].SetActive(true);
                    yield return new WaitForSeconds(wait);
                }
                yield return new WaitForSeconds(7f);
                for (int i = 0; i < BOSS_Atk03_Tips.Length - 1; i++)
                {
                    BOSS_Atk03_Tips[i].SetActive(false);
                    yield return new WaitForSeconds(wait);
                }
                Boss_Animator.SetBool("atk_end", false);
                for (int i = 0; i < BOSS_Atk03_Tips.Length - 1; i++)
                {
                    for (int j = i * 3; j < i * 3 + 3; j++)
                    {
                        BOSS_Atk03_Ani_ground[j].SetTrigger("BOSS_Atk03_Ground");
                    }
                    if (i < BOSS_Atk03_Tips.Length - 2)
                    {
                        for (int j = i * 4; j < i * 4 + 4; j++)
                        {
                            audioSource.PlayOneShot(BOSS_Atk03_sound[0]);
                            BOSS_Atk03_Ani_cards[j].SetTrigger("BOSS_Atk03_Card");
                        }
                    }
                    BOSS_Atk03_GC[i].enabled = true;
                    yield return new WaitForSeconds(wait);
                }
                break;
            case 1:
                if (BOSS_Atk03_isFacingRight)
                {
                    Flip();
                }
                for (int i = BOSS_Atk03_Tips.Length - 1; i > 0; i--)
                {
                    BOSS_Atk03_Tips[i].SetActive(true);
                    yield return new WaitForSeconds(wait);
                }
                yield return new WaitForSeconds(7f);
                for (int i = BOSS_Atk03_Tips.Length - 1; i > 0; i--)
                {
                    BOSS_Atk03_Tips[i].SetActive(false);
                    yield return new WaitForSeconds(wait);
                }
                Boss_Animator.SetBool("atk_end", false);
                audioSource.loop = false;
                audioSource.clip = BOSS_laugh;
                audioSource.Play();
                for (int i = BOSS_Atk03_Tips.Length - 1; i > 0; i--)
                {
                    for (int j = (i + 1) * 3 - 1; j > i * 3 - 1; j--)
                    {
                        BOSS_Atk03_Ani_ground[j].SetTrigger("BOSS_Atk03_Ground");
                    }
                    if (i > 1)
                    {
                        for (int j = i * 4 - 1; j > (i - 1) * 4 - 1; j--)
                        {
                            audioSource.PlayOneShot(BOSS_Atk03_sound[0]);
                            BOSS_Atk03_Ani_cards[j].SetTrigger("BOSS_Atk03_Card");
                        }
                    }
                    BOSS_Atk03_GC[i].enabled = true;
                    yield return new WaitForSeconds(wait);
                }
                break;
        }
    }
    IEnumerator BOSS_Atk03_ready02()
    {
        switch (BOSS_Atk03_random)
        {
            case 0:
                for (int i = 0; i < BOSS_Atk03_GC.Length - 1; i++)
                {
                    yield return new WaitUntil(() =>
                    {
                        AnimatorStateInfo stateInfo = BOSS_Atk03_Ani_cards[i * 3].GetCurrentAnimatorStateInfo(0);
                        return stateInfo.IsName("BOSS_Atk03_Card") && stateInfo.normalizedTime >= 0.98f;
                    });
                    BOSS_Atk03_GC[i].enabled = false;
                }
                break;
            case 1:
                for (int i = BOSS_Atk03_GC.Length - 1; i > 0; i--)
                {
                    yield return new WaitUntil(() =>
                    {
                        AnimatorStateInfo stateInfo = BOSS_Atk03_Ani_cards[i * 3 + 1].GetCurrentAnimatorStateInfo(0);
                        return stateInfo.IsName("BOSS_Atk03_Card") && stateInfo.normalizedTime >= 0.98f;
                    });
                    BOSS_Atk03_GC[i].enabled = false;
                }
                break;
        }
        BOSS_Atk_state = 1;
        BOSS_Atk_bool = false;
    }

    void Flip()
    {
        BOSS_Atk03_isFacingRight = !BOSS_Atk03_isFacingRight;
        for (int i = 0; i < BOSS_Atk03_Ani_ground.Length; i++)
        {
            Vector3 theScale = BOSS_Atk03_Ani_ground[i].transform.localScale;
            theScale.x *= -1;
            BOSS_Atk03_Ani_ground[i].transform.localScale = theScale;
        }
        for (int i = 0; i < BOSS_Atk03_Ani_cards.Length; i++)
        {
            Vector3 theScale = BOSS_Atk03_Ani_cards[i].transform.localScale;
            theScale.x *= -1;
            BOSS_Atk03_Ani_cards[i].transform.localScale = theScale;
        }
    }

    public Animator animator_to_atk;
    public SpriteRenderer weaponDUCK;
    private SpriteRenderer spriteRenderer; private Color originalColor;
    private bool MC_to_Att = true, isCoroutineRunning = false;
    private float damageCooldown = 1.0f, nextDamageTime = 0.0f;
    int open_EnableHitbox = 0;

    private void OnTriggerEnter(Collider other)
    {
        effect.skill_TriggerEnter(other);
    }
    private void OnTriggerStay(Collider other)
    {
        if (BOSS_HP > 0)
        {
            if (other.gameObject.tag == "Player" && Time.time >= nextDamageTime)
            {
                if (open_EnableHitbox == 0)
                {
                    open_EnableHitbox = 1;
                }
            }

            if (other.gameObject.CompareTag("MC_Att") && MC_to_Att)
            {
                Change();
                audioSource.PlayOneShot(BOSS_hit);
                switch (static_parameters.Ani_state)
                {
                    case 2:
                        animator_to_atk.SetTrigger("atk_to_MC01");
                        break;
                    case 3:
                        animator_to_atk.SetTrigger("atk_to_MC02");
                        break;
                    case 4:
                        animator_to_atk.SetTrigger("atk_to_MC02");
                        break;
                }
                change_color_red();
                Boss_Animator.SetTrigger("hit");
                effect.piano_Skill();
                effect.fight_instinct_npc();
                boss_blood.TakeDamage(static_parameters.MC_ATK, BOSS_DEF);
                Debug.Log("BOSS_HP01:" + BOSS_HP);
                MC_to_Att = false;
                Invoke("wait_MC_att", 0.5f);
                nextDamageTime = Time.time + damageCooldown;
            }

            if (other.gameObject.CompareTag("MC_bomb"))
            {
                effect.play_piano_effect();
            }

            if (other.gameObject.CompareTag("MC_bullet"))
            {
                change_color_red();
                Boss_Animator.SetTrigger("hit");
                switch (static_parameters._ItemID)
                {
                    case 1:
                        boss_blood.TakeDamage(4 * Skill_public_funtion.skill_13_bullet_atk, BOSS_DEF);
                        break;
                    case 2:
                        boss_blood.TakeDamage(3 * Skill_public_funtion.skill_13_bullet_atk, BOSS_DEF);
                        break;
                    case 3:
                        boss_blood.TakeDamage(5 * Skill_public_funtion.skill_13_bullet_atk, BOSS_DEF);
                        break;
                    case 4:
                        boss_blood.TakeDamage(1 * Skill_public_funtion.skill_13_bullet_atk, BOSS_DEF);
                        break;
                }
            }
        }
    }
    public void change_color_red()
    {
        spriteRenderer.color = Color.red; // 將顏色改為紅色
        if (!isCoroutineRunning)  // 檢查協程是否正在運行
        {
            StartCoroutine(ResetColorAfterDelay(0.75F)); // 啟動協程
        }

    }
    IEnumerator ResetColorAfterDelay(float delay)
    {
        isCoroutineRunning = true; // 設置為 true，表示協程正在運行
        yield return new WaitForSeconds(delay);  // 等待指定的延遲時間
        spriteRenderer.color = UnityEngine.Color.white; // 重置顏色為白色
        isCoroutineRunning = false; // 協程結束後將旗標設回 false
    }

    void wait_MC_att()
    {
        MC_to_Att = true;
    }
    public void Change()
    {
        switch (Change_mood.mood)
        {
            case 0:
                weaponDUCK.color = new Color(0.63f, 0.98f, 0.86f, 1);
                break;
            case 1:
                weaponDUCK.color = new Color(0.98f, 0.62f, 0.63f, 1);
                break;
            case 2:
                weaponDUCK.color = new Color(0.61f, 0.8f, 1, 1);
                break;
            case 3:
                weaponDUCK.color = new Color(0.84f, 0.62f, 0.88f, 1);
                break;
            case 4:
                weaponDUCK.color = new Color(1, 0.93f, 0.59f, 1);
                break;
            default:
                weaponDUCK.color = new Color(0.95f, 0.88f, 0.89f, 1);
                break;
        }
    }
    IEnumerator Dead_after(float wait)
    {
        yield return new WaitForSeconds(wait);
        // Demo_End.SetActive(true);
        Destroy(gameObject);
    }
}
