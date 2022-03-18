using TMPro;
using UnityEngine;

public class BalanceDisplay : MonoBehaviour
{
    [SerializeField] private TMP_Text text;

    public void ToText(int money)
    {
        text.text = "$ " + money;
    }
}
