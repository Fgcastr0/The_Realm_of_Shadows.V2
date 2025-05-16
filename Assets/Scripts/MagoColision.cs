using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MagoColision : MonoBehaviour
{
    public AudioClip sonidoImpacto;   // Sonido a reproducir al colisionar
    private AudioSource audioSource;  // Referencia al componente AudioSource

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            Debug.LogError("Falta el componente AudioSource en este GameObject.");
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Si colisiona con un enemigo y este objeto tiene el tag "Player"
        if (collision.gameObject.CompareTag("Enemy") && gameObject.CompareTag("Player"))
        {
            if (sonidoImpacto != null && audioSource != null)
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
        audioSource.PlayOneShot(sonidoImpacto);
        yield return new WaitForSeconds(sonidoImpacto.length);
        CargarEscenaPortales();
    }

    void CargarEscenaPortales()
    {
        SceneManager.LoadScene("Portales");
    }
}
