using Cinemachine;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraDistanceControl : MonoBehaviour
{
    public CinemachineVirtualCamera virtualCam;
    private float targetDistance = -20f;  // 通常是負值，表示在目標後方
    public GameObject death_MC;

    void Start()
    {
        SetCameraDistance(targetDistance);
    }
    private void Update()
    {
        if (static_parameters.stage_number == 6)
        {
            death_MC.transform.localPosition = new Vector3(0, 25, -42);
            death_MC.transform.localScale = new Vector3(2.05f, 2.05f, 2.05f);
            targetDistance = -35f;
            SetCameraDistance(targetDistance);
        }
        else
        {
            if (static_parameters.reburn_ani)
            {
                death_MC.transform.localPosition = new Vector3(0, -400, -42);
                death_MC.transform.localScale = new Vector3(17f, 17f, 17f);
                targetDistance = -20f;
                SetCameraDistance(targetDistance);
            }
            else if (SceneManager.GetActiveScene().name == "magic_house")
            {
                death_MC.transform.localPosition = new Vector3(0, 25, -42);
                death_MC.transform.localScale = new Vector3(3.4f, 3.4f, 3.4f);
                targetDistance = -12f;
                SetCameraDistance(targetDistance);
            }
            else
            {
                death_MC.transform.localPosition = new Vector3(0, 45, -42);
                death_MC.transform.localScale = new Vector3(3.4f, 3.4f, 3.4f);
                targetDistance = -20f;
                SetCameraDistance(targetDistance);
            }

        }
    }

    public void SetCameraDistance(float distance)
    {
        var transposer = virtualCam.GetCinemachineComponent<CinemachineTransposer>();
        if (transposer != null)
        {
            Vector3 offset = transposer.m_FollowOffset;
            offset.z = distance; // 調整鏡頭與角色的距離
            transposer.m_FollowOffset = offset;
        }
    }
}
