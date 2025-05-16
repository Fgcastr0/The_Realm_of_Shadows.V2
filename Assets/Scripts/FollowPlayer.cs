using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float range;
    [SerializeField] private GameObject character;

    private bool facingRight = false; // Ahora empieza como si mirara a la izquierda

    void Update()
    {
        float distance = Vector3.Distance(transform.position, character.transform.position);

        if (distance > range)
        {
            // Mover hacia el personaje
            transform.position = Vector3.MoveTowards(transform.position, character.transform.position, speed * Time.deltaTime);

            // Determinar dirección
            Vector3 direction = character.transform.position - transform.position;

            // Corregimos el flip
            if (direction.x > 0 && !facingRight)
            {
                Flip();
            }
            else if (direction.x < 0 && facingRight)
            {
                Flip();
            }
        }
    }

    private void Flip()
    {
        facingRight = !facingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1; // Invierte la escala horizontalmente
        transform.localScale = scale;
    }
}
