using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField]
    private float Speed;
    public PlayerAnimation playeranim;
    //cách 2 khai báo rigibody2d
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        playeranim = GetComponent<PlayerAnimation>();
        //lấy component rigi
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        float horizoltalInput = Input.GetAxis("Horizontal");


        float VerticalInput = Input.GetAxis("Vertical");

        if (horizoltalInput>0)
        {
            transform.Translate(Vector3.right*Speed*Time.deltaTime);
            playeranim.SetRunning(1);
         
            //lấy scale nhân vật hiện tại(kích thước)
            Vector2 scale = transform.localScale;
            //scale.x *= scale.x > 0 ? 1 : -1;
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
        else if (horizoltalInput < 0)
        {
            //qua trai
            transform.Translate(Vector3.left * Speed * Time.deltaTime);
            playeranim.SetRunning(1);
            Vector2 scale = transform.localScale;
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
        
        else if (VerticalInput > 0)
        {
            //qua trai

            rb.AddForce(new Vector2(0, 20));
            playeranim.SetJumping(false);
         
        }
        else
        {
            playeranim.SetRunning(0);
           
        }

    }

    
    public float GetSpeed()
    {
        return Speed;
    }
}
