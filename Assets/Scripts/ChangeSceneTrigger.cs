using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneTrigger : MonoBehaviour
{
    SoundManager soundManager;

    private void OnTriggerEnter2D(Collider2D other)
    {
        soundManager = GameObject.FindGameObjectWithTag("Sound").GetComponent<SoundManager>();

        if (other.CompareTag("Player")) // El Mago debe tener el Tag "Player"
        {
            Debug.Log("Cargando TorreHielo...");

            soundManager.StopMusic();
            soundManager.PlayMusic(soundManager.musicHielo);

            SceneManager.LoadScene("TorreHielo");
        }
    }
}
