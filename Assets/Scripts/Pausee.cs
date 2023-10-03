using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Pausee : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject pauseMenuScreen;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Paugame()
    {
        Time.timeScale = 0;
      
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
       
    }
    public void GoToMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
}
