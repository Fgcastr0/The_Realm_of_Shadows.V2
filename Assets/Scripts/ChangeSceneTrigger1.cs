using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneTrigger1 : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // El Mago debe tener el Tag "Player"
        {
            Debug.Log("Cargando TorreFuego...");
            SceneManager.LoadScene("TorreFuego");
        }
    }
}
