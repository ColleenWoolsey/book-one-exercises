using System;
using System.Collections.Generic;

namespace tryCatch
{

    public class AddressBook
    {        
        public Dictionary<string, Contact> addressBook = new Dictionary<string, Contact>();
        // Don't need a constructor because every time add a dictionary it's always a key value pair
        // string is the type for key and Contact is the type for value
        // Constructor methods are unique - The void is implied and they 
        // always have the name of the class

        // Returning the value of the key
        // The argument is the email key

        // public type methodname (argument)
        public Contact GetByEmail(string email) {
            return addressBook[email];
        } 

        // public void method name(argument = contact object name - ie bob) {
        // do a regular add to the addressBook with a key and value pair }
        
        public void AddContact(Contact contact) {
            addressBook.Add(contact.Email, contact);
        }  
    }
}