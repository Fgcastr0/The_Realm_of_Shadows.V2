using UnityEngine;

public class GatoSeguir1 : MonoBehaviour
{
    SoundManager soundManager;

    public Transform personaje;           // El personaje principal
    public float velocidad = 3f;          // Velocidad del gato
    public float distanciaMinima = 0.5f;  // Distancia para detenerse
    private Animator animator;
    private SpriteRenderer spriteRenderer;

    public float tiempoEntreAcciones = 10f; // Tiempo en segundos para maullido
    private float contadorTiempo;

    void Start()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>(); // Necesario para el flip
        soundManager = GameObject.FindGameObjectWithTag("Sound").GetComponent<SoundManager>();
    }

    void Update()
    {
        float distancia = Vector3.Distance(transform.position, personaje.position);

        if (distancia > distanciaMinima)
        {
            // Calcular dirección hacia el personaje
            Vector3 direccion = (personaje.position - transform.position).normalized;

            // Mover el gato hacia el personaje
            transform.position += direccion * velocidad * Time.deltaTime;

            // Activar animación de movimiento
            animator.SetBool("EstaMoviendose", true);

            // Flip: si se mueve a la izquierda, girar el sprite
            if (direccion.x < 0)
                spriteRenderer.flipX = true;  // Mira a la izquierda
            else if (direccion.x > 0)
                spriteRenderer.flipX = false; // Mira a la derecha
        }
        else
        {
            // Quieto: idle
            animator.SetBool("EstaMoviendose", false);
        }

        // --- Lógica del temporizador de maullido ---
        contadorTiempo -= Time.deltaTime;
        if (contadorTiempo <= 0)
        {
            soundManager.PlaySFX(soundManager.miau);
            contadorTiempo = 10f;
        }
    }
}
