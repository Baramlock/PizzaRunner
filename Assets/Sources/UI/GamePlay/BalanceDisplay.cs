using TMPro;
using UnityEngine;

public class BalanceDisplay : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;

    public void ToText(int money)
    {
        _text.text = "$ " + money;
    }
}
