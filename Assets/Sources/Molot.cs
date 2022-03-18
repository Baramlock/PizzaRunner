using DG.Tweening;
using UnityEngine;

public class Molot : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _yHight;
    private void Start()
    {
        transform.DOMoveY(_yHight, _speed).SetLoops(-1, LoopType.Yoyo);
    }
}
