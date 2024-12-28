using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Death_MC : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject MC_S, MC_Img;
    public GameObject Blood_Screen; public UnityEngine.UI.Image Blood_Screen_Img;
    private float fadeDuration = 3.1f; public Animator animator;
    static public bool isDead = false;
    void Start()
    {
        MC_S = GameObject.Find("Player_S");
        MC_Img = GameObject.Find("F S0100");
    }

    // Update is called once per frame
    void Update()
    {
        if (static_parameters.MC_HP <= 0 && isDead)
        {
            Blood_Screen_Img.color = new Color(0f, 0f, 0f, 0.5f);
            animator.SetTrigger("Death");
            StartCoroutine(FadeToFullOpacity());
            Blood_Screen.SetActive(true);
        }
    }
    private IEnumerator FadeToFullOpacity()
    {
        bool close = true;
        isDead = false;
        Color startColor = Blood_Screen_Img.color;
        Color targetColor = new Color(startColor.r, startColor.g, startColor.b, 1f);
        float elapsedTime = 0f;
        while (elapsedTime < fadeDuration)
        {
            if (close && elapsedTime > 0.2f)
            {
                MC_Img.SetActive(false);
            }
            Blood_Screen_Img.color = Color.Lerp(startColor, targetColor, elapsedTime / fadeDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        static_parameters.stage_number--;
        SceneManager.LoadScene("magic_house");
        MC_S.transform.position = new Vector3(0, 0, 0);
        MC_Img.SetActive(true);
        Blood_Screen_Img.color = targetColor;
    }
}
