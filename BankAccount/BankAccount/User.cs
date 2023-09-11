namespace BankAccount;

public class User
{
    public BankAccount? Account { get; private set; }
    
    public void InitializeAccount(BankAccount account)
    {
        Account = account;
    }
    
}