using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerStats : MonoBehaviour
{
    [Header("Vida")]
    public int vidaMaxima = 4;
    public int vidaActual;

    [SerializeField] private Slider barraVida;

    [Header("Mana")]
    public int manaMaximo = 5;
    public int manaActual;

    [SerializeField] private Slider barraMana;

    [SerializeField] private KeyCode regenerarManaKey = KeyCode.M;
    [SerializeField] private float velocidadRecuperacionMana = 1f; // segundos por punto de mana

    private SoundManager soundManager;
    private bool regenerandoMana = false;

    void Start()
    {
        soundManager = GameObject.FindGameObjectWithTag("Sound")?.GetComponent<SoundManager>();

        vidaActual = vidaMaxima;
        manaActual = manaMaximo;

        if (barraVida != null)
        {
            barraVida.maxValue = vidaMaxima;
            barraVida.value = vidaActual;
        }
        else
        {
            Debug.LogWarning("No asignaste el Slider de vida en PlayerStats");
        }

        if (barraMana != null)
        {
            barraMana.maxValue = manaMaximo;
            barraMana.value = manaActual;
        }
        else
        {
            Debug.LogWarning("No asignaste el Slider de mana en PlayerStats");
        }
    }

    void Update()
    {
        if (Input.GetKey(regenerarManaKey) && manaActual < manaMaximo && !regenerandoMana)
        {
            StartCoroutine(RegenerarManaProgresivo());
        }
    }

    public void RecibirDaño()
    {
        if (vidaActual <= 0)
            return;

        vidaActual--;
        ActualizarBarraVida();

        if (vidaActual > 0)
        {
            if (soundManager != null)
                soundManager.PlaySFX(soundManager.fail);
        }
        else
        {
            StartCoroutine(GameOver());
        }
    }

    public bool ConsumirMana()
    {
        if (manaActual > 0)
        {
            manaActual--;
            ActualizarBarraMana();
            return true;
        }
        else
        {
            // No hay mana suficiente para usar
            return false;
        }
    }

    private IEnumerator RegenerarManaProgresivo()
    {
        regenerandoMana = true;
        while (manaActual < manaMaximo && Input.GetKey(regenerarManaKey))
        {
            manaActual++;
            ActualizarBarraMana();
            yield return new WaitForSeconds(velocidadRecuperacionMana);
        }
        regenerandoMana = false;
    }

    private void ActualizarBarraVida()
    {
        if (barraVida != null)
            barraVida.value = vidaActual;
    }

    private void ActualizarBarraMana()
    {
        if (barraMana != null)
            barraMana.value = manaActual;
    }

    private IEnumerator GameOver()
    {
        if (soundManager != null)
            soundManager.PlaySFX(soundManager.gameOver);

        yield return new WaitForSeconds(soundManager.gameOver.length);

        CargarEscenaPortales();
    }

    private void CargarEscenaPortales()
    {
        if (soundManager != null)
        {
            soundManager.StopMusic();
            soundManager.PlayMusic(soundManager.musicPortales);
        }
        SceneManager.LoadScene("Portales");
    }
}
