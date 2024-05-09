using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
public class NPCCtrl : MonoBehaviour
{
    // Start is called before the first frame update
    NavMeshAgent npcNavi;
    public GameObject TargetObj;
    public int DetectDistance = 10;
    public int NPC_HP = 100;
    public int NPC_ATK = 10;
    private Camera mainCamera;
    public GameObject cube;
    void Start()
    {
        cube = GameObject.Find("NPC");
        Renderer renderer = cube.GetComponent<Renderer>();
        if (renderer != null)
        {
            renderer.enabled = false;
        }
        mainCamera = Camera.main;
        TargetObj = GameObject.Find("Player");
        npcNavi = GetComponent<NavMeshAgent>();
    }
    // Update is called once per frame
    void Update()
    {
        float dist = Vector3.Distance(transform.position, TargetObj.transform.position);
        _ = npcNavi.velocity.magnitude;   // 取得NPC的速度.
        transform.LookAt(mainCamera.transform);
        if (dist < DetectDistance && NPC_HP > 0) // 偵測NPC和玩家之間的距離, 如在所設定的距離內, 開始追蹤
        {
            npcNavi.destination = TargetObj.transform.position;  // 
        }
        else // 追蹤自己的位置 
        {
            npcNavi.destination = transform.position;
        }
    }
    //NPC攻擊判定
    private void OnCollisionEnter(Collision Hit)
    {
        if (Hit.gameObject.CompareTag("Player"))
        {
            static_parameters.MC_HP -= NPC_ATK;
        }
        else
        {
            Debug.LogWarning("找不到對應組件");
        }
    }
}