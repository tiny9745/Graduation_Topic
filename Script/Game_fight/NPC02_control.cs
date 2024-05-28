using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class NPC02_control : MonoBehaviour
{
    // Start is called before the first frame update
    NavMeshAgent npcNavi;
    public GameObject TargetObj;
    public static int DetectDistance = 25; public static int NPC_ATK = 20;
    public static float NPC_HP = 80; public static float npcSpeed = 5f;

    private Quaternion initialRotation;
    //private Camera mainCamera;
    public GameObject NPC02;

    void Start()
    {
        initialRotation = transform.rotation;
        NPC02 = GameObject.Find("NPC02");
        if (NPC02 != null)
        {
            Renderer renderer = NPC02.GetComponent<Renderer>();
            if (renderer != null)
            {
                renderer.enabled = false;
            };
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
            // Set the speed after each acquisition of the NavMeshAgent component
            if (npcNavi != null)
            {
                npcNavi.speed = npcSpeed;
            }
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
            Debug.LogWarning("�䤣������ե�");
        }
        //NPC is determined to be attacked
        if (NPC_HP <= 0)
        {
            Destroy(gameObject);
            static_parameters.Change_enemy--;
        }
    }
}
