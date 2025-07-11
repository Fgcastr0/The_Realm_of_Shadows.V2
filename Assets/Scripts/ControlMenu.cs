using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlMenu : MonoBehaviour
{
    // Este método se llama al presionar el botón "Start"
    public void BackMenu()
    {
        SceneManager.LoadScene("MenuPrincipal");
    }
}
