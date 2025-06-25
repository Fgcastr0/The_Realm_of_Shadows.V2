using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverSceneLoader : MonoBehaviour
{
    public static GameOverSceneLoader instance;

    private void Awake()
    {
        // Singleton para mantener acceso global si es necesario
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Opcional si querés mantener entre escenas
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void CargarEscenaGameOver()
    {
        string escenaActual = SceneManager.GetActiveScene().name;

        switch (escenaActual)
        {
            case "TorreFuego":
                SceneManager.LoadScene("GameOverFuego");
                break;
            case "TorreHielo":
                SceneManager.LoadScene("GameOverHielo");
                break;
            case "TorreOscuridad":
                SceneManager.LoadScene("GameOverOscuridad");
                break;
            default:
                Debug.LogWarning("No se detectó una escena válida para game over.");
                SceneManager.LoadScene("Portales"); // fallback
                break;
        }
    }
}
