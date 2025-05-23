using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MagoColision : MonoBehaviour
{
    SoundManager soundManager;

    void Start()
    {
        soundManager = GameObject.FindGameObjectWithTag("Sound").GetComponent<SoundManager>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Si colisiona con un enemigo y este objeto tiene el tag "Player"
        if (collision.gameObject.CompareTag("Enemy") && gameObject.CompareTag("Player"))
        {
            if (soundManager.fail != null)
            {
                StartCoroutine(CargarPortalesConSonido());
            }
            else
            {
                Debug.LogWarning("Falta asignar el sonido de impacto o el AudioSource.");
                CargarEscenaPortales();
            }
        }
    }

    IEnumerator CargarPortalesConSonido()
    {
        soundManager.PlaySFX(soundManager.fail);
        yield return new WaitForSeconds(soundManager.fail.length);
        CargarEscenaPortales();
    }

    void CargarEscenaPortales()
    {
        soundManager.StopMusic();
        soundManager.PlayMusic(soundManager.musicPortales);

        SceneManager.LoadScene("Portales");
    }
}
