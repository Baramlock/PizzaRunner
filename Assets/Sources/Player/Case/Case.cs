using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CaseAnimation))]
public class Case : MonoBehaviour
{
    private readonly List<Item> _caseItems = new List<Item>();

    [SerializeField] private Transform _prefabs;
    [SerializeField] private Transform _center;
    [SerializeField] private Transform _plane;

    private CaseAnimation _animator;
    private ÑaseEngine _engine;

    private void Start()
    {
        _animator = GetComponent<CaseAnimation>();
        _engine = new ÑaseEngine();
    }

    private void FixedUpdate()
    {
        _engine.Update();
    }

    private void OnEnable()
    {
        TouchTrigger.BreadTouched += AddPizza;
        TouchTrigger.BreadTouched += StartAnimation;
        ModelSubstitute.ModelChanged += UpdateRadius;
        SellPizzaAction.PizzaSelled += RemovePizza;
    }

    private void OnDisable()
    {
        TouchTrigger.BreadTouched -= AddPizza;
        TouchTrigger.BreadTouched -= StartAnimation;
        ModelSubstitute.ModelChanged -= UpdateRadius;
        SellPizzaAction.PizzaSelled -= RemovePizza;
    }

    private void StartAnimation()
    {
        _animator.StartAnimationCorutinne(_caseItems);
    }

    private void UpdateRadius()
    {
        for (int i = 0; i < _caseItems.Count; i++)
        {
            _caseItems[i].UpdateRadius();
        }
    }

    private void AddPizza()
    {
        Vector3 startPosition;
        if (_caseItems.Count == 0)
            startPosition = _center.position;
        else
            startPosition = _caseItems[_caseItems.Count - 1].Transform.position;

        var pizza = Instantiate(_prefabs, startPosition, Quaternion.identity, transform);
        _caseItems.Add(new Item(pizza));
        _engine.Add(_caseItems[_caseItems.Count - 1]);
    }

    private void RemovePizza(Transform transform)
    {
        if (_caseItems == null)
        {
            return;
        }

        for (int i = 0; i < _caseItems.Count; i++)
        {
            if (_caseItems[i].Transform == transform)
            {
                _caseItems[i].Transform.parent = _plane;
                _caseItems.RemoveAt(i);
                _engine.Remove(i);
            }
        }

        if (_caseItems.Count != 0)
        {
            _caseItems[0].Transform.position = _center.position;
        }
    }
}