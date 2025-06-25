using UnityEngine;

public class PlayerDamageTrigger : MonoBehaviour
{
    private PlayerStats playerStats;

    void Start()
    {
        playerStats = GetComponent<PlayerStats>();
        if (playerStats == null)
        {
            Debug.LogError("PlayerStats no encontrado en Player.");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            Vector2 direccionEmpujon = (transform.position - other.transform.position).normalized;
            playerStats.RecibirDaño(direccionEmpujon);
        }
    }
}
