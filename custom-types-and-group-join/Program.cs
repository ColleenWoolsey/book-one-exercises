using System;
using System.Collections.Generic;
using System.Linq;

namespace custom_types_and_group_join
{
// Define a bank
public class Bank
{
    public string Symbol { get; set; }
    public string Name { get; set; }
}

// Define a customer
public class Customer
{
    public string Name { get; set; }
    public double Balance { get; set; }
    public string Bank { get; set; }
}
public class Result
{
    public string BankName {get; set;}
    public double BankMillions {get; set;}
}

public class ReportItem
{
    public string BankName { get; set; }
    public string CustomerName { get; set; }
    
}

public class Program
{
    public static void Main()
        {
            List<Bank> banks = new List<Bank>() {
            new Bank(){ Name="First Tennessee", Symbol="FTB"},
            new Bank(){ Name="Wells Fargo", Symbol="WF"},
            new Bank(){ Name="Bank of America", Symbol="BOA"},
            new Bank(){ Name="Citibank", Symbol="CITI"},
        };

            List<Customer> customers = new List<Customer>() {
            new Customer(){ Name="Bob Lesman", Balance=80345.66, Bank="FTB"},
            new Customer(){ Name="Joe Landy", Balance=9284756.21, Bank="WF"},
            new Customer(){ Name="Meg Ford", Balance=487233.01, Bank="BOA"},
            new Customer(){ Name="Peg Vale", Balance=7001449.92, Bank="BOA"},
            new Customer(){ Name="Mike Johnson", Balance=790872.12, Bank="WF"},
            new Customer(){ Name="Les Paul", Balance=8374892.54, Bank="WF"},
            new Customer(){ Name="Sid Crosby", Balance=957436.39, Bank="FTB"},
            new Customer(){ Name="Sarah Ng", Balance=56562389.85, Bank="FTB"},
            new Customer(){ Name="Tina Fey", Balance=1000000.00, Bank="CITI"},
            new Customer(){ Name="Sid Brown", Balance=49582.68, Bank="CITI"}
        };

Console.WriteLine("Build a collection of customers who are millionaires");
        List<Customer> millionaires = (from c in customers
            where c.Balance >= 1000000.00
            select c
            ).ToList();

        foreach(Customer mill in millionaires) {
            Console.WriteLine($"{mill.Name} is rich by 20th century standards");

        }

            
Console.WriteLine("***** Show millionaires Per Bank *****");
        List<Result> bankResults = (from c in customers
            group c by c.Bank into theBankGroup
            select new Result
                {
                    BankName = theBankGroup.Key, 
                    BankMillions = theBankGroup.Count(c => c.Balance >= 1000000)
                }
        ).ToList();

            foreach(Result bank in bankResults)
            {
                Console.WriteLine($"{bank.BankName} - {bank.BankMillions}");
            }

Console.WriteLine("***** Show millionaires Per Bank Sorted by Last Name and showing Bank Name *****");        
    // As in the previous exercise, you're going to output the millionaires,
    // but you will also display the full name of the bank. You also need
    // to sort the millionaires' names, ascending by their LAST name.
    // You will need to use the `Where()`and `Select()` methods to generate
    // instances of the following class.

    var reportItem = from c in customers // outer sequence
            where c.Balance >= 1000000.00
            orderby c.Name.Split(" ").Last()
            join b in banks //inner sequence 
            on c.Bank equals b.Symbol // key selector 
            select new { // result selector 
                        CustomerName = c.Name, 
                        BankName = b.Name 
                    };
            
        foreach (var item in reportItem)
        {
            Console.WriteLine(value: $"{item.CustomerName} banks at {item.BankName}");
        }

        }
    }
}