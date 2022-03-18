using System.Collections.Generic;
using UnityEngine;

internal class ItemMover
{
    private readonly List<Vector3> _positions = new List<Vector3>();
    public ItemMover(Item target, Item stalker)
    {
        CaseObject1 = target;
        CaseObject2 = stalker;
        _positions.Add(target.Position);
        _positions.Add(stalker.Position);
    }

    private Item CaseObject1 { get; }
    private Item CaseObject2 { get; }

    public void Move()
    {
        float requiredDistance = CaseObject1.Radius + CaseObject2.Radius;
        float currentDistance = (CaseObject1.Position - _positions[0]).magnitude;
        if (currentDistance > requiredDistance)
        {
            Vector3 direction = (CaseObject1.Position - _positions[0]) / currentDistance;

            _positions.Insert(0, _positions[0] + (direction * requiredDistance));
            _positions.RemoveAt(_positions.Count - 1);

            currentDistance -= requiredDistance;
        }

        CaseObject2.Position = Vector3.Lerp(_positions[1], _positions[0], currentDistance / requiredDistance);
    }
}