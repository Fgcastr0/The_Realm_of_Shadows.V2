using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LimitPlayer: MonoBehaviour
{


    // Variables que utilizaremos para fijar limites
    [SerializeField] private float leftLimit;
    [SerializeField] private float rightLimit;
    [SerializeField] private float bottomLimit;
    [SerializeField] private float topLimit;

    private void FixedUpdate()
    {
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, leftLimit, rightLimit), Mathf.Clamp(transform.position.y, bottomLimit, topLimit), transform.position.z);
    }
}
