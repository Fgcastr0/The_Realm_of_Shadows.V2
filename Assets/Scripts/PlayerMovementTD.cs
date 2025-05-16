using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementTD : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;

    [Header("Sprites por dirección")]
    [SerializeField] private Sprite Arriba; // Arriba
    [SerializeField] private Sprite Abajo; // Abajo
    [SerializeField] private Sprite Derecha; // Derecha
    [SerializeField] private Sprite Izquierda; // Izquierda

    private SpriteRenderer spriteRenderer;
    private Vector2 movement;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        // Entrada del teclado
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        // Prioriza el movimiento en un solo eje
        if (movement.x != 0) movement.y = 0;

        UpdateDirectionSprite();
    }

    private void FixedUpdate()
    {
        // Movimiento
        transform.Translate(movement * moveSpeed * Time.fixedDeltaTime);
    }

    private void UpdateDirectionSprite()
    {
        if (movement.x > 0)
            spriteRenderer.sprite = Derecha; // Derecha
        else if (movement.x < 0)
            spriteRenderer.sprite = Izquierda; // Izquierda
        else if (movement.y > 0)
            spriteRenderer.sprite = Arriba; // Arriba
        else if (movement.y < 0)
            spriteRenderer.sprite = Abajo; // Abajo
    }
}
