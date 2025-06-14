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

    [SerializeField] private Sprite fuego;
    [SerializeField] private Sprite hielo;
    [SerializeField] private Sprite oscuridad;
    public GameObject projectilePrefab; // Cambié el nombre a 'projectilePrefab' para ser más claro que es un prefab
    [SerializeField] private SpriteRenderer projectileSpriteRenderer; // Referencia al SpriteRenderer si está en el mismo prefab


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
        projectileSpriteRenderer = projectilePrefab.GetComponent<SpriteRenderer>();
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

        if (projectileSpriteRenderer)
        {
            switch (weaponInUse)
            {
                case "fire":
                    projectileSpriteRenderer.sprite = fuego;
                    break;
                case "ice":
                    projectileSpriteRenderer.sprite = hielo;
                    break;
                case "dark":
                    projectileSpriteRenderer.sprite = oscuridad;
                    break;
            }
        }
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
