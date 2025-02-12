using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;

public class skill_piano_effect : MonoBehaviour
{
    // Start is called before the first frame update
    private Vector3 startPosition;
    public SpriteRenderer number_pic;

    public GameObject number_object, icon_object;

    public Sprite[] number_image;

    private void Awake()
    {
        startPosition = transform.localPosition;
    }

    private void Start()
    {

    }

    /// 向上淡入進場（啟用物件，從下方移動至原位置）
    public void FadeInMoveUp(float duration, float moveDistance)
    {
        number_object.SetActive(true);
        icon_object.SetActive(true);
        StartCoroutine(FadeInMoveUpRoutine(duration, moveDistance));
    }
    /// 向下淡出離場（移動後關閉物件）
    public void FadeOutMoveDown(float duration, float moveDistance)
    {
        StartCoroutine(FadeOutMoveDownRoutine(duration, moveDistance));
    }
    /// 原地跳動（執行一次）
    public void JumpAnimation(float jumpHeight, float jumpDuration, int jumpcount)
    {
        StartCoroutine(JumpRoutine(jumpHeight, jumpDuration, jumpcount));
    }

    private IEnumerator FadeInMoveUpRoutine(float duration, float moveDistance)
    {
        float elapsedTime = 0f;
        Vector3 start = startPosition + new Vector3(0, moveDistance, 0); // 🔹 起始點改為上方
        Vector3 end = startPosition;
        transform.localPosition = start;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            transform.localPosition = Vector3.Lerp(start, end, elapsedTime / duration);
            yield return null;
        }
        transform.localPosition = end;
    }

    private IEnumerator FadeOutMoveDownRoutine(float duration, float moveDistance)
    {
        float elapsedTime = 0f;
        Vector3 start = startPosition;
        Vector3 end = startPosition + new Vector3(0, moveDistance, 0); // 🔹 目標點改為上方

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            transform.localPosition = Vector3.Lerp(start, end, elapsedTime / duration);
            yield return null;
        }
        transform.localPosition = end;
        icon_object.SetActive(false);
        number_object.SetActive(false);
    }

    private IEnumerator JumpRoutine(float jumpHeight, float jumpDuration, int jumpcount)
    {
        float elapsedTime = 0f;
        Vector3 start = startPosition;
        Vector3 peak = start + new Vector3(0, jumpHeight, 0);

        // 向上
        while (elapsedTime < jumpDuration / 2)
        {
            elapsedTime += Time.deltaTime;
            transform.localPosition = Vector3.Lerp(start, peak, elapsedTime / (jumpDuration / 2));
            yield return null;
        }

        elapsedTime = 0f;
        if (jumpcount >= Skill_public_funtion.P_time - 1)
        {
            jumpcount = 0;
            FadeOutMoveDown(0.25f, 4f);
        }
        number_pic.sprite = number_image[jumpcount];

        // 向下
        while (elapsedTime < jumpDuration / 2)
        {
            elapsedTime += Time.deltaTime;
            transform.localPosition = Vector3.Lerp(peak, start, elapsedTime / (jumpDuration / 2));
            yield return null;
        }
        transform.localPosition = start; // 確保回到原位置
    }
}
