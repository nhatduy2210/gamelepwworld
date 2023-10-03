using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerScene2 : MonoBehaviour
{

    //gọi animator
    public Animator animator;
    private float speed = 8f;

    //biến check trái phải
    public bool isRight = true;
    //cách 2 khai báo rigibody2d
    private Rigidbody2D rb;
    //tạo biến nền quản lí
    public bool nen;
    //tốc độ di chuyển nhân vật
    private float movingSpeed;
    private bool canDash = true;
    private bool isDashing;
    private float dashingPower = 3f;
    private float dashingTime = 0.2f;
    private float dashingCooldown = 1f;
    [SerializeField]
    private TrailRenderer tr;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        //lấy component rigi
        rb = GetComponent<Rigidbody2D>();
        movingSpeed = 5.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (isDashing)
        {
            return;
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            isRight = true;
          
            animator.SetBool("isRunning", true);
            animator.SetBool("isOnGround", true);
            transform.Translate(Time.deltaTime * 2, 0, 0);
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


        if (Input.GetKey(KeyCode.Space) && canDash)
        {

            StartCoroutine(Dash());
        }



            if (Input.GetKey(KeyCode.LeftArrow))
        {

           
            isRight = false;
          
            animator.SetBool("isRunning", true);
            animator.SetBool("isOnGround", true);
            transform.Translate(-Time.deltaTime * 2, 0, 0);
            //cách 2 di chuyển transform.Translate(Vector3.right*moving speed)
            //scale.x *= scale.x > 0 ? 1 : -1;
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

        if (Input.GetKey(KeyCode.UpArrow))
        {
            animator.SetBool("isRunning", false);
            animator.SetBool("isOnGround", false);
            Debug.Log("cccccccc" + nen);


            if (nen)
            {
               
                rb.AddForce(new Vector2(0, 450));

                if (isRight)
                {
                    // transform.Translate(Time.deltaTime * 2, Time.deltaTime * 10, 0);
                    //cách 2 nhảy 

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
                else
                {
                    //transform.Translate(-Time.deltaTime * 2, Time.deltaTime * 10, 0);
                    //cách 2
                    //rb.AddForce(new Vector2(0, 10));
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
                nen = false;
            }


            //nen = false;
        }
    }
    //hàm quản lí va chạm của game object
    //2 conlider chạm hàm sẽ kích hoat
    //va chạm đẩy nhau
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject.tag);
        if (collision.gameObject.tag == "sewerS" || collision.gameObject.tag == "Ground")
        {
            Debug.Log(">>>>>>>>>>>>day ne: " + nen);
            nen = true;
        }


    }

    private IEnumerator Dash()
    {
        canDash = false;
        isDashing = true;
        float originalGravity = rb.gravityScale;
        rb.gravityScale = 0f;
        rb.velocity = new Vector2(transform.localScale.x * dashingPower, 0.5f);
        tr.emitting = true;
        yield return new WaitForSeconds(dashingTime);
        tr.emitting = false;
        rb.gravityScale = originalGravity;
        isDashing = false;
        yield return new WaitForSeconds(dashingCooldown);
        canDash = true;
    }    
}
