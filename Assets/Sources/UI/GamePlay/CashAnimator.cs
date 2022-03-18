using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class CashAnimator : MonoBehaviour
{
    [SerializeField] private Cash _cash;
    [SerializeField] private Transform _startPosition;
    [SerializeField] private Transform _endPosition;
    [SerializeField] private Transform _parentPlayer;

    [SerializeField] private float _timeBetweenAnimation = 0.25f;
    [SerializeField] private float _timeAnimation = 1;
    [SerializeField] private float _countToOnePizza = 3;

    private Pool<Cash> _poolCash;

    public void StartAnimation()
    {
        StartCoroutine(Animation());
    }

    private void Start()
    {
        _poolCash = new Pool<Cash>(_cash);
    }

    private IEnumerator Animation()
    {
        var time = new WaitForSeconds(_timeBetweenAnimation);

        var cashPool = new List<Cash>();
        for (int i = 0; i < _countToOnePizza; i++)
        {
            var cash = _poolCash.Get(_startPosition.position, _parentPlayer);
            cash.transform.DOMoveX(_endPosition.position.x, _timeAnimation);
            cash.transform.DOMoveY(_endPosition.position.y, _timeAnimation);
            cashPool.Add(cash);
            yield return time;
        }

        yield return new WaitForSeconds(_timeAnimation);
        _poolCash.Return(cashPool);
    }
}
