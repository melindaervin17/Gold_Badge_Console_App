using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

    public class KomodoBadgesUI
    {
        private readonly BadgeDictionary _bdRepo = new BadgeDictionary();

        private readonly DoorList _dRepo = new DoorList();

        public void Run()
        {
            SeedData();
            RunApp();
        }

        private void SeedData()
        {
            Badges badge1 = new Badges(234, "A1", "A2", "A4");
            Badges badge2 = new Badges(235, "A1", "A3", "A5");
            Badges badge3 = new Badges(236, "A3", "A4", "A5");
            Badges badge4 = new Badges(237, "A2", "A3", "A4");

            _bdRepo.AddBadgeToDictionary(badge1);
            _bdRepo.AddBadgeToDictionary(badge2);
            _bdRepo.AddBadgeToDictionary(badge3);
            _bdRepo.AddBadgeToDictionary(badge4);
        }

        public void RunApp()
        {
            bool isRunning = true;
            while(isRunning)
            {
                Console.Clear();

                System.Console.WriteLine("Hello, please choose from the options below: \n"
                + "1. Add a Badge\n"
                + "2. Edit a Badge\n"
                + "3. List all Badges\n"
                + "X. Close Application\n"
                );

                string userInput = Console.Readline().ToLower();

                switch(userInput)
                {
                    case "1":
                        AddBadgeToDictionary();
                        break;
                    case "2":
                        UpdateBadgeInfo();
                        break;
                    case "3":
                        ViewAllBadges();
                        break;
                    case "X":
                        isRunning = CloseApplication();
                        break;
                    default:
                        System.Console.WriteLine("Invalid selection. Please choose from the options provided.");
                }
            }
        }

        private void AddBadgeToDictionary()
        {
            Clear.Console();

            var newBadge = new Badges();

            System.Console.WriteLine("Please provide the badge number: ");
            newBadge.ID = int.Parse(Console.ReadLine());

            System.Console.WriteLine("Provide a door to grant access to: ");
            newBadge.Doors = Console.ReadLine().ToUpper();

            System.Console.WriteLine("Would you like to grant access to another door? y/n");
            string anotherDoor = Console.ReadLine();
            if(anotherDoor == "y")
            {
                System.Console.WriteLine("Provide a door to grant access to: ");
                newBadge.Doors();
            }
            else if(anotherDoor == "n")
            {
                RunApp();
            }
            else
            {
                System.Console.WriteLine("Invalid selection. Please respond with 'y' for yes or 'n' for no.");
            }

            PressAnyKey();
        }

        private void UpdateBadgeInfo()
        {
            Console.Clear();
            var currentBadges = _bdRepo.GetAllBadges();
            foreach(var b in currentBadges)
            {
                DisplayBadgeInfo();
            }

            System.Console.WriteLine("Please provide the badge number you wish to update: ");
            int userInput = int.Parse(Console.ReadLine());
            
            var selectedBadge = _bdRepo.GetBadgeByID(userInput);
            if(selectedBadge != null)
            {
                DisplayDoorListing();
            }
            else
            {
                System.Console.WriteLine("Please provide a valid badge number.");
            }

            System.Console.WriteLine("Please select an option: \n"
            + "1. Remove a door \n"
            + "2. Add a door \n"
            );

            string userInput = Console.ReadLine().ToUpper();
            switch(userInput)
            {
                case "1":
                    System.Console.WriteLine("Select a door to remove: ");
                    string selectedDoor = int.Parse(Console.ReadLine());
                    var selectedDoor = _dRepo.GetDoorByName(selectedDoor);
                    if(selectedDoor != null)
                    {
                        currentDoors.Remove(selectedDoor);
                    }
                    else
                    {
                        System.Console.WriteLine("Sorry, this door does not exist.");
                    }
                    PressAnyKey();
                    UpdateBadgeInfo();
                case "2":
                    System.Console.WriteLine("Provide a door to add: ");
                    newDoor.Doors = Console.ReadLine().ToUpper();
                    bool isAdded = _dRepo.AddDoorAccess(newDoor);
                    if(isAdded)
                    {
                        System.Console.WriteLine($"Door {newDoor.Doors} was added.");
                    }
                    else
                    {
                        System.Console.WriteLine("Unable to add this door.");
                    }
                    System.Console.WriteLine("Would you like add another door? y/n");
                    string anotherDoor = Console.ReadLine();
                    if(anotherDoor == "y")
                    {
                    System.Console.WriteLine("Provide a door to grant access to: ");
                    newDoor.Doors();
                    }
                    else if(anotherDoor == "n")
                    {
                    RunApp();
                    }
                    else
                    {
                        System.Console.WriteLine("Invalid selection. Please respond with 'y' for yes or 'n' for no.");
                    }

            PressAnyKey();
            }
        }

        public void ViewAllBadges()
        {
            Console.Clear();

            if(_bdRepo.GetAllBadges().Count > 0)
            {
                List<Badges> badges = _bdRepo.GetAllBadges();
                foreach (Badges b in badges)
                {
                    DisplayBadgeInfo();
                }
            }
            else
            {
                System.Console.WriteLine("No badges exist.");
            }

            PressAnyKey();
        }

        private void DisplayBadgeInfo(Badges badges)
        {
            System.Console.WriteLine
            ($"BadgeID: {badge.ID}\n"
            + $"Door Access: {badge.Doors}\n"
            );
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
