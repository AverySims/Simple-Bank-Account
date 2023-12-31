﻿namespace BankAccount;

public class BankAccount
{
	#region Constructors
	public BankAccount()
	{
	}

	public BankAccount(int accountNumber, User owner)
	{
		AccountNumber = accountNumber;
		Owner = owner;
	}

	public BankAccount(int accountNumber, User? owner, double balance)
	{
		AccountNumber = accountNumber;
		Owner = owner;
		Balance = balance;
	}
	#endregion

	public int AccountNumber { get; private set; }
	public User? Owner { get; private set; }
	public double Balance { get; private set; }

	public List<string> History { get; private set; } = new List<string>();

	/// <summary>
	/// Deposits the specified amount to the specified account.
	/// </summary>
	/// <param name="addition">The amount to add to the account</param>
	/// <param name="account">The account to add the amount</param>
	/// <returns></returns>
	public static bool DepositToAccount(double addition, BankAccount account)
	{
		// cannot add 0 or less to the balance
		if (!(addition > 0)) return false;

		account.Balance += addition;
		account.History.Add($"+{addition}");
		return true;
	}

	/// <summary>
	/// Withdraws the specified amount from the specified account.
	/// </summary>
	/// <param name="subtraction">The amount to remove from the account</param>
	/// <param name="account">The account to remove the amount from</param>
	/// <returns></returns>
	public static bool WithdrawFromAccount(double subtraction, BankAccount account)
	{
		// cannot subtract 0 or less from the balance
		// cannot subtract more than what is in the account's balance
		if (!(subtraction > 0) || subtraction > account.Balance) return false;
		
		account.Balance -= subtraction;
		account.History.Add($"-{subtraction}");
		return true;
	}

	/// <summary>
	/// Prints the transaction history of the specified account.
	/// </summary>
	/// <param name="history">The specified bank account's history</param>
	/// <param name="max">The amount of entries to print</param>
	public static void PrintTransactionHistory(List<string> history, int max = 0)
	{
		// reversing the list so we can print last -> first
		List<string> reversedHistory = history;
		reversedHistory.Reverse();
		
		// if max is 0, print all transactions
		if (max == 0)
		{
			foreach (var transaction in reversedHistory)
			{
				Console.WriteLine(ConvertDollarAmount(transaction));
			}
		}
		
		// if max is greater than 0, limit the number of transactions printed
		if (max > 0)
		{
			// if max is greater than the number of transactions, print all transactions
			int loopCount = Math.Min(max, reversedHistory.Count);
			
			for (int i = 0; i < loopCount; i++)
			{
				Console.WriteLine(ConvertDollarAmount(reversedHistory[i]));
			}
		}
	}
	
	public static string ConvertDollarAmount(double amount)
	{
		return $"${amount}";
	}
	
	public static string ConvertDollarAmount(string amount)
	{
		return $"${amount}";
	}
}