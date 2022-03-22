using System.Collections.Generic;

internal class CaseEngine
{
    private readonly List<Item> _caseObjects = new List<Item>();
    private readonly List<ItemMover> _objectMoves = new List<ItemMover>();

    public void Add(Item caseObject)
    {
        _caseObjects.Add(caseObject);

        if (_caseObjects.Count > 1)
        {
            _objectMoves.Add(new ItemMover(_caseObjects[_caseObjects.Count - 2], _caseObjects[_caseObjects.Count - 1]));
        }
    }

    public void Remove(int number)
    {
        _caseObjects.RemoveAt(number);
        if (number == 0)
        {
            if (_objectMoves.Count != 0)
                _objectMoves.RemoveAt(number);

            if (_caseObjects.Count > 1)
                _objectMoves.Insert(number, new ItemMover(_caseObjects[number], _caseObjects[number + 1]));
        }
        else if (number == _caseObjects.Count - 1)
        {
            _objectMoves.RemoveAt(number - 1);
        }
        else
        {
            _objectMoves.RemoveRange(number - 1, 2);
            _objectMoves.Insert(number - 1, new ItemMover(_caseObjects[number - 1], _caseObjects[number]));
        }
    }

    public void Update()
    {
        foreach (var objectMove in _objectMoves)
        {
            objectMove.Move();
        }
    }
}
