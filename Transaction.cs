
public abstract class Transaction
{
    //protected means the class and child classes can access
    protected decimal _amount;
    private bool _executed;
    private bool _reversed;
    private DateTime _dateStamp;


    public Transaction(decimal amount)
    {
        _amount = amount;
    }

    public bool Executed
    {
        get { return _executed; } //read whatever value is within _exectued
    }

    public bool Reversed
    {
        get { return _reversed; }
    }

    public DateTime DateStamp
    {
        get { return _dateStamp; }
    }

    public abstract bool Success
    {
        get;
    }

    public abstract void Print();
    
    public virtual void Execute()
    {

        if (_executed)
        {
            throw new Exception("Cannot execute as the transaction has already been executed");
        }
        _executed = true;
        _dateStamp = DateTime.Now;
    }

    public virtual void Rollback()
    {
        //! is NOT - so if _executed is false - or if transaction has not been executed
        if (!_executed)
        {
            throw new Exception("Cannot rollback a transaction that hasn't been executed");
        }

        if (_reversed)
        {
            throw new Exception("Transaction has already been reversed");
        }
            //to make sure you dont roll back again
            _reversed = true;
            _dateStamp = DateTime.Now;
    }


}



