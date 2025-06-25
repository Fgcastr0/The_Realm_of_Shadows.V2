using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneTrigger2 : MonoBehaviour
{
    private SoundManager soundManager;

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Si no es el jugador, ignorar
        if (!other.CompareTag("Player")) return;

        // Contar enemigos activos
        GameObject[] enemigos = GameObject.FindGameObjectsWithTag("Enemy");

        if (enemigos.Length == 0)
        {
            // Reproducir música y cambiar de escena
            soundManager = GameObject.FindGameObjectWithTag("Sound")?.GetComponent<SoundManager>();
            if (soundManager != null)
            {
                soundManager.StopMusic();
                soundManager.PlayMusic(soundManager.musicPortales);
            }

            Debug.Log("Cargando Portales...");
            SceneManager.LoadScene("Portales");
        }
        else
        {
            Debug.Log("Todavía hay enemigos en la escena (" + enemigos.Length + "), no se puede salir.");
        }
    }
}
