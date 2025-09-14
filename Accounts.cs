using System;
using SplashKitSDK;

//Class
public class Account
{
    private decimal _balance;
    private string _name;

    //Constructor - used when we create an Account object to initialise the name and balance
    public Account(string name, decimal startingBalance)
    {
        _name = name;
        _balance = startingBalance;
    }
    //Returning boolean value (public bool)
    public bool Deposit(decimal amountToDeposit)
    {
        if (amountToDeposit > 0)
        {
            _balance = _balance + amountToDeposit;
            return true;
        }
        return false;
    }

    //Public (is the access modifier - method can be accessed from anywhere), void (return type - void means the method does not return any value)
    public bool Withdraw(decimal amountToRemove)
    {
        if (amountToRemove <= _balance)
        {
            _balance = _balance - amountToRemove;
            return true;
        }
        return false;
    }

    public string Name
    {
        get { return _name; }
    }

    public void Print()
    {
        Console.WriteLine("Hi " + _name + ", Your account balance is $" + _balance);
    }
}
