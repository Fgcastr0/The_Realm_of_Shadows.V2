using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    [Header("Vida")]
    public int vidaMaxima = 4;
    public int vidaActual;
    [SerializeField] private Slider barraVida;

    [Header("Maná")]
    public int manaMaximo = 5;
    public int manaActual;
    [SerializeField] private Slider barraMana;

    [Header("Empujón")]
    public float fuerzaEmpujon = 12f;

    [Header("Invencibilidad")]
    public float tiempoInvencibilidad = 1.0f;
    private bool puedeRecibirDaño = true;

    private SoundManager soundManager;
    private Rigidbody2D rb;

    private float manaRechargeInterval = 0.5f;
    private float manaRechargeTimer = 0f;

    private bool isStunned = false;

    void Start()
    {
        soundManager = GameObject.FindGameObjectWithTag("Sound")?.GetComponent<SoundManager>();
        rb = GetComponent<Rigidbody2D>();

        vidaActual = vidaMaxima;
        manaActual = manaMaximo;

        ActualizarBarraVida();
        ActualizarBarraMana();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.M))
        {
            manaRechargeTimer += Time.deltaTime;
            if (manaRechargeTimer >= manaRechargeInterval)
            {
                RegenerarMana(1);
                manaRechargeTimer = 0f;
            }
        }
        else
        {
            manaRechargeTimer = 0f;
        }
    }

    public void RecibirDaño(Vector2 direccionEmpujon)
    {
        if (!puedeRecibirDaño) return;

        vidaActual--;
        ActualizarBarraVida();

        if (soundManager != null)
            soundManager.PlaySFX(soundManager.fail);

        if (direccionEmpujon != Vector2.zero)
        {
            StartCoroutine(ApplyKnockback(direccionEmpujon));
        }

        if (vidaActual <= 0)
        {
            if (SceneManager1.Instance != null)
                SceneManager1.Instance.MostrarGameOver();
            else
                Debug.LogWarning("SceneManager1 no encontrado.");
        }

        StartCoroutine(InvencibilidadCooldown());
    }

    private IEnumerator InvencibilidadCooldown()
    {
        puedeRecibirDaño = false;
        yield return new WaitForSeconds(tiempoInvencibilidad);
        puedeRecibirDaño = true;
    }

    private IEnumerator ApplyKnockback(Vector2 direccionEmpujon)
    {
        isStunned = true;

        float knockbackDuration = 0.3f;
        float elapsed = 0f;
        Vector3 startPos = transform.position;
        Vector3 targetPos = startPos + (Vector3)(direccionEmpujon.normalized * fuerzaEmpujon * 0.1f);

        while (elapsed < knockbackDuration)
        {
            transform.position = Vector3.Lerp(startPos, targetPos, elapsed / knockbackDuration);
            elapsed += Time.deltaTime;
            yield return null;
        }

        transform.position = targetPos;

        isStunned = false;
    }

    public bool ConsumirMana(int cantidad)
    {
        if (manaActual >= cantidad)
        {
            manaActual -= cantidad;
            ActualizarBarraMana();
            return true;
        }
        return false;
    }

    public void RegenerarMana(int cantidad)
    {
        manaActual += cantidad;
        if (manaActual > manaMaximo)
            manaActual = manaMaximo;

        ActualizarBarraMana();
    }

    public float ObtenerFuerzaEmpujon()
    {
        return fuerzaEmpujon;
    }

    public bool EstaAturdido()
    {
        return isStunned;
    }

    void ActualizarBarraVida()
    {
        if (barraVida != null)
            barraVida.value = vidaActual;
    }

    void ActualizarBarraMana()
    {
        if (barraMana != null)
            barraMana.value = manaActual;
    }
}
