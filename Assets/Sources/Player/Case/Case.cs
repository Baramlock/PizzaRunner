using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CaseAnimation))]
public class Case : MonoBehaviour
{
    private readonly List<Transform> _transformList = new List<Transform>();
    private readonly List<Item> _caseObjects = new List<Item>();

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
        TouchTrigger.Bread += AddPizza;
        TouchTrigger.Bread += StartAnimation;
        ModelSubstitute.ModelChanged += UpdateRadius;
        SellPizzaAction.RemovePizza += RemovePizza;
    }

    private void OnDisable()
    {
        TouchTrigger.Bread -= AddPizza;
        TouchTrigger.Bread -= StartAnimation;
        ModelSubstitute.ModelChanged -= UpdateRadius;
        SellPizzaAction.RemovePizza -= RemovePizza;
    }

    private void StartAnimation()
    {
        _animator.StartAnimationCorutinne(_transformList);
    }

    private void UpdateRadius()
    {
        for (int i = 0; i < _caseObjects.Count; i++)
        {
            _caseObjects[i].UpdateRadius();
        }
    }

    private void AddPizza()
    {
        Vector3 startPosition;
        if (_transformList.Count == 0)
            startPosition = _center.position;
        else
            startPosition = _transformList[_transformList.Count - 1].position;

        var pizza = Instantiate(_prefabs, startPosition, Quaternion.identity, transform);
        _transformList.Add(pizza);
        var item = new Item(pizza);
        _caseObjects.Add(item);
        _engine.Add(_caseObjects[_caseObjects.Count - 1]);
    }

    private void RemovePizza(Transform transform)
    {
        if (_transformList == null)
        {
            return;
        }

        for (int i = 0; i < _transformList.Count; i++)
        {
            if (_transformList[i] == transform)
            {
                _transformList[i].parent = _plane;
                _transformList.RemoveAt(i);
                _engine.Remove(i);
                _caseObjects.RemoveAt(i);
            }
        }

        if (_transformList.Count != 0)
        {
            _transformList[0].position = _center.position;
        }
    }
}