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
            Customer dee = new Customer("Dee", "Winters", CustomerStatus.current);
            Customer jasmine = new Customer("Jasmine", "Summers", CustomerStatus.current);
            Customer luke = new Customer("Luke", "Johnson", CustomerStatus.past);
            Customer nicole = new Customer("Nicole", "Fears", CustomerStatus.past);
            Customer randy = new Customer("Randy", "Newton", CustomerStatus.potential);
            Customer alonna = new Customer("Alonna", "Bryers", CustomerStatus.potential);

            _cRepo.AddCustomerToDatabase(dee);
            _cRepo.AddCustomerToDatabase(jasmine);
            _cRepo.AddCustomerToDatabase(luke);
            _cRepo.AddCustomerToDatabase(nicole);
            _cRepo.AddCustomerToDatabase(randy);
            _cRepo.AddCustomerToDatabase(alonna);

            List<Customer> customerDB = _cRepo.GetAllCustomers();
            customerDB.Sort((x, y) => string.Compare(x.FirstName, y.FirstName));
            foreach (Customer c in customerDB)
            {
                System.Console.WriteLine(c.FirstName);
            }
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
                + "X. Close Application\n"
                );
                string userInput = Console.ReadLine();
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
                    case "X":
                    case "x":
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
            System.Console.WriteLine("Please enter the Customer's status: \n"
                + "1. Potential\n"
                + "2. Current\n"
                + "3. Past\n"   
                );
                string statusInput = Console.ReadLine().ToLower();             
                switch(statusInput)
                {
                    case "1":
                    case "potential":
                        newCustomer.Status = CustomerStatus.potential;
                        break;
                    case "2":
                    case "current":
                        newCustomer.Status = CustomerStatus.current;
                        break;
                    case "3":
                    case "past":
                        newCustomer.Status = CustomerStatus.past;
                        break;
                    default:
                        System.Console.WriteLine("Invalid selection."); 
                        break;  
                }

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
            System.Console.WriteLine($"\tID: {customer.ID} \n \tName: {customer.FirstName} {customer.LastName} \n \tStatus: {customer.Status} \n \tEmail: {customer.Email} \n"
            );
        }

        public void UpdateCustomerDetails()
        {
            Console.Clear();

            System.Console.WriteLine("Please enter a customer ID: ");
            int userInp = int.Parse(Console.ReadLine());
            var selectedCustomer = _cRepo.GetCustomerByID(userInp);
            if(selectedCustomer != null)
            {
                Console.Clear();
                Customer newCustomer = new Customer();
                System.Console.WriteLine("Please enter the customer's first name: ");
                newCustomer.FirstName = Console.ReadLine();
                System.Console.WriteLine("Please enter the customer's last name: ");
                newCustomer.LastName = Console.ReadLine();
                System.Console.WriteLine("Please enter the customer's new status: \n"
                + "1. Potential\n"
                + "2. Current\n"
                + "3. Past\n"   
                );
                string statusInput = Console.ReadLine().ToLower();             
                switch(statusInput)
                {
                    case "1":
                    case "potential":
                        newCustomer.Status = CustomerStatus.potential;
                        break;
                    case "2":
                    case "current":
                        newCustomer.Status = CustomerStatus.current;
                        break;
                    case "3":
                    case "past":
                        newCustomer.Status = CustomerStatus.past;
                        break;
                    default:
                        System.Console.WriteLine("Invalid selection."); 
                        break;  
                }
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
            foreach (Customer c in customers)
            {
                DisplayCustomerDetails(c);
            }
            try
            {
                System.Console.WriteLine("Please enter the customer ID: ");
                int userSelectedCustomer = int.Parse(Console.ReadLine());
                bool isSuccessful = _cRepo.DeleteCustomerFromDatabase(userSelectedCustomer);
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

            PressAnyKey();
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
