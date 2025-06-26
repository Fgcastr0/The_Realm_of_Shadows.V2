using UnityEngine;
using UnityEngine.Rendering.Universal; // Necesario para Light2D

public class PuertaCalavera : MonoBehaviour
{
    public HabitacionManager habitacionManager;   // Asignar en el inspector
    public int idHabitacionDestino;               // Número de la habitación destino

    private Collider2D col;
    private Light2D luzPuerta;
    private bool puertaAbierta = false;

    void Start()
    {
        col = GetComponent<Collider2D>();
        luzPuerta = GetComponentInChildren<Light2D>();

        if (luzPuerta == null)
            Debug.LogWarning("No se encontró Light2D en un hijo de PuertaCalavera");

        CerrarPuerta(); // Al comenzar, está cerrada
    }

    public void AbrirPuerta()
    {
        puertaAbierta = true;

        if (col != null) col.enabled = true;
        if (luzPuerta != null) luzPuerta.enabled = true;

        Debug.Log("Puerta abierta y luz encendida");
    }

    public void CerrarPuerta()
    {
        puertaAbierta = false;

        if (col != null) col.enabled = false;
        if (luzPuerta != null) luzPuerta.enabled = false;

        Debug.Log("Puerta cerrada y luz apagada");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (puertaAbierta && other.CompareTag("Player"))
        {
            Debug.Log("El jugador entró en la puerta - cambiando a habitación " + idHabitacionDestino);
            habitacionManager.CambiarAHabitacion(idHabitacionDestino);
        }
    }
}
