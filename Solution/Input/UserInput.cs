namespace SectraCalculator;

public class UserInput
{

  public void UserInputLogic(Calculator calc)
  {
    Messages.Prompt();
    List<Transaction> transactions = new();
    TransactionCrafter tr = new();
    string[]? cmd;
    var message = "Available operations are: Add, Subtract & Multiply \nRetry please.";
    while ((cmd = Console.ReadLine()?.ToLower().Split(" ")) != null)
    {
      if(cmd[0] == "")
      {
        Messages.PressSomething();
        Thread.Sleep(1000);
        Messages.ContinousPrompt();
        continue;
      }
      if (cmd[0] == "quit")
      {
        Messages.AppEnd();
        Thread.Sleep(1000);
        Environment.Exit(0);
      }
      if (cmd[0] == "print")
      {
        Messages.CurrentValue(cmd[1], Printer.Print(transactions, cmd[1], calc));
        Messages.ContinousPrompt();
        continue;
      }
      Messages.ContinousPrompt();
      transactions.Add(tr.GetTransaction(cmd, message, transactions, calc));
      continue;
    }
  }
}

