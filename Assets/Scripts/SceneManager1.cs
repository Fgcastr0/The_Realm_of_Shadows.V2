using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManager1 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    

        if (Input.GetKeyDown(KeyCode.F))
            SceneManager.LoadScene("Portales");


        if (Input.GetKeyDown(KeyCode.P)) {

            PauseGame();
        }
        if (Input.GetKeyDown(KeyCode.O)) {
            ResumeGame();
        }
        if (Input.GetKeyDown(KeyCode.Q)) {

            ApplicationQuit();
        }

    }
    void PauseGame()
    {
        Time.timeScale = 0;
    }

    void ResumeGame()
    {
        Time.timeScale = 1;
    }
    void ApplicationQuit()
    {
        Application.Quit();
    }
}
