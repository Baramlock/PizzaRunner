using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;

public class ModelSubstitute : Action
{
    [SerializeField] private Transform _nextModel;
    [SerializeField] private bool _isAnimation = false;
    [SerializeField] private int _changeMoney = 1;

    private float _startScale;
    private float _animationScale;
    private float _timeAnimationl;

    public static event UnityAction ModelChanged;

    public override void PerfomingAction()
    {
        var position = new Vector3(transform.position.x, transform.position.y + _nextModel.transform.position.y, transform.position.z);
        Instantiate(_nextModel, position, Quaternion.identity, transform.parent);

        ModelChanged?.Invoke();

        if (_isAnimation)
        {
            transform.parent.DOScale(_animationScale, _timeAnimationl);
            transform.parent.DOScale(_startScale, _timeAnimationl).SetDelay(_timeAnimationl);
        }

        Destroy(this.gameObject);
    }

    public override int GiveMoney()
    {
        return _changeMoney;
    }

    private void Start()
    {
        _startScale = 1;
        _animationScale = 1.3f;
        _timeAnimationl = 0.2f;
    }
}
