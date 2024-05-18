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
    int DetectDistance = 15;
    int NPC_HP = 100;
    int NPC_ATK = 10;
    private Quaternion initialRotation;
    //private Camera mainCamera;
    public GameObject cube;

    void Start()
    {
        initialRotation = transform.rotation;
        cube = GameObject.Find("NPC");
        Renderer renderer = cube.GetComponent<Renderer>();
        if (renderer != null)
        {
            renderer.enabled = false;
        }
        //mainCamera = FindObjectOfType<Camera>();//Get camera
    }
    // Update is called once per frame
    void Update()
    {
        transform.rotation = initialRotation;
        if (TargetObj == null)
        {
            TargetObj = GameObject.Find("Player");
            npcNavi = GetComponent<NavMeshAgent>();
        }
        else
        {
            float dist = Vector3.Distance(transform.position, TargetObj.transform.position);
            if (dist < DetectDistance && NPC_HP > 0)
            {
                npcNavi.destination = TargetObj.transform.position;
            }
            else // Track your location 
            {
                npcNavi.destination = transform.position;
            }
            _ = npcNavi.velocity.magnitude;  // Get NPC speed
            //transform.LookAt(mainCamera.transform);
        }
    }

    private void OnCollisionEnter(Collision Hit)
    {
        //NPC attack determination
        if (Hit.gameObject.CompareTag("Player"))
        {
            static_parameters.MC_HP -= NPC_ATK;
            print("Player_HP=" + static_parameters.MC_HP);
        }
        else
        {
            Debug.LogWarning("找不到對應組件");
        }
        //NPC is determined to be attacked
        if (NPC_HP<=0)
        {
            Destroy(gameObject);
            static_parameters.Change_enemy--;
        }
    }
}