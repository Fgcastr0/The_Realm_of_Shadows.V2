using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Header("Spawn de enemigos")]
    [SerializeField] public GameObject enemigoPrefab; // IceGolem
    [SerializeField] private float tiempoEntreSpawns = 7f;

    [Header("Opcional - Puntos")]
    [SerializeField] private bool sumarPuntoAlDestruir = true;

    private bool activo = true;

    void Start()
    {
        StartCoroutine(SpawnEnemigos());
    }

    IEnumerator SpawnEnemigos()
    {
        while (activo)
        {
            yield return new WaitForSeconds(tiempoEntreSpawns);

            if (enemigoPrefab != null)
            {
                Instantiate(enemigoPrefab, transform.position, Quaternion.identity);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Projectil"))
        {
            Destroy(collision.gameObject);

            if (sumarPuntoAlDestruir)
            {
                GameObject hud = GameObject.Find("HUD");
                if (hud != null)
                {
                    HUDController controlador = hud.GetComponent<HUDController>();
                    if (controlador != null)
                    {
                        controlador.SumarPunto();
                    }
                }
            }

            Destroy(gameObject); // Se destruye el cristal
        }
    }

    private void OnDestroy()
    {
        activo = false; // Detiene el ciclo de spawneo
    }
}
