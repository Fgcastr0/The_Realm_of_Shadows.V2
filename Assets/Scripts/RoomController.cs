using UnityEngine;

public class RoomController : MonoBehaviour
{
    public GameObject[] puertas;
    [SerializeField] private PuertaCalavera puertaCalavera;

    private bool completada = false;

    void Start()
    {
        CerrarPuertas();
    }

    void Update()
    {
        if (completada) return;

        GameObject[] enemigos = GameObject.FindGameObjectsWithTag("Enemy");
        int enemigosDentro = 0;

        foreach (GameObject enemigo in enemigos)
        {
            if (enemigo.transform.IsChildOf(transform))
            {
                enemigosDentro++;
            }
        }

        Debug.Log($"{gameObject.name} tiene {enemigosDentro} enemigos dentro");

        if (enemigosDentro == 0)
        {
            AbrirPuertas();
            completada = true;
            Debug.Log($"{gameObject.name} COMPLETADA");
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
        Debug.Log("Llamando a AbrirPuerta() de la calavera");

        foreach (GameObject puerta in puertas)
        {
            if (puerta != null)
            {
                // ✅ En lugar de desactivarla, desactivamos su collider
                Collider2D col = puerta.GetComponent<Collider2D>();
                if (col != null) col.enabled = false;
            }
        }

        if (puertaCalavera != null)
        {
            puertaCalavera.AbrirPuerta();
        }
        else
        {
            Debug.LogWarning("puertaCalavera no asignada en " + gameObject.name);
        }
    }

    private void CerrarPuertas()
    {
        foreach (GameObject puerta in puertas)
        {
            if (puerta != null)
            {
                // ✅ Volvemos a activar el collider
                Collider2D col = puerta.GetComponent<Collider2D>();
                if (col != null) col.enabled = true;
            }
        }

        if (puertaCalavera != null)
        {
            puertaCalavera.CerrarPuerta();
        }
    }

    public bool EstaCompletada()
    {
        return completada;
    }
}
