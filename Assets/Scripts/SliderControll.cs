using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderControll : MonoBehaviour
{

    Slider slider;
    int index = 10;
    // Start is called before the first frame update
    void Start()
    {
        slider = gameObject.GetComponent<Slider>();
        index = 10;

    }

    // Update is called once per frame
    void Update()
    {
       if(index < 1)
        {
            index = 1;
        } 
       else if (index > 10)
        {
            index = 10;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            slider.value = index--;
        }
        else if(Input.GetKeyDown(KeyCode.D))
        {
            slider.value = index++;
        }    
    }

    // Khi có va chạm
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("quai2")) // Kiểm tra nếu va chạm với đối tượng có tag "Enemy"
        {
            slider.value = index--;
        }
    }
}
