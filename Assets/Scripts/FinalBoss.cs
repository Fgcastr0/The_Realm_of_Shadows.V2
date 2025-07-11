using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(SpriteRenderer))]
public class FinalBoss : MonoBehaviour
{
    public float idleTime = 5f;
    public float moveSpeed = 2f;

    private Animator animator;
    private SpriteRenderer spriteRenderer;
    private Transform player;

    private float idleTimer = 0f;
    private bool isChasing = false;
    private bool isDead = false;

    // 🧊🔥🌑 Contadores de impacto por tipo
    private int hieloHits = 0;
    private int fuegoHits = 0;
    private int oscuridadHits = 0;

    void Start()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        player = GameObject.FindGameObjectWithTag("Player")?.transform;

        if (player == null)
        {
            Debug.LogError("No se encontró el GameObject con la tag 'Player'");
        }

        spriteRenderer.flipX = false;
        animator.Play("BossFinalIdel");
    }

    void Update()
    {
        if (player == null || isDead) return;

        idleTimer += Time.deltaTime;

        if (!isChasing && idleTimer >= idleTime)
        {
            isChasing = true;
            animator.Play("BossFinalWalk");
        }

        if (isChasing)
        {
            Vector2 direction = (player.position - transform.position).normalized;
            transform.position += (Vector3)direction * moveSpeed * Time.deltaTime;

            if (direction.x > 0.01f)
                spriteRenderer.flipX = true;
            else if (direction.x < -0.01f)
                spriteRenderer.flipX = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isDead) return;

        string nombre = collision.name;

        if (nombre.Contains("ProjectilHielo"))
        {
            hieloHits++;
            Destroy(collision.gameObject);
        }
        else if (nombre.Contains("ProjectilFuego"))
        {
            fuegoHits++;
            Destroy(collision.gameObject);
        }
        else if (nombre.Contains("ProjectilOscuridad") && isChasing)
        {
            oscuridadHits++;
            Destroy(collision.gameObject);
        }

        // 🔴 Chequeo si recibió 2 de cada uno
        if (hieloHits >= 2 && fuegoHits >= 2 && oscuridadHits >= 2)
        {
            Morir();
        }

        if (collision.CompareTag("Player"))
        {
            PlayerStats stats = collision.GetComponent<PlayerStats>();
            if (stats != null)
            {
                Vector2 direccionEmpujon = (collision.transform.position - transform.position).normalized;
                stats.RecibirDaño(direccionEmpujon);
            }
            else
            {
                Debug.LogWarning("No se encontró PlayerStats en el GameObject con tag Player.");
            }
        }
    }

    private void Morir()
    {
        isDead = true;
        animator.Play("FinalBossMuerte");

        // Obtener duración de la animación actual y destruir después
        float duracion = animator.GetCurrentAnimatorStateInfo(0).length;
        StartCoroutine(DestruirDespues(duracion));
    }

    private IEnumerator DestruirDespues(float segundos)
    {
        yield return new WaitForSeconds(segundos);
        Destroy(gameObject);
    }
}
