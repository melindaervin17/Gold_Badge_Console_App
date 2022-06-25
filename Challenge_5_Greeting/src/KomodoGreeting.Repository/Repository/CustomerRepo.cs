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
                oldCustomerDetails.Name = newCustomerDeatils.Name;
                oldCustomerDetails.Status = newCustomerDeatils.Status;

                return true;
            }
            else
            {
                return false;
            }
        }

        public bool DeleteCustomerFromDatabase()
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
    }
