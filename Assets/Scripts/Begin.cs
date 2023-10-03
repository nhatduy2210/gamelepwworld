using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Begin : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void BatDau()
    {
        SceneManager.LoadScene(4);

    }

    public void BatDauMan1()
    {
        SceneManager.LoadScene(5);

    }
    public void BatDauMan2()
    {
        SceneManager.LoadScene(3);

    }
}
