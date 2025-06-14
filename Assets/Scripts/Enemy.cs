using UnityEngine;

public class Enemy : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Si choca con proyectil
        if (collision.CompareTag("Projectil"))
        {
            Destroy(collision.gameObject); // destruye proyectil
            Destroy(gameObject); // destruye enemigo
        }

        // Si choca con el jugador
        if (collision.CompareTag("Player"))
        {
            PlayerStats stats = collision.GetComponent<PlayerStats>();
            if (stats != null)
            {
                stats.RecibirDaño();
            }
        }
    }
}
