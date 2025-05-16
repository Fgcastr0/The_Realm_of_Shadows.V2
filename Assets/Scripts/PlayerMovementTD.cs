using UnityEngine;

public class PlayerMovementTD : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;

    [Header("Sprites por dirección")]
    [SerializeField] private Sprite Arriba;
    [SerializeField] private Sprite Abajo;
    [SerializeField] private Sprite Derecha;
    [SerializeField] private Sprite Izquierda;

    private SpriteRenderer spriteRenderer;
    private Vector2 movement;

    public Vector2 LastDirection { get; private set; } = Vector2.down;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        if (movement.x != 0) movement.y = 0;

        if (movement != Vector2.zero)
            LastDirection = movement.normalized;

        UpdateDirectionSprite();
    }

    private void FixedUpdate()
    {
        transform.Translate(movement * moveSpeed * Time.fixedDeltaTime);
    }

    private void UpdateDirectionSprite()
    {
        if (movement.x > 0)
            spriteRenderer.sprite = Derecha;
        else if (movement.x < 0)
            spriteRenderer.sprite = Izquierda;
        else if (movement.y > 0)
            spriteRenderer.sprite = Arriba;
        else if (movement.y < 0)
            spriteRenderer.sprite = Abajo;
    }
}