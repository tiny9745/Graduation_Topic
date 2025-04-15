using Cinemachine;
using UnityEngine;

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
            death_MC.transform.localPosition = new Vector3(0, 32, -42);
            death_MC.transform.localScale = new Vector3(2.1f, 2.1f, 2.1f);
            targetDistance = -35f;
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
