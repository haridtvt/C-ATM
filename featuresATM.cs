using System.Diagnostics.Contracts;

class feature_ATM
{
    public void checkinfo(string username, string nation, string balance)
    {
        Console.WriteLine(username);
        Console.WriteLine(nation);
        Console.WriteLine(balance);
    }
    public float withdraw(float balance, float money)
    {
        balance = balance = money;
        return balance;
    }
    public float tranfer(float balance_user1, float money_be_recive)
    {
        balance_user1 = balance_user1 + money_be_recive;
        return balance_user1;
    }
    public float update_money(float balance, float money_to_tranfet)
    {
        balance = balance - money_to_tranfet;
        return balance;
    }
    public bool check_money(float money, float balance)
    {
        if (money > balance) {return false;}
        return true;
    }
}