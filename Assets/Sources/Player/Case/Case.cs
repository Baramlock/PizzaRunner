using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CaseAnimation))]
public class Case : MonoBehaviour
{
    private readonly List<Item> _caseItems = new List<Item>();

    [SerializeField] private PizzaStartPrefab _prefabs;
    [SerializeField] private Transform _center;
    [SerializeField] private Transform _plane;

    private CaseAnimation _animator;
    private CaseEngine _engine;
    private Pool<PizzaStartPrefab> _pool;

    private void Start()
    {
        _pool = new Pool<PizzaStartPrefab>(_prefabs);
        _pool.CreateItems(10);
        _animator = GetComponent<CaseAnimation>();
        _engine = new CaseEngine();
        AddPizza();

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
        var pizza = _pool.Get(startPosition, transform);
        _caseItems.Add(new Item(pizza.transform));
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