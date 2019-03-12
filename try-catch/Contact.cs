using System;

namespace tryCatch
{    
    public class Contact
    {
        public string FirstName {get; set;}
        public string LastName {get; set;}
        public string Email {get; set;}
        public string Address {get; set;}

        // Just for fun        
        public string FullName {get
            {
                return $"{FirstName} {LastName}";
            }
        // Don't need a constructor because added the long form way in Program
        }
    }
}