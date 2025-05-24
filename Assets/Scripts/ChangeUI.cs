using UnityEngine;

public class ChangeUI : MonoBehaviour
{
    public GameObject fondo;
    public GameObject estadisticas;

    private bool mostrarFondo = true;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (mostrarFondo)
            {
                fondo.SetActive(false);
                estadisticas.SetActive(true);
            }
            else
            {
                fondo.SetActive(true);
                estadisticas.SetActive(false);
            }

            mostrarFondo = !mostrarFondo;
        }
    }
}
