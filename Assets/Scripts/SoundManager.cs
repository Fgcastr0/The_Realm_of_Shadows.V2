using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    [Header("Audio Source")]
    [SerializeField] AudioSource musicSrc;
    [SerializeField] AudioSource sfxSrc;
    [SerializeField] AudioSource backgrdSrc;

    [Header("Audio Clips")]
    public AudioClip musicPortales;
    public AudioClip musicOscuridad;
    public AudioClip musicFinal;
    public AudioClip musicHielo;
    public AudioClip musicFuego;
    public AudioClip bckgrd;
    public AudioClip fail;
    public AudioClip walk;
    public AudioClip miau;
    public AudioClip gameOver;

    // shots weapons
    public AudioClip fireShot;
    public AudioClip iceShot;
    public AudioClip darkShot;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        // Solo reproducir música si estamos en la escena de Portales
        if (SceneManager.GetActiveScene().name == "Portales")
        {
            PlayMusic(musicPortales);
        }
    }

    public void PlaySFX(AudioClip clip)
    {
        sfxSrc.PlayOneShot(clip);
    }

    public void PlayMusic(AudioClip clip)
    {
        musicSrc.clip = clip;
        musicSrc.Play();
    }

    public void StopMusic()
    {
        musicSrc.Stop();
    }
}
