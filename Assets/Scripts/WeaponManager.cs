using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    SoundManager soundManager;

    //Variable para mantener el manager entre escenas
    public static WeaponManager instance;

    private string weaponInUse = "fire";
    private int positionCurrentWeapon;
    private int positionNextWeapon;

    [Header("Prefabs de proyectiles")]
    public GameObject firePrefab;
    public GameObject icePrefab;
    public GameObject darkPrefab;

    // Prefab actualmente seleccionado
    private GameObject currentProjectilePrefab;

    private List<string> weapons = new List<string> { "fire", "ice", "dark" };

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
        soundManager = GameObject.FindGameObjectWithTag("Sound").GetComponent<SoundManager>();
        UpdateCurrentProjectile(); // Establece el primer prefab
    }

    public void ChangeWeapon()
    {
        positionCurrentWeapon = weapons.IndexOf(weaponInUse);
        positionNextWeapon = (positionCurrentWeapon + 1) % weapons.Count;
        weaponInUse = weapons[positionNextWeapon];

        UpdateCurrentProjectile(); // Actualiza el prefab a usar
    }

    private void UpdateCurrentProjectile()
    {
        switch (weaponInUse)
        {
            case "fire":
                currentProjectilePrefab = firePrefab;
                break;
            case "ice":
                currentProjectilePrefab = icePrefab;
                break;
            case "dark":
                currentProjectilePrefab = darkPrefab;
                break;
        }
    }

    public GameObject GetCurrentProjectilePrefab()
    {
        return currentProjectilePrefab;
    }

    public void ShotSound()
    {
        switch (weaponInUse)
        {
            case "fire":
                soundManager.PlaySFX(soundManager.fireShot);
                break;
            case "ice":
                soundManager.PlaySFX(soundManager.iceShot);
                break;
            case "dark":
                soundManager.PlaySFX(soundManager.darkShot);
                break;
        }
    }
}
