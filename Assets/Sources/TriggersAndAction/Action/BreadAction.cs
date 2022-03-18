internal class BreadAction : IMoneyGiveable
{
    private readonly int _moneyToBread;

    public BreadAction(int moneyToBread)
    {
        _moneyToBread = moneyToBread;
    }

    public int GiveMoney()
    {
        return _moneyToBread;
    }
}
