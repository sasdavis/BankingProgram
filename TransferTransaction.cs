public class TransferTransaction : Transaction
{
    //account money is going to
    private Account _toAccount;
    //account money is coming from
    private Account _fromAccount;
    //the amount of money being transferred
    //private decimal _amount;

    //deposit
    private DepositTransaction _theDeposit;
    //withdrawal
    private WithdrawTransaction _theWithdraw;
    //whether the transfer is executed
    //private bool _executed;
    //whether the transfer is successfu;
    private bool _success;
    //whether the transfer is reversed
    //private bool _reversed;

    public TransferTransaction(Account fromAccount, Account toAccount, decimal amount) : base(amount)
    {
        _fromAccount = fromAccount;
        _toAccount = toAccount;
       
        _theWithdraw = new WithdrawTransaction(_fromAccount, _amount);
        _theDeposit = new DepositTransaction(_toAccount, _amount);

        //_executed = false;
        _success = false;
       //_reversed = false;
    }

    public override bool Success
    {
        get
        {
            return _success;
        }
    }

    public override void Execute()
    {
        base.Execute();

        _theWithdraw.Execute();

        if (_theWithdraw.Success)
        {
            _theDeposit.Execute();

            if (_theDeposit.Success)
            {
                _success = true;

            }
            else
            {
               _theWithdraw.Rollback(); 
            }

        }
        
    }

    public override void Rollback()
    {
        if (!Success)
        {
        throw new Exception("Cannot rollback a transfer that was unsuccessful");
        }

        base.Rollback();

        if (_theDeposit.Success)
        {
            _theDeposit.Rollback();
            
        }
        if (_theWithdraw.Success)
        {
            _theWithdraw.Rollback();
        }
        _success = false;
    }

    public override void Print()
    {
        if (_success)
        {
            Console.WriteLine("Transaction was successful. You have transferred $" + _amount + " from " + _fromAccount.Name + " to " + _toAccount.Name);
        }
        else
        {
            Console.WriteLine("Transaction failed.");
        }

        //withdraw transaction print method
            Console.Write("    ");
        _theWithdraw.Print();
        //deposit transaction print method
        Console.Write("    ");
        _theDeposit.Print();

        
        
    }
}