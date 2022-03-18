using TMPro;
using UnityEngine;

internal class MoneyPool : MonoBehaviour
{
    [SerializeField] private TMP_Text _moneyPlus;
    [SerializeField] private TMP_Text _moneyMinus;

    public Pool<TMP_Text> PoolMoneyPlus { get; private set; }
    public Pool<TMP_Text> PoolMoneyMinus { get; private set; }

    private void Start()
    {
        PoolMoneyPlus = new Pool<TMP_Text>(_moneyPlus);
        PoolMoneyMinus = new Pool<TMP_Text>(_moneyMinus);
    }
}
