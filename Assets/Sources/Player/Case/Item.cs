using UnityEngine;

internal class Item
{
    private readonly Transform _transform;

    private float _radius;
    public Item(Transform transform)
    {
        _transform = transform;
        UpdateRadius();
    }

    public Vector3 Position
    {
        get => _transform.position;
        set => _transform.position = value;
    }

    public float Radius => _radius;

    public void UpdateRadius()
    {
        var i = 0;
        if (_transform.childCount > 1)
            i = 1;
        _radius = _transform.GetChild(i).GetComponent<SphereCollider>().radius * _transform.GetChild(i).localScale.x;
    }
}
