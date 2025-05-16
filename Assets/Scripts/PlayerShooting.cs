using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [Header("Disparo")]
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private float projectileSpeed = 10f;
    [SerializeField] private KeyCode shootKey = KeyCode.Space;
    [SerializeField] private float shootCooldown = 0.2f;

    private PlayerMovementTD playerMovement;
    private float lastShotTime;

    private void Start()
    {
        playerMovement = GetComponent<PlayerMovementTD>();

        if (playerMovement == null)
        {
            Debug.LogError("PlayerMovement no encontrado.");
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(shootKey) && Time.time >= lastShotTime + shootCooldown)
        {
            Shoot();
            lastShotTime = Time.time;
        }
    }

    private void Shoot()
    {
        if (projectilePrefab == null || playerMovement == null) return;

        Vector2 shootDirection = playerMovement.LastDirection.normalized;
        Vector3 spawnPosition = transform.position + (Vector3)(shootDirection * 0.5f);

        GameObject projectile = Instantiate(projectilePrefab, spawnPosition, Quaternion.identity);

        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.velocity = shootDirection * projectileSpeed;
        }

        // Debug opcional
        // Debug.Log("Proyectiles activos: " + GameObject.FindGameObjectsWithTag("Projectile").Length);
    }
}
