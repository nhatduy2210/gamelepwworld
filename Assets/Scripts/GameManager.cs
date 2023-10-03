using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public float TimeE1, CountE1;
    public GameObject Enemy1;
    // Start is called before the first frame update

    //register
    public TMP_InputField RegisterEmail;
    public TMP_InputField RegisterPassword;
    
    void Start()
    {
        TimeE1 = 1f;
        CountE1 = TimeE1;
    }

    // Update is called once per frame
    void Update()
    {
        RandomEnemy1();
    }

    void RandomEnemy1()
    {
        CountE1 -= Time.deltaTime;
        if (CountE1 <= 0)
        {
            CountE1 = TimeE1;
          GameObject go1 =  Instantiate(Enemy1);
            go1.transform.position = new Vector3(

                Random.Range(0, 9), -2f, 0);
        }
    }



}