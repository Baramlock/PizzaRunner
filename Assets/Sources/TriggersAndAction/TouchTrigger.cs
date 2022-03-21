using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TouchTrigger : MonoBehaviour
{
    [SerializeField] private List<TriggerAction> _triggerActions = new List<TriggerAction>();
    [SerializeField] private bool _inTrigger = false;
    [SerializeField] private int _moneyToBread = 1;

    private BreadAction _breadAction;

    public static event UnityAction<IMoneyGiveable> MoneyChanged;
    public static event UnityAction BreadTouched;

    private void Start()
    {
        _breadAction = new BreadAction(_moneyToBread);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Trigger trigger))
        {
            if (trigger.GetType() == typeof(BreadTrigger))
            {
                var bread = (BreadTrigger)trigger;
                if (bread.Touch == false)
                {
                    bread.Touch = true;
                    trigger.gameObject.SetActive(false);
                    Destroy(trigger.gameObject);
                    BreadTouched.Invoke();
                    MoneyChanged?.Invoke(_breadAction);
                    trigger.StartMoneyAnimation();
                }
            }
            else if (_inTrigger == false)
            {
                foreach (var triggerAction in _triggerActions)
                {
                    if (triggerAction.Trigger.GetType() == trigger.GetType())
                    {
                        triggerAction.Action.PerfomingAction();
                        MoneyChanged?.Invoke(triggerAction.Action);
                        trigger.StartMoneyAnimation();
                    }
                }

                _inTrigger = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out Trigger _))
        {
            _inTrigger = false;
        }
    }
}
