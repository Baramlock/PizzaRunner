using DG.Tweening;
using UnityEngine;

public class Blood : MonoBehaviour
{
    private void OnEnable()
    {
        transform.DOScaleX(0.17f, 0.2f);
        transform.DOScaleZ(0.17f, 0.2f);
    }
}
