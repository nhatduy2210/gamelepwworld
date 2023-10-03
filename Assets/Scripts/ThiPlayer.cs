using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ThiPlayer : MonoBehaviour
{

    public TextMeshProUGUI scoreText;
    private float startTime;
    private int score;
    public GameObject panel;
    private float speed = 8f;

    //biến check trái phải
    public bool isRight = true;
    //cách 2 khai báo rigibody2d
    private Rigidbody2D rb;
    //tạo biến nền quản lí
    public bool nen;
    //tốc độ di chuyển nhân vật
    private float movingSpeed;
    // Start is called before the first frame update
    void Start()
    {
        //lấy component rigi
        rb = GetComponent<Rigidbody2D>();
        movingSpeed = 5.0f;
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            isRight = true;

            
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

        if (Input.GetKey(KeyCode.LeftArrow))
        {


            isRight = false;

          
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

        if (Input.GetKey(KeyCode.Space))
        {
          
          

                rb.AddForce(new Vector2(0, 40));

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
        

    }

   


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    
        if (collision.gameObject.CompareTag("QuaiThi"))
        {

           
            Time.timeScale = 0;
            panel.SetActive(true);
            CalculateScore();
            scoreText.text = "Score: " + score.ToString();

        }
    }
    private void CalculateScore()
    {
        float elapsedTime = Time.time - startTime;
        score = Mathf.RoundToInt(elapsedTime); 
    }
}
