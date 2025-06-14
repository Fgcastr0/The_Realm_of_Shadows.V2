using UnityEngine;
using System.Collections.Generic;

public class PlayerAddMana : MonoBehaviour
{
    private GameObject canvasMana;

    void Start()
    {
        canvasMana = GameObject.FindGameObjectWithTag("manaParticulas");
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.M))
        {
            SetCanvasesActive(true);
        }
        else
        {
            SetCanvasesActive(false);
        }
    }

    void SetCanvasesActive(bool isActive)
    {
        canvasMana.SetActive(isActive);
    }
}