using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneTrigger3 : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // El Mago debe tener el Tag "Player"
        {
            Debug.Log("Cargando Oscuridad...");
            SceneManager.LoadScene("TorreOscuridad");
        }
    }
}
