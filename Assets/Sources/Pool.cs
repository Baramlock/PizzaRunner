using System.Collections.Generic;
using UnityEngine;

public class Pool<T>
    where T : MonoBehaviour
{
    private readonly Stack<T> _prefabsPool = new Stack<T>();
    private readonly T _prefab;

    public Pool(T prefab)
    {
        _prefab = prefab;
    }

    public void CreateItems(int count)
    {
        for (int i = 0; i < count; i++)
        {
            Return(Object.Instantiate(_prefab, Vector3.zero, Quaternion.identity));
        }
    }

    public void Return(T prefab)
    {
        prefab.gameObject.SetActive(false);
        _prefabsPool.Push(prefab);
    }

    public void Return(IEnumerable<T> prefabs)
    {
        foreach (var prefab in prefabs)
        {
            prefab.gameObject.SetActive(false);
            _prefabsPool.Push(prefab);
        }
    }

    public T Get(Vector3 startPosition, Transform parent)
    {
        if (_prefabsPool.Count == 0)
        {
            return Object.Instantiate(_prefab, startPosition, Quaternion.identity, parent);
        }

        var prefab = _prefabsPool.Pop();
        prefab.transform.position = startPosition;
        prefab.transform.SetParent(parent);
        prefab.gameObject.SetActive(true);
        return prefab;
    }
}