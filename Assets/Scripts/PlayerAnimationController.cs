using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerAnimationController : MonoBehaviour
{
    private Animator animator;
    private PlayerStats playerStats;

    private Vector2 movement;

    private void Start()
    {
        animator = GetComponent<Animator>();
        playerStats = GetComponent<PlayerStats>();

        if (playerStats == null)
            Debug.LogWarning("No se encontró PlayerStats en Player.");
    }

    private void Update()
    {
        // Bloquea animaciones de movimiento si está aturdido
        if (playerStats != null && playerStats.EstaAturdido())
        {
            movement = Vector2.zero;
            animator.SetBool("isWalking ", false);
            return;
        }

        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        // Prioriza movimiento horizontal
        if (movement.x != 0) movement.y = 0;

        // Activar animación de caminar
        if (movement != Vector2.zero)
            animator.SetBool("isWalking ", true);
        else
            animator.SetBool("isWalking ", false);

        // Activar animación de ataque
        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetTrigger("Attack");
        }
    }
}
