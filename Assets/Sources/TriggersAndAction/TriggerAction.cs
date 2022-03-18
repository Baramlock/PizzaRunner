using UnityEngine;

[System.Serializable]
public class TriggerAction
{
    [SerializeField] private Trigger _trigger;
    [SerializeField] private Action _action;

    public Trigger Trigger => _trigger;
    public Action Action => _action;
}
