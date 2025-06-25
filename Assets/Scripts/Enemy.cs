using UnityEngine;

public class Enemy : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Si choca con proyectil
        if (collision.CompareTag("Projectil"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);

            // Sumar punto
            GameObject hud = GameObject.Find("HUD"); // Asegurate de nombrar tu GameObject HUD con este nombre
            if (hud != null)
            {
                HUDController controlador = hud.GetComponent<HUDController>();
                if (controlador != null)
                {
                    controlador.SumarPunto();
                }
            }
        }

        // Si choca con el jugador
        if (collision.CompareTag("Player"))
        {
            PlayerStats stats = collision.GetComponent<PlayerStats>();
            if (stats != null)
            {
                Vector2 direccionEmpujon = (collision.transform.position - transform.position).normalized;
                stats.RecibirDaño(direccionEmpujon);
            }
        }
    }
}
