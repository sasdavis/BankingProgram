using System;
using System.Collections;
using System.Configuration.Assemblies;
using System.Data;
using SplashKitSDK;

public class Program
{
    public enum MenuOptions
    {
        Withdraw = 0,
        Deposit = 1,
        Print = 2,
        Transfer = 3,
        AddAccount = 4,
        TransactionHistory = 5,
        Quit = 6,

    }

    public static MenuOptions ReadUserOption()
    {
        int option;

        do
        {
            Console.WriteLine("Choose an option");
            Console.WriteLine("1.Withdraw");
            Console.WriteLine("2.Deposit");
            Console.WriteLine("3.Print");
            Console.WriteLine("4.Transfer");
            Console.WriteLine("5.Add a new Account");
            Console.WriteLine("6.Check transaction history");
            Console.WriteLine("7.Quit");
            option = Convert.ToInt32(Console.ReadLine());

        //keep doing it if the user enters a number less then 1 or bigger then 7
        } while (option < 1 || option > 7);

        return (MenuOptions)(option - 1);
    }

    public static void Main()
    {
        Account account = new Account("Sas", 10000);

        //Name of class - Bank class, unique name of object - bank1
        Bank bank = new Bank();

        MenuOptions option;
        do
        {
            option = ReadUserOption();
            switch (option)
            {
                case MenuOptions.Withdraw:
                    DoWithdraw(bank);
                    break;

                case MenuOptions.Deposit:
                    DoDeposit(bank);
                    break;

                case MenuOptions.Print:
                    DoPrint(account);
                    break;

                case MenuOptions.Transfer:
                    DoTransfer(bank);
                    break;

                case MenuOptions.AddAccount:
                    DoAddAccount(bank);
                    break;

                case MenuOptions.TransactionHistory:
                    DoPrintTransactionHistory(bank);
                    break;

                case MenuOptions.Quit:
                    Console.WriteLine("You choose to quit.");
                    break;

            }
        } while (option != MenuOptions.Quit);


    }
    private static void DoWithdraw(Bank bank)
    {
        Account toAccount = FindAccount(bank);
        if (toAccount == null) return;
        Console.WriteLine("You choose to withdraw.");
        Console.WriteLine("Enter the amount to withdraw:");
        decimal amountToRemove = Convert.ToDecimal(Console.ReadLine());

        WithdrawTransaction transaction = new WithdrawTransaction(toAccount, amountToRemove);

        //this calls on the bank object instead of transaction.Execute() which was calling on the Transaction
        bank.ExecuteTransaction(transaction);
        transaction.Print();

    }

    private static void DoDeposit(Bank bank)
    {
        Account toAccount = FindAccount(bank);
        if (toAccount == null) return;
        Console.WriteLine("You chose to Deposit.");
        Console.WriteLine("Enter the amount to deposit:");
        decimal amountToDeposit = Convert.ToDecimal(Console.ReadLine());

        DepositTransaction transaction = new DepositTransaction(toAccount, amountToDeposit);

        bank.ExecuteTransaction(transaction);
        transaction.Print();
    }

    private static void DoPrint(Account account)
    {
        Console.WriteLine("You chose to Print.");
        account.Print();
    }

    private static void DoTransfer(Bank bank)
    {
        Account toAccount = FindAccount(bank);
        if (toAccount == null) return;
        Account fromAccount = FindAccount(bank);
        if (fromAccount == null) return;
        
        Console.WriteLine("Enter the amount you would like to transfer:");
        //saves the number into the variable called amountToTransfer
        decimal amountToTransfer = Convert.ToDecimal(Console.ReadLine());

        TransferTransaction transfer = new TransferTransaction(fromAccount, toAccount, amountToTransfer);

        bank.ExecuteTransaction(transfer);
        transfer.Print();

    }

    private static void DoAddAccount(Bank bank)
    {
        Console.WriteLine("What is the name for the new account: ");
        string accountName = Console.ReadLine();
        Console.WriteLine("What is your starting balance: ");
        decimal startingBalance = Convert.ToDecimal(Console.ReadLine());
        Account newAccount = new Account(accountName, startingBalance);
        bank.AddAccount(newAccount);

    }

    private static Account FindAccount(Bank fromBank)
    {
        Console.Write("Enter account name: ");
        String name = Console.ReadLine();
        Account result = fromBank.GetAccount(name);

        if (result == null)
        {
            Console.WriteLine($"No account found with name {name}");
        }
        return result;
    }

    private static void DoPrintTransactionHistory(Bank bank)
    {
        Console.Write("This is your transaction history");
        Console.WriteLine();
        bank.PrintTransactionHistory();
        Console.WriteLine();
        
    }
        
}

