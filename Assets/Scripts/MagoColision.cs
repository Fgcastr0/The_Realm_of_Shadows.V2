using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MagoColision : MonoBehaviour
{
    SoundManager soundManager;

    Image barraVida;
    public int vidaInicial = 3;
    private int vidaActual;

    [Header("Sprites por vida")]
    [SerializeField] private Sprite maximaVida;
    [SerializeField] private Sprite mediaVida;
    [SerializeField] private Sprite pocaVida;
    [SerializeField] private Sprite sinVida;

    void Start()
    {
        barraVida = GameObject.FindGameObjectWithTag("ImagenVida")?.GetComponent<Image>();
        soundManager = GameObject.FindGameObjectWithTag("Sound").GetComponent<SoundManager>();

        // Carga la vida guardada, si no existe, usa la vida inicial
        vidaActual = PlayerPrefs.GetInt("VidaJugador", vidaInicial);
        Debug.Log("vidaActual: " + vidaActual);
        if (barraVida != null)
        {
            ActualizarBarraVida(); // Actualiza la UI de la barra de vida al iniciar
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && gameObject.CompareTag("Player"))
        {
            if (soundManager.fail != null)
            {
                vidaActual--;
                PlayerPrefs.SetInt("VidaJugador", vidaActual); // Guarda la vida después de cada golpe
                PlayerPrefs.Save(); // Asegura que se guarde en disco

                Debug.Log("vidaActual: " + vidaActual);
                if (barraVida != null)
                {
                    ActualizarBarraVida(); // Actualiza la UI de la barra de vida
                }

                if (vidaActual <= 0)
                {
                    StartCoroutine(CargarPortalesConSonido());
                    PlayerPrefs.DeleteKey("VidaJugador"); // Resetea la vida al Game Over para el próximo juego
                }
                else
                {
                    StartCoroutine(ReiniciarJuegoConSonido());
                }
            }
            else
            {
                Debug.LogWarning("Falta asignar el sonido de impacto o el AudioSource.");
                CargarEscenaPortales();
            }
        }
    }

    IEnumerator CargarPortalesConSonido()
    {
        soundManager.PlaySFX(soundManager.gameOver);
        yield return new WaitForSeconds(soundManager.gameOver.length);
        CargarEscenaPortales();
    }

    IEnumerator ReiniciarJuegoConSonido()
    {
        soundManager.PlaySFX(soundManager.fail);
        yield return new WaitForSeconds(soundManager.fail.length);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void CargarEscenaPortales()
    {
        soundManager.StopMusic();
        soundManager.PlayMusic(soundManager.musicPortales);
        SceneManager.LoadScene("Portales");
    }

    private void ActualizarBarraVida()
    {
        if (barraVida == null)
        {
            Debug.LogWarning("No se encontró la barra de vida.");
            return;
        }

        if (vidaActual == 3)
            barraVida.sprite = maximaVida;
        else if (vidaActual == 2)
            barraVida.sprite = mediaVida;
        else if (vidaActual == 1)
            barraVida.sprite = pocaVida;
        else if (vidaActual == 0)
            barraVida.sprite = sinVida;
    }
}
