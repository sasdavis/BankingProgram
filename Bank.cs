
//List<data type> name of list = new List <data type again>() 
using System.Transactions;

public class Bank
{
    //List that can store accounts
    private List<Account> _accounts = new List<Account>();

    //List that can store transactions
    private List<Transaction> _transactions = new List<Transaction>();
    public void AddAccount(Account account)
    {
        _accounts.Add(account);
    }

    public Account GetAccount(string name)
    {
        foreach (Account account in _accounts)
        {
            if (account.Name == name)
            {
                return account;
            }
        }
        return null;
    }

    public void ExecuteTransaction(Transaction transaction)
    {
        //performs withdraw, deposit, transfer
        transaction.Execute();
        //adds it the transaction list
        AddTransaction(transaction);
    }

    //add the transaction to _transaction and store it there 
    public void AddTransaction(Transaction transaction)
    {
        _transactions.Add(transaction);
    }
  
    public void PrintTransactionHistory()
    {
        //for each Transaction, if the transaction is a success then print
        foreach (Transaction transaction in _transactions)
        {
                transaction.Print();
        }
    }
}


