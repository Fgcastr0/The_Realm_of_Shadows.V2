using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SoundManager : MonoBehaviour
{
    //Variable para mantener el manager entre escenas
    public static SoundManager instance;
    //El static permite referenciar a la misma clase, en este caso SoundManager

    [Header("Audio Source")]
    [SerializeField] AudioSource musicSrc;
    [SerializeField] AudioSource sfxSrc;
    [SerializeField] AudioSource backgrdSrc;


    [Header("Audio Clips")]
    public AudioClip musicPortales;
    public AudioClip musicOscuridad;
    public AudioClip musicHielo;
    public AudioClip musicFuego;
    public AudioClip bckgrd;
    public AudioClip fail;
    public AudioClip walk;
    public AudioClip miau;

    // shots weapons
    public AudioClip fireShot;
    public AudioClip iceShot;
    public AudioClip darkShot;


    void Awake()
    {
        //Código para que la instancia del Sound Manager no se repita por error
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
        PlayMusic(musicPortales);
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
