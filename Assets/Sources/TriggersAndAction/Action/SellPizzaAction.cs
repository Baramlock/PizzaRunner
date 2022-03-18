using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;

public class SellPizzaAction : Action
{
    [SerializeField] private int _changeMoney = -6;

    public static event UnityAction<Transform> PizzaSelled;

    public override void PerfomingAction()
    {
        PizzaSelled?.Invoke(transform.parent);
        transform.DOMoveX(100, 5);
    }

    public override int GiveMoney()
    {
        return _changeMoney;
    }
}
