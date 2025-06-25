using UnityEngine;

public class PuertaCalavera : MonoBehaviour
{
    public HabitacionManager habitacionManager; // Referencia al manager de habitaciones
    public int idHabitacionDestino = 1; // A qué habitación llevar

    private Collider2D col;
    private bool puertaAbierta = false;

    void Start()
    {
        col = GetComponent<Collider2D>();

        // La puerta empieza invisible y cerrada
        gameObject.SetActive(false);
        if (col != null)
            col.enabled = false;
    }

    public void AbrirPuerta()
    {
        puertaAbierta = true;
        gameObject.SetActive(true); // Se vuelve visible
        if (col != null)
            col.enabled = true;
    }

    public void CerrarPuerta()
    {
        puertaAbierta = false;
        gameObject.SetActive(false); // Se vuelve invisible
        if (col != null)
            col.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!puertaAbierta) return;

        if (other.CompareTag("Player"))
        {
            Debug.Log("Jugador pasó por la puerta, cambiando habitación...");
            if (habitacionManager != null)
            {
                habitacionManager.CambiarAHabitacion(idHabitacionDestino);
            }
            else
            {
                Debug.LogWarning("HabitacionManager no asignado en PuertaCalavera.");
            }
        }
    }
}
