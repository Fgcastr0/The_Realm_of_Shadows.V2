using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    SoundManager soundManager;
    WeaponManager weaponManager;
    PlayerStats playerStats;

    [Header("Disparo")]
    [SerializeField] private float projectileSpeed = 10f;
    [SerializeField] private KeyCode shootKey = KeyCode.Space;
    [SerializeField] private KeyCode changeWeaponKey = KeyCode.L;
    [SerializeField] private float shootCooldown = 0.2f;

    private PlayerMovementTD playerMovement;
    private float lastShotTime;

    private void Start()
    {
        playerMovement = GetComponent<PlayerMovementTD>();
        soundManager = GameObject.FindGameObjectWithTag("Sound").GetComponent<SoundManager>();
        weaponManager = GameObject.FindGameObjectWithTag("WeaponManager").GetComponent<WeaponManager>();
        playerStats = GetComponent<PlayerStats>();

        if (playerMovement == null)
        {
            Debug.LogError("PlayerMovement no encontrado.");
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(changeWeaponKey))
        {
            weaponManager.ChangeWeapon();
        }

        if (Input.GetKeyDown(shootKey) && Time.time >= lastShotTime + shootCooldown)
        {
            Shoot();
            lastShotTime = Time.time;
        }
    }

    private void Shoot()
    {
        // Verifica maná suficiente
        if (playerStats == null || !playerStats.ConsumirMana()) return;

        GameObject currentPrefab = weaponManager.GetCurrentProjectilePrefab();
        if (currentPrefab == null || playerMovement == null) return;

        Vector2 shootDirection = playerMovement.LastDirection.normalized;
        Vector3 spawnPosition = transform.position + (Vector3)(shootDirection * 0.5f);

        weaponManager.ShotSound();  // Reproduce sonido del arma actual

        // Calcula rotación para mirar en dirección del disparo
        float angle = Mathf.Atan2(shootDirection.y, shootDirection.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.Euler(0, 0, angle);

        GameObject projectile = Instantiate(currentPrefab, spawnPosition, rotation);

        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.velocity = shootDirection * projectileSpeed;
        }
    }
}
