using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

    public class Customer
    {
        public void Customer(){}

        public void Customer(string firstName, string lastName, CustomerStatus status)
        {
            FirstName = firstName;
            LastName = lastName;
            Status = status;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public CustomerStatus Status { get; set; }
    }
