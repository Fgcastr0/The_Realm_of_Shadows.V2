using UnityEngine;
using UnityEngine.Rendering.Universal; // Asegurate de tener el paquete URP instalado

public class LightOnRoomClear : MonoBehaviour
{
    [SerializeField] private GameObject puertaConLuz; // El GameObject que tiene la Light2D
    private Light2D luzPuerta;
    private bool luzEncendida = false;

    void Start()
    {
        if (puertaConLuz != null)
        {
            luzPuerta = puertaConLuz.GetComponent<Light2D>();
            if (luzPuerta != null)
            {
                luzPuerta.enabled = false; // Apagamos la luz al iniciar
            }
        }
    }

    void Update()
    {
        if (!luzEncendida)
        {
            GameObject[] enemigos = GameObject.FindGameObjectsWithTag("Enemy");

            int enemigosDentro = 0;
            foreach (GameObject enemigo in enemigos)
            {
                if (enemigo.transform.IsChildOf(transform)) // Solo enemigos de esta habitación
                    enemigosDentro++;
            }

            if (enemigosDentro == 0 && luzPuerta != null)
            {
                luzPuerta.enabled = true;
                luzEncendida = true;
                Debug.Log("Habitación despejada, luz activada en la puerta.");
            }
        }
    }
}
