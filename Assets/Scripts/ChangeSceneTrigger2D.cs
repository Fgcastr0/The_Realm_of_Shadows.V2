using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneTrigger2D : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Verificamos qué tag tiene el objeto que entró al trigger
        if (other.CompareTag("Varita Hielo"))
        {
            Debug.Log("Varita Hielo detectada, cargando TorreHielo...");
            SceneManager.LoadScene("TorreHielo");
        }
        else if (other.CompareTag("Varita Fuego"))
        {
            Debug.Log("Varita Fuego detectada, cargando TorreFuego...");
            SceneManager.LoadScene("TorreFuego");
        }
        else if (other.CompareTag("Varita"))
        {
            Debug.Log("Varita normal detectada, cargando Puertas...");
            SceneManager.LoadScene("Puertas");
        }
    }
}
