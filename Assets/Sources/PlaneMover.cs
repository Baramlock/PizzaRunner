using UnityEngine;

public class PlaneMover : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    public float MoveSpeed => _moveSpeed;

    private void Update()
    {
        transform.Translate(_moveSpeed * Time.deltaTime * Vector3.forward);
    }
}
