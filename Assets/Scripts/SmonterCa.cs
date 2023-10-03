using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmonterCa : MonoBehaviour
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
        float positionX = transform.position.x;
        // float positionX = transform.localPosition.x; Nếu gom nhóm

        if (positionX <= leftBound)
        {
            isOnRight = true;
            Vector2 scale = transform.localScale;

            //scale.x *= scale.x > 0 ? 1 : -1;
            if (scale.x > 0)
            {
                scale.x = scale.x * -1;
            }
            else
            {
                scale.x = scale.x * 1;
            }

            transform.localScale = scale;

        }
        else if (positionX >= rightBound)
        {
            isOnRight = false;

            Vector2 scale = transform.localScale;
            if (scale.x > 0)
            {
                scale.x = scale.x * 1;
            }
            else
            {
                scale.x = scale.x * -1;
            }

            transform.localScale = scale;

        }
        if (isOnRight)
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
    }
}
