using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Updown : MonoBehaviour
{
    [SerializeField]
    private float leftBound;
    [SerializeField]
    private float rightBound;
    //tốc độ di chuyển
    [SerializeField]
    private float speed;
    //hướng mặt
    [SerializeField]
    private bool isOnRight;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float positionY = transform.position.y;
        // float positionX = transform.localPosition.x; Nếu gom nhóm

        if (positionY <= leftBound)
        {
            isOnRight = true;
           

        }
        else if (positionY >= rightBound)
        {
            isOnRight = false;

         

        }
        if (isOnRight)
        {
            transform.Translate(Vector3.up * speed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector3.down * speed * Time.deltaTime);
        }
    }
}
