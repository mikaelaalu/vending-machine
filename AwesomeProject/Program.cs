using System;
using Microsoft.VisualBasic;
using System.Collections.Generic;

namespace AwesomeProject
{
    class Program
    {
        static void Main(string[] args)
        {
            var goodsItems = new List<Item>();

            goodsItems.AddRange(new List<Item>
            {
                new Item("Chocolate", 10),
                new Item("Coke", 20),
                new Item("Sprite", 20),
                new Item("Chips", 15),
                new Item("Banana", 5),
            });
            
            int moneyOnBank = 200;
            int moneyInPocket = 0;
            var bought = new List<string>();
            
            Console.WriteLine("Welcome to this amazing bank, what's your name?");
            string name = Console.ReadLine();
            Console.WriteLine();
            
            var user = new Bank(moneyOnBank);
            
            Console.WriteLine($"Hi {name}! If you want to shop anything you need money in your pocket.");
            
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("Pick a number to tell me what you want to do.");
                Console.WriteLine("1. To see money in your pocket that you can shop for");
                Console.WriteLine("2. Check account");
                Console.WriteLine("3. Withdrawal");
                Console.WriteLine("4. Menu" );
                Console.WriteLine("5. Shop");
                Console.WriteLine("6. Receipt");
                Console.WriteLine();


                var option = Console.ReadLine();

                if (option == "1")
                {
                    Console.WriteLine($"You have {moneyInPocket} to shop for. ");
                    
                }

                if (option == "2" )
                {
                    var total = user.CheckAccount();
                    Console.WriteLine($"You have {total} on your account.");
            

                }

                if (option == "3")
                {
                    Console.WriteLine("Please tell me how much money you want to take out.");
                    
                    int.TryParse(Console.ReadLine(), out int wantToTakeOut);
                    var takeOut = user.Withdrawal(wantToTakeOut);
                    if (takeOut)
                    {
                        moneyInPocket = wantToTakeOut + moneyInPocket;
                        Console.WriteLine($"You now have {moneyInPocket} to shop for.");
                    }
                    else
                    {
                        Console.WriteLine("You dont have that much money on you bank. Please try again.");
                    }
                }

                if (option == "4")
                {
                    Console.WriteLine("*******************");
                    foreach (var goodsItem in goodsItems)
                    {
                        Console.WriteLine($"{goodsItem.name}, price: {goodsItem.price}" );
                    }
                    Console.WriteLine("*******************");
                }

                if (option == "5")
                {
                    Console.WriteLine("Tell me want you want to shop");
                    
                    var item = Console.ReadLine();
                    
                    int cost = VendingMachine.Shop(goodsItems, item, moneyInPocket);
                    if (cost != 0)
                    {
                        bought.Add(item);
                        moneyInPocket = moneyInPocket - cost;
                        Console.WriteLine($"Here is your {item}, you have now {moneyInPocket} to shop for.");

                        continue;
                    }
                    
                    Console.WriteLine("You dont have enough money.");
                }

                if (option== "6")
                {
                    if (bought.Count == 0)
                    {
                        Console.WriteLine("You havn't bought anything yet. Please go to the shop.");
                    }

                    if (bought.Count > 0)
                    {
                        Console.WriteLine("You have bought: ");
                        foreach (var item in bought)
                        {
                            Console.WriteLine(item);
                        }
                    }
                }
            }
        }
    }
}