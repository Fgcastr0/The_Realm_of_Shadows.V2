using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneTrigger2 : MonoBehaviour
{
    SoundManager soundManager;

    private void OnTriggerEnter2D(Collider2D other)
    {
        soundManager = GameObject.FindGameObjectWithTag("Sound").GetComponent<SoundManager>();
        soundManager.StopMusic();
        soundManager.PlayMusic(soundManager.musicPortales);

        if (other.CompareTag("Player")) // El Mago debe tener el Tag "Player"
        {
            Debug.Log("Cargando Portales...");
            SceneManager.LoadScene("Portales");
        }
    }
}
