using UnityEngine;
using UnityEngine.SceneManagement;

public class CambiarEscenaAlPresionar : MonoBehaviour
{
    [SerializeField] private string nombreEscenaDestino = "Portales";

    void Update()
    {
        if (Input.anyKeyDown)
        {
            SceneManager.LoadScene(nombreEscenaDestino);
        }
    }
}
