using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

    public class CustomerRepo
    {
        private readonly List<Customer> _customerDatabase = new List<Customer>();

        private int _count;

        public bool AddCustomerToDatabase(Customer customer)
        {
            if(customer != null)
            {
                _count++;
                customer.ID = _count;
                _customerDatabase.Add(customer);
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<Customer> GetAllCustomers()
        {
            return _customerDatabase;
        }

        public Customer GetCustomerByID(int id)
        {
            foreach (Customer c in _customerDatabase)
            {
                if(c.ID == id)
                {
                    return c;
                }
            }

            return null;
        }

        public bool UpdateCustomerDetails(int ID, Customer newCustomerDeatils)
        {
            var oldCustomerDetails = GetCustomerByID(ID);

            if(oldCustomerDetails != null)
            {
                oldCustomerDetails.FirstName = newCustomerDeatils.FirstName;
                oldCustomerDetails.LastName = newCustomerDeatils.LastName;
                oldCustomerDetails.Status = newCustomerDeatils.Status;

                return true;
            }
            else
            {
                return false;
            }
        }

        public bool DeleteCustomerFromDatabase(int id)
        {
            var customer = GetCustomerByID(id);

            if(customer != null)
            {
                _customerDatabase.Remove(customer);
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool EmailResponse()
        {
            foreach (Customer c in _customerDatabase)
            {
                if(c.Status == CustomerStatus.current)
                {
                    System.Console.WriteLine("Thank you for your work with us. We appreciate your loyalty. Here's a coupon.");
                }
                else if(c.Status == CustomerStatus.past)
                {
                    System.Console.WriteLine("It's been a long time since we've heard from you, we want you back.");
                }
                else if(c.Status == CustomerStatus.potential)
                {
                    System.Console.WriteLine("We currently have the lowest rates on Helicopter Insurance!");
                }
                else
                {
                    System.Console.WriteLine("Error");
                }
            }
            return false;
        }
    }
