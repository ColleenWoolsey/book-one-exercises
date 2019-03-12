using System;
using System.Collections.Generic;

namespace tryCatch
{
  public class Program
  {
    /*
        1. Add the required classes to make the following code compile.
        HINT: Use a Dictionary in the AddressBook class to store Contacts. The key should be the contact's email address.

        2. Run the program and observe the exception.

        3. Add try/catch blocks in the appropriate locations to prevent the program from crashing
            Print meaningful error messages in the catch blocks.
    */

    static void Main(string[] args)
    {
        // Create a few contacts
        Contact bob = new Contact() {
            FirstName = "Bob",
            LastName = "Smith",
            Email = "bob.smith@email.com",
            Address = "100 Some Ln, Testville, TN 11111"
        };
        Contact sue = new Contact() {
            FirstName = "Sue",            
            LastName = "Jones",
            Email = "sue.jones@email.com",
            Address = "322 Hard Way, Testville, TN 11111"
        };
        Contact juan = new Contact() {
            FirstName = "Juan",
            LastName = "Lopez",
            Email = "juan.lopez@email.com",
            Address = "888 Easy St, Testville, TN 11111"
        };

        // List<Dictionary<string, Contact>> addressBook = new List<Dictionary<string, Contact>>();

        // Create an AddressBook and add some contacts to it
        AddressBook addressBook = new AddressBook();
        addressBook.AddContact(bob);
        addressBook.AddContact(sue);
        addressBook.AddContact(juan);

        try{
        // Try to add a contact a second time
        addressBook.AddContact(sue);
        }
        catch(Exception)
        {
            Console.WriteLine("That contact is already in the AddressBook");
        }

        // Create a list of emails that match our Contacts
        // This is for my reference as not Console.Writing it
        List<string> emails = new List<string>() {
            "sue.jones@email.com",
            "juan.lopez@email.com",
            "bob.smith@email.com",
        };

        // Insert an email (that does NOT match a Contact) into position [1]
        // in list - ie ... after Sue So her infor should show up on first loop
        // I DON'T put the try before this line because it has no 
        // problem inserting this email in the list and so skips over the catch
        // The exception shows up when I TRY to print out the contact info for not.in email
        emails.Insert(1, "not.in.addressbook@email.com");
        
        try{
        //  Search the AddressBook by email and print the information about each Contact
        foreach (string email in emails)
        {
            Contact contact = addressBook.GetByEmail(email);
            Console.WriteLine("----------------------------");
            Console.WriteLine($"Name: {contact.FullName}");
            Console.WriteLine($"Email: {contact.Email}");
            Console.WriteLine($"Address: {contact.Address}");
        }
        }
        catch(Exception) {
            Console.WriteLine("There is no contact infor for that email");
        }
    }
  }
}