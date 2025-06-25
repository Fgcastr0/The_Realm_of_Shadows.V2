using System.Collections;
using UnityEngine;

public class FollowPlayerGolem : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float range;

    private GameObject character;
    private bool facingRight = true;

    void Start()
    {
        // Buscar automáticamente al GameObject con tag "Player"
        character = GameObject.FindGameObjectWithTag("Player");

        if (character == null)
        {
            Debug.LogWarning("No se encontró ningún GameObject con el tag 'Player'. Asegurate de que el mago tenga ese tag.");
        }
    }

    void Update()
    {
        if (character == null) return;

        float distance = Vector3.Distance(transform.position, character.transform.position);

        if (distance > range)
        {
            // Mover hacia el personaje
            transform.position = Vector3.MoveTowards(transform.position, character.transform.position, speed * Time.deltaTime);

            // Determinar dirección
            Vector3 direction = character.transform.position - transform.position;

            // Flip horizontal
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
        scale.x *= -1;
        transform.localScale = scale;
    }
}
