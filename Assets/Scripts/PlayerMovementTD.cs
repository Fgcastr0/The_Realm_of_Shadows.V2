using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(Animator), typeof(SpriteRenderer))]
public class PlayerMovementTD : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;

    private Rigidbody2D rb;
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    private Vector2 movement;

    public Vector2 LastDirection { get; private set; } = Vector2.right;

    private PlayerStats playerStats;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        playerStats = GetComponent<PlayerStats>();

        if (rb == null) Debug.LogError("No se encontró Rigidbody2D en Player.");
        if (animator == null) Debug.LogError("No se encontró Animator en Player.");
        if (spriteRenderer == null) Debug.LogError("No se encontró SpriteRenderer en Player.");
        if (playerStats == null) Debug.LogWarning("No se encontró PlayerStats en Player.");
    }

    private void Update()
    {
        if (playerStats != null && playerStats.EstaAturdido())
        {
            movement = Vector2.zero;
            animator.SetBool("isWalking", false);
            return;
        }

        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        // Prioriza movimiento horizontal
        if (movement.x != 0) movement.y = 0;

        animator.SetBool("isWalking", movement != Vector2.zero);

        // ✅ Solo actualizamos la dirección si se mueve en X (izquierda o derecha)
        if (movement.x != 0)
            LastDirection = new Vector2(movement.x, 0).normalized;

        // Flipping horizontal del sprite
        if (movement.x > 0)
            spriteRenderer.flipX = false;
        else if (movement.x < 0)
            spriteRenderer.flipX = true;

        // Animación de ataque
        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetTrigger("Attack");
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = movement.normalized * moveSpeed;
    }
}
