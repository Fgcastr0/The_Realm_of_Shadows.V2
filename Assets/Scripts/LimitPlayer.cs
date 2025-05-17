using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimitPlayer : MonoBehaviour
{
    // Variables que utilizaremos para fijar límites (valores por defecto incluidos)
    [SerializeField] private float leftLimit = -7.2f;
    [SerializeField] private float rightLimit = 7.32f;
    [SerializeField] private float bottomLimit = -3.4f;
    [SerializeField] private float topLimit = 2.77f;

    private void FixedUpdate()
    {
        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x, leftLimit, rightLimit),
            Mathf.Clamp(transform.position.y, bottomLimit, topLimit),
            transform.position.z
        );
    }
}
