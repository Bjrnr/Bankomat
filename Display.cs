using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bankomat
{
    internal class Display
    {
        private Person PersonAccounts;

        public Display(Person person)
        {
            PersonAccounts = person;
        }

        public void MainMenu()
        {
            bool loop = true;
            while (loop)
            {
                PrintMainMenu();
                switch (Console.ReadKey(intercept: true).Key)
                {
                    case ConsoleKey.D1:
                        AccountMenu();
                        break;
                    case ConsoleKey.D2:
                        Console.WriteLine("2");
                        break;
                    case ConsoleKey.D3:
                        Console.WriteLine("3");
                        break;
                    case ConsoleKey.D4:
                        break;
                    case ConsoleKey.D5:
                        Console.WriteLine($"Hej då!\n{PersonAccounts.FirstName} {PersonAccounts.LastName}");
                        return;
                    default:
                        Console.Error.WriteLine("\nOgiltigt val, försök igen.");
                        break;

                }
            }
        }

        public Account MainMenuCase1()
        {
            while (true)
            {
                PrintMainMenuCase1();
                var key = Console.ReadKey(intercept: true).Key;
                try
                {

                    int index = (int)key - (int)ConsoleKey.D1;
                    if (index == 20)
                    {
                        return null;
                    }
                    return PersonAccounts.Accounts[index];
                }
                catch (Exception ex)
                {
                    Console.Clear();
                    Console.WriteLine(ex.Message);
                    Console.WriteLine("Du gav fel in put");
                    Console.ReadLine();
                }
            }
        }

        public void AccountMenu()
        {
            while (true)
            {
                Account? account = MainMenuCase1();
                if (account != null)
                {
                    bool loop = true;
                    while (loop)
                    {
                        PrintAccountMenu(account);
                        switch (Console.ReadKey(intercept: true).Key)
                        {
                            case ConsoleKey.D1:
                                Despite(account);
                                break;
                            case ConsoleKey.D2:
                                WithDraw(account);
                                break;
                            case ConsoleKey.D3:
                                loop = false;
                                break;
                            case ConsoleKey.D4:
                                return;
                        }
                    }
                }
                else
                {
                    break;
                }
            }
        }

        public void Despite(Account account)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine();
                var Input = Console.ReadLine();
                try
                {
                    Double amount = Convert.ToDouble(Input);
                    account.Deposit(amount);
                    return;
                }
                catch (InvalidOperationException ex)
                {

                }
            }


        }
        public void WithDraw(Account account)
        {
            Console.Clear();
            Console.WriteLine();
            var Input = Console.ReadLine();
            try
            {
                Double amount = Convert.ToDouble(Input);
                account.WithDraw(amount);
                return;
            }
            catch (InvalidOperationException ex)
            {

            }
        }


        /*
        
        
        Här ar vad som kommer skrivas 
        
        */

        public void PrintMainMenu()
        {
            Console.Clear();
            Console.WriteLine("1. Välj konto");
            Console.WriteLine("2. Vissa alla konton och saldo");
            Console.WriteLine("3. Skapa nytt konto");
            Console.WriteLine("4. Byt lösenord");
            Console.WriteLine("5. Logga ut");
        }

        public void PrintMainMenuCase1()
        {
            int i = 0;
            Console.Clear();
            Console.WriteLine($"Dina konton: ");
            foreach (Account account in PersonAccounts.Accounts)
            {
                Console.WriteLine($"{++i}. {account.ToString()}");
            }
            Console.WriteLine($"Enter 1-{i}");
        }
        public void PrintAccountMenu(Account account)
        {

            Console.Clear();
            Console.WriteLine(account.ToString());
            Console.WriteLine("1. Överför");
            Console.WriteLine("2. Insättning");
            Console.WriteLine("3. Byt Account");
            Console.WriteLine("4. Huvud Meny");

        }

    }
}
