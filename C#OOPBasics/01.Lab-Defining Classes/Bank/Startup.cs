using System;
using System.Collections.Generic;
using System.Linq;

public class Startup
{
    static void Main(string[] args)
    {
        //var input = Console.ReadLine();
        //Dictionary<int, BankAccount> clients = new Dictionary<int, BankAccount>();

        //while (input != "End")
        //{
        //    var command = input.Split(' ').ToArray();

        //    switch (command[0])
        //    {
        //        case "Create":
        //            if (clients.ContainsKey(int.Parse(command[1])))
        //            {
        //                Console.WriteLine("Account already exists");
        //            }
        //            else
        //            {
        //                Create(int.Parse(command[1]), clients);
        //            }
        //            break;
        //        case "Deposit":
        //            if (!clients.ContainsKey(int.Parse(command[1])))
        //            {
        //                Console.WriteLine("Account does not exist");
        //            }
        //            else
        //            {
        //                Deposit(int.Parse(command[1]), double.Parse(command[2]), clients);
        //            }
        //            break;
        //        case "Withdraw":
        //            if (!clients.ContainsKey(int.Parse(command[1])))
        //            {
        //                Console.WriteLine("Account does not exist");
        //            }
        //            else
        //            {
        //                Withdraw(int.Parse(command[1]), double.Parse(command[2]), clients);
        //            }
        //            break;
        //        case "Print":
        //            if (!clients.ContainsKey(int.Parse(command[1])))
        //            {
        //                Console.WriteLine("Account does not exist");
        //            }
        //            else
        //            {
        //                Print(int.Parse(command[1]), clients);
        //            }
        //            break;
        //    }

        //    input = Console.ReadLine();
        //}
        
    }

    private static void Print(int id, Dictionary<int, BankAccount> clients)
    {
        Console.WriteLine(clients[id].ToString());
    }

    private static void Withdraw(int id, double amount, Dictionary<int, BankAccount> clients)
    {
        if (amount > clients[id].Balance)
        {
            Console.WriteLine("Insufficient balance");
        }
        else
        {
            clients[id].Withdraw(amount);
        }
    }

    private static void Deposit(int id, double amount, Dictionary<int, BankAccount> clients)
    {
        clients[id].Deposit(amount);
    }

    private static void Create(int id, Dictionary<int, BankAccount> clients)
    {
        clients.Add(id, new BankAccount(id, 0));
    }
}

