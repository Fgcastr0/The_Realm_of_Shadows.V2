using UnityEngine;

[RequireComponent(typeof(Animator))]
public class FinalBoss : MonoBehaviour
{
    public float idleTime = 7f;
    public float moveSpeed = 2f;
    public int maxHits = 3;

    private Animator animator;
    private Transform player;
    private int hitCount = 0;
    private float idleTimer = 0f;
    private bool isChasing = false;

    void Start()
    {
        animator = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player")?.transform;

        if (player == null)
        {
            Debug.LogError("No se encontró el GameObject con la tag 'Player'");
        }

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

            // Girar sprite según dirección horizontal
            if (direction.x > 0.01f)
            {
                transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            }
            else if (direction.x < -0.01f)
            {
                transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Recibir daño solo si ya está en modo persecución
        if (collision.name.Contains("ProjectilHielo") && isChasing)
        {
            hitCount++;

            if (hitCount >= maxHits)
            {
                Destroy(gameObject);
            }

            Destroy(collision.gameObject);
        }

        // Hacer daño al jugador (sin cooldown)
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
