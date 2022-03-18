using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class CaseAnimation : MonoBehaviour
{
    [SerializeField] private float _waitNext;
    [SerializeField] private float _timeAnimation;
    [SerializeField] private float _scaleAnimation;

    private WaitForSeconds _waitForSeconds;
    public void StartAnimationCorutinne(List<Transform> list)
    {
        StartCoroutine(StartAnimation(list));
    }

    private void Start()
    {
        _waitForSeconds = new WaitForSeconds(_waitNext);
    }

    private IEnumerator StartAnimation(List<Transform> list)
    {
        for (int i = list.Count - 1; i >= 0; i--)
        {
            list[i].DOScale(_scaleAnimation, _timeAnimation);
            list[i].DOScale(1, _timeAnimation).SetDelay(_timeAnimation);
            yield return _waitForSeconds;
        }
    }
}
