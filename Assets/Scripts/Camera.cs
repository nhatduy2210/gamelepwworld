using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public GameObject Player;
    public float left;
    public float right;
    public float up;

  
    // Start is called before the first frame update
    void Start()
    {
        up = Player.transform.position.y;//vị trí ban đầu

        
    }

    // Update is called once per frame
    void Update()
    {
        if (Player != null)
        {
            float PlayerX = Player.transform.position.x;
            float PlayerY = Player.transform.position.y;

            float CameraX = transform.position.x;
            float Cameray = transform.position.y;
            if(PlayerX> left && PlayerX < right)
            {
                CameraX = PlayerX;
            }else if(PlayerX <= left)
            {
                CameraX = left;
            }else if (PlayerX >= right)
            {
                CameraX = right;
            }
            Cameray = Mathf.Max(0, PlayerY);
            transform.position = new Vector3(CameraX, Cameray, -10);
        }

    }
}
