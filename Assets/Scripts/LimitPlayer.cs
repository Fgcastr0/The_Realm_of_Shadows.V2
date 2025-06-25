using UnityEngine;

public class LimitPlayer : MonoBehaviour
{
    [SerializeField] private float leftLimit = -7.2f;
    [SerializeField] private float rightLimit = 7.32f;
    [SerializeField] private float bottomLimit = -3.4f;
    [SerializeField] private float topLimit = 2.77f;

    private void FixedUpdate()
    {
        Vector3 pos = transform.position;

        pos.x = Mathf.Clamp(pos.x, leftLimit, rightLimit);
        pos.y = Mathf.Clamp(pos.y, bottomLimit, topLimit);

        transform.position = pos;
    }
}
