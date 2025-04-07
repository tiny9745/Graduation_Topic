using Cinemachine;
using UnityEngine;

public class CameraDistanceControl : MonoBehaviour
{
    public CinemachineVirtualCamera virtualCam;
    public float targetDistance = -15f;  // 通常是負值，表示在目標後方

    void Start()
    {
        SetCameraDistance(targetDistance);
    }
    private void Update()
    {
        // 這裡可以根據需要調整鏡頭距離
        if (static_parameters.into_gameFight_Levels == 6)
        {
            targetDistance = -35;
            SetCameraDistance(targetDistance);
        }
        else
        {
            targetDistance = -15f;
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
