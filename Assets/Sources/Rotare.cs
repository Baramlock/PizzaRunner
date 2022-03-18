using UnityEngine;

public class Rotare : MonoBehaviour
{
    [SerializeField] private float speed = 1;

    private void Update()
    {
        transform.Rotate(0, 0, 1 * Time.deltaTime * speed);
    }
}
