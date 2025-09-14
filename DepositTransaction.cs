public class DepositTransaction: Transaction
{
    private Account _account;

    private bool _success = false;
    
    public override bool Success
    {
        get
        {
            return _success;
        }
    }

    public DepositTransaction(Account account, decimal amount) : base(amount)
    {
        _account = account;
    }

    public override void Execute()
    {
        base.Execute();
        _success = _account.Deposit(_amount);

    }

    public override void Rollback()
    {
        //if it is not successful
        if (!_success)
        {
            throw new Exception("Cannot rollback a deposit that was unsuccessful");
        }
        //otherwise do rollback - executed/reversed
        base.Rollback();

        _success = false;

    }
    public override void Print()
    {
        if (_success)
        {
            Console.WriteLine("Transaction was successful. You have deposited $" + _amount);
        }
        else
        {
            Console.WriteLine("Transaction was unsuccessful. You deposit of $" + _amount + "failed");
        }
        if (Reversed)
        {
            Console.WriteLine("Transaction was reversed");
        }

    }

}

