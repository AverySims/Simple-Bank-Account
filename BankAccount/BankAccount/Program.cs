using CustomConsole;

namespace BankAccount
{
	internal class Program
	{
		static async Task Main(string[] args)
		{
			Random random = new Random();
			User user = new User();
			
			user.InitializeAccount(new BankAccount(1234, user, 100000));

			// while the user's account has less than 1000 transactions
			while (user.Account is { History.Count: < 1000 })
			{
				// 50% chance to deposit, 50% chance to withdraw
				if (random.Next(0, 10) > 5)
				{
					// deposit between 5 and 500
					if (!BankAccount.DepositToAccount(random.Next(1, 500), user.Account))
					{
						// if the deposit fails, break out of the loop
						break;
					}
				}
				else
				{
					// withdraw between 1 and 10000
					if (!BankAccount.WithdrawFromAccount(random.Next(1, 10000), user.Account))
					{
						// if the withdrawal fails, break out of the loop
						break;
					}
				}
				
				// wait for the next iteration
				await Task.Yield();
			}
			
			Console.Clear();
			// print the user's transaction history
			BankAccount.PrintTransactionHistory(user.Account.History);
			
			// wait for the user to press a key to close the program
			ConsoleHelper.HaltProgram();
		}
	}
}