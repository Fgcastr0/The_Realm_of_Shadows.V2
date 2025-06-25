using UnityEngine;
using UnityEngine.SceneManagement;

public class EscenaController1 : MonoBehaviour
{
    private float tiempoEspera = 5f; // 5 segundos
    private float tiempoTranscurrido = 0f;

    void Update()
    {
        tiempoTranscurrido += Time.deltaTime;

        if (tiempoTranscurrido >= tiempoEspera)
        {
            SceneManager.LoadScene("TorreFuego");
        }
    }
}
