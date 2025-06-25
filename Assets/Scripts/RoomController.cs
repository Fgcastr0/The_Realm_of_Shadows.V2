using UnityEngine;

public class RoomController : MonoBehaviour
{
    public GameObject[] puertas; // Otras puertas (opcional)
    [SerializeField] private PuertaCalavera puertaCalavera; // Referencia a la calavera

    private bool completada = false;

    void Start()
    {
        CerrarPuertas();
    }

    void Update()
    {
        if (!completada)
        {
            GameObject[] enemigos = GameObject.FindGameObjectsWithTag("Enemy");
            int enemigosDentro = 0;

            foreach (GameObject enemigo in enemigos)
            {
                if (enemigo.transform.IsChildOf(transform))
                    enemigosDentro++;
            }

            if (enemigosDentro == 0)
            {
                AbrirPuertas();
                completada = true;
                Debug.Log(gameObject.name + " completada");
            }
        }
    }

    public void ActivarHabitacion()
    {
        gameObject.SetActive(true);
        if (!completada)
            CerrarPuertas();
    }

    public void DesactivarHabitacion()
    {
        gameObject.SetActive(false);
    }

    private void AbrirPuertas()
    {
        foreach (GameObject puerta in puertas)
        {
            if (puerta != null)
                puerta.SetActive(false);
        }

        if (puertaCalavera != null)
        {
            puertaCalavera.AbrirPuerta(); // Activa la calavera
        }
    }

    private void CerrarPuertas()
    {
        foreach (GameObject puerta in puertas)
        {
            if (puerta != null)
                puerta.SetActive(true);
        }

        if (puertaCalavera != null)
        {
            puertaCalavera.CerrarPuerta(); // Desactiva la calavera
        }
    }

    public bool EstaCompletada()
    {
        return completada;
    }
}
