using UnityEngine;
using System.Collections;

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
    [SerializeField] private float shootingDelay = 0.3f; // ⏱️ Tiempo desde que arranca la animación hasta que dispara

    private PlayerMovementTD playerMovement;
    private Animator animator;
    private float lastShotTime;

    private void Start()
    {
        playerMovement = GetComponent<PlayerMovementTD>();
        animator = GetComponent<Animator>();
        soundManager = GameObject.FindGameObjectWithTag("Sound").GetComponent<SoundManager>();
        weaponManager = GameObject.FindGameObjectWithTag("WeaponManager").GetComponent<WeaponManager>();
        playerStats = GetComponent<PlayerStats>();

        if (playerMovement == null)
            Debug.LogError("PlayerMovement no encontrado.");
        if (animator == null)
            Debug.LogError("Animator no encontrado.");
    }

    private void Update()
    {
        if (Input.GetKeyDown(changeWeaponKey))
        {
            weaponManager.ChangeWeapon();
        }

        if (Input.GetKeyDown(shootKey) && Time.time >= lastShotTime + shootCooldown)
        {
            StartCoroutine(DisparoConDelay(shootingDelay));
            lastShotTime = Time.time;
        }
    }

    private IEnumerator DisparoConDelay(float delay)
    {
        // Verifica maná antes de disparar
        if (playerStats == null || !playerStats.ConsumirMana(1)) yield break;

        // Reproducir animación de ataque
        animator.SetTrigger("Attack");

        // Esperar el delay para sincronizar con la animación
        yield return new WaitForSeconds(delay);

        // Disparar el proyectil
        Disparar();
    }

    private void Disparar()
    {
        GameObject currentPrefab = weaponManager.GetCurrentProjectilePrefab();
        if (currentPrefab == null || playerMovement == null) return;

        Vector2 shootDirection = playerMovement.LastDirection.normalized;
        Vector3 spawnPosition = transform.position + (Vector3)(shootDirection * 0.5f);

        weaponManager.ShotSound();

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
