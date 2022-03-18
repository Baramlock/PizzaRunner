using UnityEngine;

public abstract class Trigger : MonoBehaviour
{
    [SerializeField] private MoneyAnimation _moneyAnimation;

    public void StartMoneyAnimation()
    {
        if (_moneyAnimation == null)
        {
            return;
        }

        _moneyAnimation.StartAnimation();
    }
}
