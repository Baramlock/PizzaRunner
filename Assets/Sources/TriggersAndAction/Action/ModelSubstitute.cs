using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;

public class ModelSubstitute : Action
{
    [SerializeField] private Transform _nextModel;
    [SerializeField] private bool _isAnimation = false;
    [SerializeField] private int _changeMoney = 1;

    [SerializeField] private float _startScale = 1;
    [SerializeField] private float _animationScale = 1.6f;
    [SerializeField] private float _timeAnimationl = 0.15f;

    public static event UnityAction ModelChanged;

    public override void PerfomingAction()
    {
        var position = new Vector3(transform.position.x, transform.position.y + _nextModel.transform.position.y, transform.position.z);
        Instantiate(_nextModel, position, Quaternion.identity, transform.parent);

        ModelChanged?.Invoke();

        if (_isAnimation)
            Animation();

        Destroy(this.gameObject);
    }

    public override int GiveMoney()
    {
        return _changeMoney;
    }

    private void Animation()
    {
        transform.parent.DOScale(_animationScale, _timeAnimationl);
        transform.parent.DOScale(_startScale, _timeAnimationl).SetDelay(_timeAnimationl);
    }
}
