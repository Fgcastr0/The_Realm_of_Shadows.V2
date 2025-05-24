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
    // Start is called before the first frame update
    void Start()
    {
        soundManager = GameObject.FindGameObjectWithTag("Sound").GetComponent<SoundManager>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void ChangeWeapon()
    {
        positionCurrentWeapon = weapons.IndexOf(weaponInUse);
        positionNextWeapon = (positionCurrentWeapon + 1) % weapons.Count;
        weaponInUse = weapons[positionNextWeapon];
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
