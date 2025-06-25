using UnityEngine;
using TMPro;

public class HUDController : MonoBehaviour
{
    [Header("Referencias UI")]
    public TextMeshProUGUI textoPuntos;
    public TextMeshProUGUI textoTiempo;

    private int enemigosDerrotados = 0;
    private float tiempoTranscurrido = 0f;

    void Update()
    {
        // Actualiza el temporizador
        tiempoTranscurrido += Time.deltaTime;
        int minutos = Mathf.FloorToInt(tiempoTranscurrido / 60);
        int segundos = Mathf.FloorToInt(tiempoTranscurrido % 60);
        textoTiempo.text = $"{minutos:0}:{segundos:00}";
    }

    public void SumarPunto()
    {
        enemigosDerrotados++;
        textoPuntos.text = enemigosDerrotados.ToString();
    }
}
