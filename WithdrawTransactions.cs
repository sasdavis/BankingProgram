public class WithdrawTransaction: Transaction 
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
   
    public WithdrawTransaction(Account account, decimal amount) :base(amount)
    {
        _account = account;
    }

    public override void Execute()
    {
        base.Execute();
        _success = _account.Withdraw(_amount);

    }
    
    public override void Rollback()
    {
        if (!_success)
        {
            throw new Exception("Cannot rollback a deposit that was unsuccessful");
        }
        base.Rollback();

        //after a rollback, the withdraw is not successful so its false
        _success = false;
        
    }

    public override void Print()
    {
        
        if (_success)
        {
            Console.WriteLine("Transaction was successful. You withdrew $" + _amount);
        }
        else
        {
            Console.WriteLine("Transaction was unsuccessful. Your withdrawal of $" + _amount + " failed");
        }

        if (Reversed)
        {
            Console.WriteLine("Transaction was reversed.");
        }
    }

}