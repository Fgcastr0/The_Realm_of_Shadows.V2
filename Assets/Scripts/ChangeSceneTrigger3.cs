using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneTrigger3 : MonoBehaviour
{
    SoundManager soundManager;

    private void OnTriggerEnter2D(Collider2D other)
    {
        soundManager = GameObject.FindGameObjectWithTag("Sound").GetComponent<SoundManager>();

        if (other.CompareTag("Player")) // El Mago debe tener el Tag "Player"
        {
            Debug.Log("Cargando Oscuridad...");

            soundManager.StopMusic();
            soundManager.PlayMusic(soundManager.musicOscuridad);

            SceneManager.LoadScene("TorreOscuridad");
        }
    }
}
