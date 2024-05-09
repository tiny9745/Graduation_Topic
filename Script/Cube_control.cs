using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    public float moveSpeed = 5f; // 移動速度
    public GameObject cube;
    void Start()
    {
        cube = GameObject.Find("Player");
        Renderer renderer = cube.GetComponent<Renderer>();
        if (renderer != null)
        {
            renderer.enabled = false;
        }
    }
    void Update()
    {
        // 獲取玩家的輸入
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // 計算移動方向
        Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput).normalized;

        // 將移動方向轉換成世界空間
        movement = transform.TransformDirection(movement);

        // 移動角色
        transform.position += movement * static_parameters.MC_Wspeed * Time.deltaTime;
        Debug.Log(static_parameters.MC_Wspeed);
    }
}
