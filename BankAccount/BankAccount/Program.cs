namespace BankAccount
{
	internal class Program
	{
		static async Task Main(string[] args)
		{
			Random random = new Random();
			User user = new User();
			user.InitializeAccount(new BankAccount(1234, user, 100000));

			while (user.Account.History.Count < 1000)
			{
				if (!BankAccount.WithdrawFromAccount(random.Next(10, 100), user.Account))
				{
					break;
				}
				await Task.Yield();
			}
			
			Console.Clear();
			BankAccount.PrintTransactionHistory(user.Account.History);
		}
	}
}