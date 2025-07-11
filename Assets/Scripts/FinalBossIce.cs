using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(SpriteRenderer))]
public class FinalBossIce : MonoBehaviour
{
    public float idleTime = 7f;
    public float moveSpeed = 2f;
    public int maxHits = 3;

    private Animator animator;
    private SpriteRenderer spriteRenderer;
    private Transform player;
    private int hitCount = 0;
    private float idleTimer = 0f;
    private bool isChasing = false;

    void Start()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        player = GameObject.FindGameObjectWithTag("Player")?.transform;

        if (player == null)
        {
            Debug.LogError("No se encontró el GameObject con la tag 'Player'");
        }

        // 🟢 Arranca mirando a la izquierda (flipped)
        spriteRenderer.flipX = false;

        animator.Play("BossHieloIdel");
    }

    void Update()
    {
        if (player == null) return;

        idleTimer += Time.deltaTime;

        if (!isChasing && idleTimer >= idleTime)
        {
            isChasing = true;
            animator.Play("BossWalk");
        }

        if (isChasing)
        {
            Vector2 direction = (player.position - transform.position).normalized;
            transform.position += (Vector3)direction * moveSpeed * Time.deltaTime;

            // 🟡 Flip visual usando SpriteRenderer (no escala)
            if (direction.x > 0.01f)
            {
                spriteRenderer.flipX = true; // Mira a la derecha
            }
            else if (direction.x < -0.01f)
            {
                spriteRenderer.flipX = false; // Mira a la izquierda
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name.Contains("ProjectilHielo") && isChasing)
        {
            hitCount++;

            if (hitCount >= maxHits)
            {
                Destroy(gameObject);
            }

            Destroy(collision.gameObject);
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
}
