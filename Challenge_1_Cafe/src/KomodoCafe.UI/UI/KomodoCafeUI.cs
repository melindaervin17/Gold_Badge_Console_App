using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

    public class KomodoCafeUI
    {
        private readonly MenuRepo _mRepo = new MenuRepo();

        public void Run()
        {
            SeedData();
            RunMenu();
        }

        private void SeedData()
        {
            Menu burger = new Menu(1, "Burger Combo", "Hamburger, no cheese, with lettuce, tomato, onions, and pickles on a toasted bun. Comes with fries and a drink.", "Beef patty, wheat bun, lettuce, tomato, onions, pickes, ketchup, mustard, mayo, potatoes", 7.50);
            Menu cheeseBurger = new Menu(2, "Cheeseburger Combo", "Hamburger with cheese, lettuce, tomato, onions and pickles on a toasted bun. Comes with fries and a drink.", "Beef patty, American cheese, wheat bun, lettuce, tomato, onions, pickes, ketchup, mustard, mayo, potatoes", 7.99);
            Menu chickenSandwich = new Menu(3, "Chicken sandwich combo", "Fried or grilled chicken patty on a toasted bun with lettuce, tomato, onions and pickles. Comes with fries and a drink.", "Chicken patty, wheat bun, lettuce, tomato, onions, pickles, mayo, potatoes", 7.25);

            Menu nuggets = new Menu(4, "Chicken Nugget Combo", "10pc chicken nuggets with choice of dipping sauce. Comes with fries and a drink.", "Chicken, potatoes", 7);

            _mRepo.AddItemToMenu(burger);
            _mRepo.AddItemToMenu(cheeseBurger);
            _mRepo.AddItemToMenu(chickenSandwich);
            _mRepo.AddItemToMenu(nuggets);
        }

        private void RunMenu()
        {
            bool isRunning = true;

            while(isRunning)
            {
                Console.Clear();

                System.Console.WriteLine("=== Welcome to Kamodo Cafe ===");

                System.Console.WriteLine("Please make a selection \n"
                + "1. Add item to menu \n"
                + "2. View all items \n"
                + "3. Delete an item \n"
                + "X. Close Application \n"
                );

                string userInput = Console.ReadLine();

                switch(userInput)
                {
                    case "1":
                        AddItemToMenu();
                        break;
                    case "2":
                        ViewAllItems();
                        break;
                    case "3":
                        DeleteItem();
                        break;
                    case "X":
                    case"x":
                        isRunning = CloseApplication();
                        break;
                    default:
                        System.Console.WriteLine("Invalid selection");
                        break;
                }
            }
        }

        private void AddItemToMenu()
        {
            Console.Clear();

            var newMenu = new Menu();
            // Menu item = new Menu();

            System.Console.WriteLine("Please enter a combo meal number: ");
            newMenu.MealNum = int.Parse(Console.ReadLine());

            System.Console.WriteLine("Please enter a meal name: ");
            newMenu.Name = Console.ReadLine();

            System.Console.WriteLine("Please enter a meal description: ");
            newMenu.Description = Console.ReadLine();

            System.Console.WriteLine("Please enter a list of ingredients: ");
            newMenu.Ingredients = Console.ReadLine();

            System.Console.WriteLine("Please enter a price: ");
            newMenu.Price = double.Parse(Console.ReadLine());

            bool isSuccessful = _mRepo.AddItemToMenu(newMenu);

            if(isSuccessful)
            {
                System.Console.WriteLine($"{newMenu.Name} was added to the menu.");
            }
            else
            {
                System.Console.WriteLine("Unable to add item to the menu.");
            }
        }

        public void ViewAllItems()
        {
            Console.Clear();
            List<Menu> itemsInMenu = _mRepo.GetAllItems();
            if(itemsInMenu.Count > 0)
            {
                foreach(Menu m in itemsInMenu)
                {
                    DisplayMenuItems(m);
                }
            }
            else
            {
                System.Console.WriteLine("No items exist");
            }

            PressAnyKey();
        }

        private void DisplayMenuItems(Menu item)
        {
            System.Console.WriteLine
            ($"Number: {item.MealNum}\n" 
            + $"Name: {item.Name}\n"
            + $"Description: {item.Description}\n"
            + $"Ingredients: {item.Ingredients}\n"
            + $"Price: {item.Price}\n"
            );
        }

        private void DeleteItem()
        {
            Console.Clear();

            ViewAllItems();
            try
            {
                System.Console.WriteLine("Please enter the number of the item you wish to remove: ");
                int selectedItem = int.Parse(Console.ReadLine());
                bool isRemoved = _mRepo.DeleteMenuItems(selectedItem);
                if(isRemoved)
                {
                    System.Console.WriteLine("Menu item was removed");
                }
                else
                {
                    System.Console.WriteLine("Unable to remove selected item");
                }
            }
            catch
            {
                System.Console.WriteLine("Invalid selection");
            }

            // List<Menu> itemMenu = _mRepo.GetAllItems();

            // if(itemMenu.Count() > 0)
            // {
            //     System.Console.WriteLine("Please select the item you wish to remove: ");

            //     int count = 0;

            //     foreach (var item in itemMenu)
            //     {
            //         count++;
            //         System.Console.WriteLine($"{count}. {item.Name}");
            //     }

            //     int selectedItem = int.Parse(Console.ReadLine());
            //     int selectedMenu = selectedItem -1;

            //     if(selectedMenu >= 0 && selectedMenu < itemMenu.Count)
            //     {
            //         Menu desiredItem = itemMenu[selectedMenu];
            //         if(_mRepo.DeleteMenuItems(desiredItem))
            //         {
            //             System.Console.WriteLine($"{desiredItem.MealNum} was removed.");
            //         }
            //         else
            //         {
            //             System.Console.WriteLine("Unable to remove the selected item.");
            //         }
            //     }
            //     else
            //     {
            //         System.Console.WriteLine("Content with selected number not found.");
            //     }
            // }

            PressAnyKey();
        }

        private bool CloseApplication()
        {
            Console.Clear();

            System.Console.WriteLine("Have a nice day!");
            PressAnyKey();
            return false;
        }

        private void PressAnyKey()
        {
            System.Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }
