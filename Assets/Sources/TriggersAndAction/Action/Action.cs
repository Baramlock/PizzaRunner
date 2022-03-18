using UnityEngine;
using UnityEngine.Events;

public abstract class Action : MonoBehaviour, IMoneyGiveable
{
    public virtual void PerfomingAction()
    {
    }

    public virtual int GiveMoney()
    {
        return 0;
    }
}