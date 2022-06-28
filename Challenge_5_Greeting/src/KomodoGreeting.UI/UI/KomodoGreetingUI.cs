using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

    public class KomodoGreetingUI
    {
        private readonly CustomerRepo _cRepo = new CustomerRepo();

        public void Run()
        {
            SeedData();
            RunApplication();
        }

        private void SeedData()
        {
            Customer dee = new Customer("Dee", "Winters");
            Customer jasmine = new Customer("Jasmine", "Summers");
            Customer luke = new Customer("Luke", "Johnson");
            Customer nicole = new Customer("Nicole", "Fears");
            Customer randy = new Customer("Randy", "Newton");
            Customer alonna = new Customer("Alonna", "Bryers");

            _cRepo.AddCustomerToDatabase(dee);
            _cRepo.AddCustomerToDatabase(jasmine);
            _cRepo.AddCustomerToDatabase(luke);
            _cRepo.AddCustomerToDatabase(nicole);
            _cRepo.AddCustomerToDatabase(randy);
            _cRepo.AddCustomerToDatabase(alonna);
        }

        public void RunApplication()
        {
            bool isRunning = true;

            while(isRunning)
            {
                Console.Clear();
                System.Console.WriteLine("Please select from the options below: \n"
                + "1. Add a Customer\n"
                + "2. View all Customers\n"
                + "3. Update Customer Details\n"
                + "4. Delete a Customer\n"
                + "5. Close Application\n"
                );
                string userInput = Console.Readline();
                switch(userInput)
                {
                    case "1":
                        AddCustomerToDatabase();
                        break;
                    case "2":
                        ViewAllCustomers();
                        break;
                    case "3":
                        UpdateCustomerDetails();
                        break;
                    case "4":
                        DeleteCustomer();
                        break;
                    case "5":
                        isRunning = CloseApplication();
                        break;
                    default:
                        System.Console.WriteLine("Invalid selection.");
                        break;
                }
            }
        }

        private void AddCustomerToDatabase()
        {
            Console.Clear();

            Customer newCustomer = new Customer();

            var currentCustomer = _cRepo.GetAllCustomers();

            System.Console.WriteLine("Please enter the Customer's first name: ");
            newCustomer.FirstName = Console.ReadLine();
            System.Console.WriteLine("Please enter the Customer's last name: ");
            newCustomer.LastName = Console.ReadLine();

            bool isSuccessful = _cRepo.AddCustomerToDatabase(newCustomer);
            if(isSuccessful)
            {
                System.Console.WriteLine($"{newCustomer.FirstName} {newCustomer.LastName} was added to the database.");
            }
            else
            {
                System.Console.WriteLine("Something went wrong...");
            }

            PressAnyKey();
        }

        public void ViewAllCustomers()
        {
            Console.Clear();
            List<Customer> customersInDB = _cRepo.GetAllCustomers();
            if(customersInDB.Count > 0)
            {
                foreach (Customer c in customersInDB)
                {
                    DisplayCustomerDetails(c);
                }
            }
            else
            {
                System.Console.WriteLine("No customers exist.");
            }

            PressAnyKey();
        }

        private void DisplayCustomerDetails(Customer customer)
        {
            System.Console.WriteLine($"\tName: {customer.FirstName} {customer.LastName} \n \tStatus: {customer.Status} \n \tEmail: {customer.Email} \n"
            );
        }

        public void UpdateCustomerDetails()
        {
            Console.Clear();

            System.Console.WriteLine("Please enter a customer ID: ");
            int userInput = int.Parse(Console.ReadLine());
            var selectedCustomer = _cRepo.GetCustomerByID(userInput);
            if(selectedCustomer != null)
            {
                Console.Clear();
                Customer newCustomer = new Customer();
                System.Console.WriteLine("Please enter the customer's first name: ");
                newCustomer.FirstName = Console.ReadLine();
                System.Console.WriteLine("Please enter the customer's last name: ");
                newCustomer.LastName = Console.ReadLine();
                System.Console.WriteLine("Please enter the customer's new status: ");
                newCustomer.Status = Console.ReadLine();
            }
            else
            {
                System.Console.WriteLine("No customer exists.");
            }
        
        PressAnyKey();
        }

        private void DeleteCustomer()
        {
            Console.Clear();
            var customers = _cRepo.GetAllCustomers();
            try
            {
                System.Console.WriteLine("Please enter the customer ID: ");
                int userSelectedCustomer = int.Parse(Consolr.ReadLine());
                bool isSuccessful = _cRepo.RemoveCustomer(userSelectedCustomer);
                if(isSuccessful)
                {
                    System.Console.WriteLine("The selcted customer has been removed.");
                }
                else
                {
                    System.Console.WriteLine("Unable to remove the selected customer.");
                }
            }
            catch 
            {
                System.Console.WriteLine("Invalid input.");
            }

            PresAnyKey();
        }

        private bool CloseApplication()
        {
            Console.Clear();
            System.Console.WriteLine("Goodbye!");
            PressAnyKey();
            return false;
        }

        private void PressAnyKey()
        {
            System.Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }
