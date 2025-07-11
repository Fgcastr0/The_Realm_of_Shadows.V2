using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Este método se llama al presionar el botón "Start"
    public void StartGame()
    {
        SceneManager.LoadScene("MenuInicio");
    }

    // Este método se llama al presionar el botón "Options"
    public void OpenOptions()
    {
        SceneManager.LoadScene("Controles");
    }

    // Este método se llama al presionar el botón "Exit"
    public void ExitGame()
    {
        Debug.Log("Saliendo del juego...");
        Application.Quit();
    }
}
