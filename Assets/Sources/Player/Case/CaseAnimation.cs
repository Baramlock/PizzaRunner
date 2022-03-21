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
    public void StartAnimationCorutinne(List<Item> list)
    {
        StartCoroutine(StartAnimations(list));
    }

    private void Start()
    {
        _waitForSeconds = new WaitForSeconds(_waitNext);
    }

    private IEnumerator StartAnimations(List<Item> list)
    {
        yield return new WaitForEndOfFrame();
        for (int i = list.Count - 1; i >= 0; i--)
        {
            Debug.Log(i);
            var tween = DOTween.Sequence();
            tween.Append(list[i].Transform.DOScale(_scaleAnimation, _timeAnimation));
            tween.Append(list[i].Transform.DOScale(1, _timeAnimation));
            yield return _waitForSeconds;
        }
    }
}
