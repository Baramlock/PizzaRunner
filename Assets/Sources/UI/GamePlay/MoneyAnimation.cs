using System.Collections;
using DG.Tweening;
using TMPro;
using UnityEngine;

public class MoneyAnimation : MonoBehaviour
{
    private readonly float _timeToFade = 0.2f;
    private readonly float _timeToCheckFade = 0.2f;

    [SerializeField] private MoneyPool _pool;
    [SerializeField] private Transform _startAnimation;
    [SerializeField] private Transform _endAnimation;

    private int _moneyCombo;
    public void StartAnimation()
    {
        var pool = _moneyCombo < 0 ? _pool.PoolMoneyMinus : _pool.PoolMoneyPlus;
        StartCoroutine(Animation(SpawnMoney(_moneyCombo, pool), pool));
    }

    public TMP_Text SpawnMoney(int combo, Pool<TMP_Text> pool)
    {
        var prefab = pool.Get(_startAnimation.position, transform);
        prefab.text = "$ " + Mathf.Abs(combo);
        return prefab;
    }

    private void OnEnable()
    {
        MoneyCounter.ComboChanged += ChangeCombo;
    }

    private void OnDisable()
    {
        MoneyCounter.ComboChanged -= ChangeCombo;
    }

    private IEnumerator Animation(TMP_Text money, Pool<TMP_Text> pool)
    {
        var timeToCheckFade = new WaitForSeconds(_timeToCheckFade);
        var color = money.color;

        money.transform.DOMoveX(_endAnimation.position.x, _timeToFade);
        var fadeAnimation = money.DOFade(0, _timeToFade).SetDelay(_timeToFade);

        while (fadeAnimation.IsActive())
        {
            yield return timeToCheckFade;
        }

        money.color = color;
        pool.Return(money);
    }

    private void ChangeCombo(int combo)
    {
        _moneyCombo = combo;
    }
}
