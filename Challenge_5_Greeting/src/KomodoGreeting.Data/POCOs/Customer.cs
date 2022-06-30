using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

    public class Customer
    {
        public Customer(){}

        public Customer(string firstName, string lastName, CustomerStatus status)
            {
                FirstName = firstName;
                LastName = lastName;
                Status = status;
            }

            public int ID { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public CustomerStatus Status { get; set; }
            public string Email { get
            {
                switch(Status)
                {
                    case CustomerStatus.current:
                        return "Thank you for your work with us. We appreciate your loyalty. Here's a coupon.";
                    case CustomerStatus.past:
                        return "It's been a long time since we've heard from you, we want you back.";
                    case CustomerStatus.potential:
                        return "We currently have the lowest rates on Helicopter Insurance!";
                    default:
                        return "Status undetermined.";
                }
            }
        }
    }
