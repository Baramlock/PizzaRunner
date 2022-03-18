using System;
using UnityEngine;
using UnityEngine.Events;

public class MoneyCounter : MonoBehaviour
{
    [SerializeField] private BalanceDisplay _balanceDisplay;
    [SerializeField] private float _timeToCombo = 1.5f;
    [SerializeField] private CashAnimator _cashAnimator;

    private int _money;
    private int _moneyCombo;
    private float _timeFromPreviousCombo;

    public static event UnityAction<int> ComboChanged;
    public void Addmoney(IMoneyGiveable money)
    {
        _money += money.GiveMoney();
        _balanceDisplay.ToText(_money);

        if (_money < 0)
        {
            throw new ArgumentOutOfRangeException(_money.ToString());
        }

        if (money.GetType() != typeof(SellPizzaAction))
            UpdateCombo(money);
        else
            _cashAnimator.StartAnimation();
    }

    private void OnEnable()
    {
        TouchTrigger.MoneyChanged += Addmoney;
    }

    private void OnDisable()
    {
        TouchTrigger.MoneyChanged -= Addmoney;
    }

    private void UpdateCombo(IMoneyGiveable money)
    {
        _moneyCombo += money.GiveMoney();
        ComboChanged?.Invoke(_moneyCombo);

        _timeFromPreviousCombo = 0;
    }

    private void Update()
    {
        _timeFromPreviousCombo += Time.deltaTime;
        if (_timeFromPreviousCombo >= _timeToCombo)
        {
            _moneyCombo = 0;
            ComboChanged?.Invoke(_moneyCombo);
        }
    }
}
