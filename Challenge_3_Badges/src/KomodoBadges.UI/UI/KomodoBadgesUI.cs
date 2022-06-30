using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

    public class KomodoBadgesUI
    {
        private readonly BadgeDictionary _bdRepo = new BadgeDictionary();

        private readonly List<Badges> _lRepo = new List<Badges>();

        private readonly List<Door> _dRepo = new List<Door>();


        public void Run()
        {
            SeedData();
            RunApp();
        }

        private void SeedData()
        {
            Badges badge1 = new Badges(Door.C001 | Door.C002 | Door.C006);
            Badges badge2 = new Badges(Door.C004 | Door.C005 | Door.C010);
            Badges badge3 = new Badges(Door.C008 | Door.C001 | Door.C003);
            Badges badge4 = new Badges(Door.C003 | Door.C006 | Door.C007);

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
                // Console.Clear();

                System.Console.WriteLine("=== Employee Badge Directory ===\n"
                +"Hello, please choose from the options below: \n"
                + "1. List all Badges\n"
                + "2. Add a Badge\n"
                + "3. Edit a Badge\n"
                + "X. Close Application\n"
                );

                string userInput = Console.ReadLine().ToLower();

                switch(userInput)
                {
                    case "1":
                        ViewAllBadges();
                        break;
                    case "2":
                        AddBadgeToDictionary();
                        break;
                    case "3":
                        UpdateBadgeInfo();
                        break;
                    case "X":
                    case "x":
                        isRunning = CloseApplication();
                        break;
                    default:
                        System.Console.WriteLine("Invalid selection. Please choose from the options provided.");
                        break;
                }
            }
        }

        public void ViewAllBadges()
        {
            Console.Clear();

            if (_bdRepo.GetAllBadges().Count > 0)
            {
                Dictionary<int, Badges> badge = _bdRepo.GetAllBadges();
                foreach(var b in badge)
                {
                    DisplayBadgeInfo(b.Value);
                }    
            } 
            else
            {
                System.Console.WriteLine("There are no badges in the list");
            }

            PressAnyKey();
        }

        private Badges BadgeInList(int id)
        {
            Dictionary<int, Badges> badges = _bdRepo.GetAllBadges();
            foreach(var b in badges)
            {
                if(b.Value.ID == id)
                {
                    return b.Value;
                }
            }
            return null;
        }

        private void DisplayBadgeInfo(Badges badge)
        {
            System.Console.WriteLine
            ($"BadgeID: {badge.ID}\n"
            + $"Door Access: {badge.Doors}\n"
            );
        }

        private void AddBadgeToDictionary()
        {
            Console.Clear();

            var newBadge = new Badges();

            System.Console.WriteLine("Please provide the badge number: ");
            newBadge.ID = int.Parse(Console.ReadLine());

            System.Console.WriteLine("Provide a door to grant access to: \n"
                + " 1. C001\n"
                + " 2. C002\n"
                + " 3. C003\n"
                + " 4. C004\n"
                + " 5. C005\n"
                + " 6. C006\n"
                + " 7. C007\n"
                + " 8. C008\n"
                + "10. C010\n"
            );
            string doorInput = Console.ReadLine().ToUpper();
            switch(doorInput)
            {
                case "1":
                case "C001":
                    newBadge.Doors = Door.C001;
                    break;
                case "2":
                case "C002":
                    newBadge.Doors = Door.C002;
                    break;
                case "3":
                case "C003":
                    newBadge.Doors = Door.C003;
                    break;
                case "4":
                case "C004":
                    newBadge.Doors = Door.C004;
                    break;
                case "5":
                case "C005":
                    newBadge.Doors = Door.C005;
                    break;
                case "6":
                case "C006":
                    newBadge.Doors = Door.C006;
                    break;
                case "7":
                case "C007":
                    newBadge.Doors = Door.C007;
                    break;
                case "8":
                case "C008":
                    newBadge.Doors = Door.C008;
                    break;
                case "10":
                case "C010":
                    newBadge.Doors = Door.C010;
                    break;
                default:
                    System.Console.WriteLine("Invalid selection. Please choose from the existing list of doors.");
                    break;
            }

            System.Console.WriteLine("Would you like to grant access to another door? y/n");
            string anotherDoor = Console.ReadLine();
            if(anotherDoor == "y")
            {
                System.Console.WriteLine("Provide a door to grant access to: \n"
                + "1. C001\n"
                + "2. C002\n"
                + "3. C003\n"
                + "4. C004\n"
                + "5. C005\n"
                + "6. C006\n"
                + "7. C007\n"
                + "8. C008\n"
                + "10. C010\n"
                );
                string doorInput2 = Console.ReadLine().ToUpper();
                switch(doorInput2)
                {
                    case "1":
                    case "C001":
                        newBadge.Doors = Door.C001;
                        break;
                    case "2":
                    case "C002":
                        newBadge.Doors = Door.C002;
                        break;
                    case "3":
                    case "C003":
                        newBadge.Doors = Door.C003;
                        break;
                    case "4":
                    case "C004":
                        newBadge.Doors = Door.C004;
                        break;
                    case "5":
                    case "C005":
                        newBadge.Doors = Door.C005;
                        break;
                    case "6":
                    case "C006":
                        newBadge.Doors = Door.C006;
                        break;
                    case "7":
                    case "C007":
                        newBadge.Doors = Door.C007;
                        break;
                    case "8":
                    case "C008":
                        newBadge.Doors = Door.C008;
                        break;
                    case "10":
                    case "C010":
                        newBadge.Doors = Door.C010;
                        break;
                    default:
                        System.Console.WriteLine("Invalid selection. Please choose from the existing list of doors.");
                        break;
                }
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


        public void UpdateBadgeInfo()
        {
            Console.Clear();
            var currentBadges = _bdRepo.GetAllBadges();
            // foreach(KeyValuePair<int, Badges> b in currentBadges)
            // {
            //     if
            //     DisplayBadgeInfo(b.Value);
            // }

            System.Console.WriteLine("Please provide the badge number you wish to update: ");
            int userInput2 = int.Parse(Console.ReadLine());
            var selectedBadge = _bdRepo.GetBadgeByKey(userInput2);
            if(selectedBadge != null)
            {
                Console.Clear();
                Badges newBadge = new Badges();
                System.Console.WriteLine("Please select an option: \n"
                + "1. Remove a door \n"
                + "2. Add a door \n"
                );

                string selectedOpt = Console.ReadLine().ToLower();
                switch(selectedOpt)
                {
                    case "1":
                    case "Remove a door":
                        Console.Clear();
                        System.Console.WriteLine("Select a door to remove: ");
                        int selectedDoor = int.Parse(Console.ReadLine());
                        var chosenDoor = _dRepo.FirstOrDefault();
                        if(selectedDoor != null)
                        {
                            _dRepo.Remove(chosenDoor);
                        }
                        else
                        {
                            System.Console.WriteLine("Invalid"); 
                        }
                        PressAnyKey();
                        UpdateBadgeInfo();
                        break;
                    case "2":
                    case "Add a door":
                        Console.Clear();
                        System.Console.WriteLine("Provide a door to add: \n"
                        + "1. C001\n"
                        + "2. C002\n"
                        + "3. C003\n"
                        + "4. C004\n"
                        + "5. C005\n"
                        + "6. C006\n"
                        + "7. C007\n"
                        + "8. C008\n"
                        + "10. C010\n"
                        );
                        string doorInput3 = Console.ReadLine().ToUpper();
                        switch(doorInput3)
                        {
                            case "1":
                            case "C001":
                                newBadge.Doors = Door.C001;
                                break;
                            case "2":
                            case "C002":
                                newBadge.Doors = Door.C002;
                                break;
                            case "3":
                            case "C003":
                                newBadge.Doors = Door.C003;
                                break;
                            case "4":
                            case "C004":
                                newBadge.Doors = Door.C004;
                                break;
                            case "5":
                            case "C005":
                                newBadge.Doors = Door.C005;
                                break;
                            case "6":
                            case "C006":
                                newBadge.Doors = Door.C006;
                                break;
                            case "7":
                            case "C007":
                                newBadge.Doors = Door.C007;
                                break;
                            case "8":
                            case "C008":
                                newBadge.Doors = Door.C008;
                                break;
                            case "10":
                            case "C010":
                                newBadge.Doors = Door.C010;
                                break;
                            default:
                                System.Console.WriteLine("Invalid selection. Please choose from the existing list of doors.");
                                break;
                        }
                        // newBadge.Doors = int.Parse(Console.ReadLine().ToUpper());
                        bool isAdded = _bdRepo.AddDoorAccess(newBadge.Doors);
                        if(isAdded)
                        {
                            System.Console.WriteLine($"Door {newBadge.Doors} was added.");
                        }
                        else
                        {
                            System.Console.WriteLine("Unable to add this door.");
                        }
                        System.Console.WriteLine("Would you like add another door? y/n");
                        string anotherDoor = Console.ReadLine();
                        if(anotherDoor == "y")
                        {
                        System.Console.WriteLine("Provide a door to grant access to: \n"
                        + "1. C001\n"
                        + "2. C002\n"
                        + "3. C003\n"
                        + "4. C004\n"
                        + "5. C005\n"
                        + "6. C006\n"
                        + "7. C007\n"
                        + "8. C008\n"
                        + "10. C010\n"
                        );
                        string doorInput4 = Console.ReadLine().ToUpper();
                        switch(doorInput4)
                        {
                            case "1":
                            case "C001":
                                newBadge.Doors = Door.C001;
                                break;
                            case "2":
                            case "C002":
                                newBadge.Doors = Door.C002;
                                break;
                            case "3":
                            case "C003":
                                newBadge.Doors = Door.C003;
                                break;
                            case "4":
                            case "C004":
                                newBadge.Doors = Door.C004;
                                break;
                            case "5":
                            case "C005":
                                newBadge.Doors = Door.C005;
                                break;
                            case "6":
                            case "C006":
                                newBadge.Doors = Door.C006;
                                break;
                            case "7":
                            case "C007":
                                newBadge.Doors = Door.C007;
                                break;
                            case "8":
                            case "C008":
                                newBadge.Doors = Door.C008;
                                break;
                            case "10":
                            case "C010":
                                newBadge.Doors = Door.C010;
                                break;
                            default:
                                System.Console.WriteLine("Invalid selection. Please choose from the existing list of doors.");
                                break;
                        }
                        // string anotherDoorInp = Console.ReadLine().ToLower();
                        }
                        else if(anotherDoor == "n")
                        {
                        RunApp();
                        }
                        else
                        {
                            System.Console.WriteLine("Invalid selection. Please respond with 'y' for yes or 'n' for no.");
                        }
                        break;
                    default:
                        System.Console.WriteLine("Invalid selection.");
                        break;
                }
            }
            else
            {
                System.Console.WriteLine("Please provide a valid badge number.");
            }

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
