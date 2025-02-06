using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skill_piano_effect : MonoBehaviour
{
    // Start is called before the first frame update
    private Vector3 startPosition;

    private void Awake()
    {
        startPosition = transform.localPosition;
    }

    private void Start()
    {
        FadeInMoveUp(20f, 0.5f);
        Debug.Log("piano NPC03 skill~~~");
    }

    /// 向上淡入進場（啟用物件，從下方移動至原位置）
    public void FadeInMoveUp(float duration, float moveDistance)
    {
        gameObject.SetActive(true);
        StartCoroutine(FadeInMoveUpRoutine(duration, moveDistance));
    }
    /// 向下淡出離場（移動後關閉物件）
    public void FadeOutMoveDown(float duration, float moveDistance)
    {
        StartCoroutine(FadeOutMoveDownRoutine(duration, moveDistance));
    }
    /// 原地跳動（執行一次）
    public void JumpAnimation(float jumpHeight, float jumpDuration)
    {
        StartCoroutine(JumpRoutine(jumpHeight, jumpDuration));
    }

    private IEnumerator FadeInMoveUpRoutine(float duration, float moveDistance)
    {
        float elapsedTime = 0f;
        Vector3 start = startPosition - new Vector3(0, moveDistance, 0);
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
        Vector3 end = startPosition - new Vector3(0, moveDistance, 0);

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            transform.localPosition = Vector3.Lerp(start, end, elapsedTime / duration);
            yield return null;
        }

        transform.localPosition = end;
        gameObject.SetActive(false);
    }

    private IEnumerator JumpRoutine(float jumpHeight, float jumpDuration)
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
