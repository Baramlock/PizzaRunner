using UnityEngine;

public abstract class Trigger : MonoBehaviour
{
    [SerializeField] private MoneyAnimation moneyAnimation;

    public void StartMoneyAnimation()
    {
        if (moneyAnimation == null)
        {
            return;
        }

        moneyAnimation.StartAnimation();
    }
}
