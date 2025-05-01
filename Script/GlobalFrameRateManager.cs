using UnityEngine;

public class GlobalFrameRateManager : MonoBehaviour
{
    public enum FrameRateMode
    {
        Default,    // 系統預設（如 60FPS）
        FPS30       // 鎖定在 30FPS
    }

    [Header("初始模式")]
    public FrameRateMode initialMode = FrameRateMode.Default;

    private const float defaultFixedDeltaTime = 0.02f;  // 預設 50FPS
    private const float fps30FixedDeltaTime = 1f / 30f;

    void Start()
    {
        ApplyFrameRateMode(initialMode);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Delete))
        {
            ToggleMode();
        }
    }

    public void ApplyFrameRateMode(FrameRateMode mode)
    {
        if (mode == FrameRateMode.FPS30)
        {
            Application.targetFrameRate = 30;
            Time.fixedDeltaTime = fps30FixedDeltaTime;
            Debug.Log("✅ 切換為 30FPS 模式");
        }
        else
        {
            Application.targetFrameRate = -1; // 系統預設
            Time.fixedDeltaTime = defaultFixedDeltaTime;
            Debug.Log("✅ 切換為預設模式");
        }
    }

    public void ToggleMode()
    {
        if (Application.targetFrameRate == 30)
        {
            ApplyFrameRateMode(FrameRateMode.Default);
        }
        else
        {
            ApplyFrameRateMode(FrameRateMode.FPS30);
        }
    }
}
