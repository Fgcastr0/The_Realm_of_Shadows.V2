using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneManager1 : MonoBehaviour
{
    public static SceneManager1 Instance;

    public string escenaGameOverFuego = "GameOverFuego";
    public string escenaGameOverHielo = "GameOverHielo";
    public string escenaGameOverOscuridad = "GameOverOscuridad";
    public string escenaMenuPrincipal = "MenuPrincipal";

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void MostrarGameOver()
    {
        string escenaActual = SceneManager.GetActiveScene().name;
        string escenaGameOver = "";

        if (escenaActual == "TorreFuego")
            escenaGameOver = escenaGameOverFuego;
        else if (escenaActual == "TorreHielo")
            escenaGameOver = escenaGameOverHielo;
        else if (escenaActual == "TorreOscuridad")
            escenaGameOver = escenaGameOverOscuridad;
        else
        {
            Debug.LogWarning("Escena no reconocida para Game Over: " + escenaActual);
            return;
        }

        StartCoroutine(CambiarAEscenaGameOver(escenaGameOver));
    }

    private IEnumerator CambiarAEscenaGameOver(string escenaGameOver)
    {
        SceneManager.LoadScene(escenaGameOver);
        yield return new WaitForSeconds(7f);
        SceneManager.LoadScene(escenaMenuPrincipal);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            SceneManager.LoadScene("Portales");
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            PauseGame();
        }

        if (Input.GetKeyDown(KeyCode.O))
        {
            ResumeGame();
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
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
