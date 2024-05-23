using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Loading_magic : MonoBehaviour
{
    public GameObject loadingScreen;
    public Image loadingBar;
    public float loadingSpeed = 0.3f;

    private void Start()
    {
        if (loadingScreen == null || loadingBar == null)
        {
            Debug.LogError("LoadingScreen or LoadingBar not found in the current scene.");
            return;
        }

        loadingScreen.SetActive(true);
        StartCoroutine(FillLoadingBarGradually());
    }

    private IEnumerator FillLoadingBarGradually()
    {
        while (loadingBar.fillAmount < 1f)
        {
            loadingBar.fillAmount += Time.unscaledDeltaTime * loadingSpeed;
            yield return null;
        }

        loadingScreen.SetActive(false);
    }
}
