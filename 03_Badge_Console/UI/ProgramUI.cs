using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Badge_Console.UI
{
    public class ProgramUI
    {
        private BadgeRepository _repository = new BadgeRepository();

        public void Run()
        {
            SeedData();
            OpenMenu();
        }

        public void OpenMenu()
        {
            bool menuControl = true;
            while (menuControl)
            {
                Console.Clear();
                Console.WriteLine("Hello Security Admin. What would you like to do? \n" +
                    "1. Add a badge \n" +
                    "2. Edit a badge \n" +
                    "3. List all badges \n" +
                    "4. Close the menu");
                var userinput = Console.ReadLine();
                switch (userinput)
                {
                    case "1":
                        {
                            AddBadge();
                            break;
                        }
                    case "2":
                        {
                            EditABadge();
                            break;
                        }
                    case "3":
                        {
                            ShowAllBadges();
                            break;
                        }
                    case "4":
                        {
                            menuControl = false;
                            break;
                        }
                    default:
                        {
                            menuControl = false;
                            break;
                        }
                }
            }

        }

        public void EditABadge()
        {
            Console.WriteLine("Please enter the badgeID of the badge you wish to update.");
            var userBadgeInput = int.Parse(Console.ReadLine());
            var onebadge = _repository.PullOneBadge(userBadgeInput);
            Console.WriteLine("This badge has access to the following doors: ");
            foreach (string value in onebadge.Doors)
            {
                Console.WriteLine($"{value}");
            }
            var doorMiniMenu = true;
            while (doorMiniMenu)
            {
                Console.Clear();
                Console.WriteLine($"Badge: {onebadge} currently has access to the following doors: ");
                foreach (string door in onebadge.Doors)
                {
                    Console.Write($"{door} - ");
                }
                Console.WriteLine("What would you like to do? \n" +
                    "1) Add new door. \n" +
                    "2) Remove door. \n" +
                    "3) Clear all doors from badge \n" +
                    "4) Finish updating badge \n" +
                    "Please enter either 1, 2 , or 3");
                var userReponse = Console.ReadLine();
                switch (userReponse)
                {
                    case "1":
                        {
                            Console.WriteLine("Please enter the door you would like to add to this badge");
                            var newDoor = Console.ReadLine();
                            onebadge.Doors.Add(newDoor);
                            Console.WriteLine($"Badge {onebadge.BadgeId} has been granted access to door {newDoor}.\n" +
                                $"Press any key to continue...");
                            Console.ReadKey();
                            break;
                        }
                    case "2":
                        {
                            Console.WriteLine("Please enter the door you would like removed from this badge.");
                            var removedDoor = Console.ReadLine();
                            _repository.RemoveDoorFromBadge(onebadge.BadgeId, removedDoor);
                            Console.WriteLine($"Door ({removedDoor}) has been removed from the badge #{onebadge.BadgeId}. \n" +
                                $"Press any key to continue...");
                            Console.ReadKey();
                            break;
                        }
                    case "3":
                        {
                            Console.WriteLine("Are you sure you want to remove all door access to this badge? \n" +
                                "You will be unable to restore original door access to this badge. User will have to manually enter doors. \n" +
                                "Press y to continue or n to return");
                            var userInput = Console.ReadLine().ToLower();
                            switch (userInput)
                            {
                                case "y":
                                    {
                                        _repository.WipeAllDoorsFromBadge(onebadge.BadgeId);
                                        Console.WriteLine("Door access for this badge has been cleared. \n" +
                                            "Press any key to continue");
                                        Console.ReadKey();
                                        break;
                                    }
                                case "n":
                                    {
                                        break;
                                    }
                                default:
                                    {
                                        Console.WriteLine("Please enter either y or n to choose an option...\n" +
                                            "Press any key to return..");
                                        Console.ReadKey();
                                        break;
                                    }
                            }

                            break;
                        }
                    case "4":
                        {
                            doorMiniMenu = false;
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Invalid response. \n" +
                                "Please enter either 1, 2, or 3 \n" +
                                "Press any key to continue....");
                            Console.ReadKey();
                            break;
                        }
                }

            }
        }
        public void ShowAllBadges()
        {
            var listOfBadges = _repository.ShowAllBadges();
            foreach (KeyValuePair<int, List<string>> kvp in listOfBadges)
            {
                Console.WriteLine("--------------------------------------");
                Console.WriteLine($"Badge: {kvp.Key}\n" +
                    $"Door Access List:");
                foreach (string value in kvp.Value)
                {
                    Console.WriteLine($"{value}");
                }
            }
            Console.WriteLine("Press any key to return to the menu.");
            Console.ReadKey();
        }
        public void AddBadge()
        {
            Console.WriteLine("Please enter the Badge ID..");
            var badgeID = int.Parse(Console.ReadLine());
            Console.WriteLine("Next, enter the first door this badge has access to");
            var doorList = new List<string>();
            doorList.Add(Console.ReadLine());
            bool addingDoors = true;
            while (addingDoors)
            {
                Console.WriteLine("Does this badge need access to another door?\n" +
                    "Please enter y or n");
                var userInput = Console.ReadLine().ToLower();
                switch (userInput)
                {
                    case "y":
                        {
                            Console.WriteLine("Please enter the next door number to provide access");
                            var doorNumber = (Console.ReadLine());
                            doorList.Add(doorNumber);
                            break;
                        }
                    case "n":
                        {
                            _repository.AddNewBadge(badgeID, doorList);
                            addingDoors = false;
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Please enter y or n \n" +
                                "Press any key to return..");
                            Console.ReadKey();
                            break;
                        }
                }

            }
        }
        public void SeedData()
        {
            _repository.AddNewBadge(012, new List<string> { "N01", "S01", "N02" });
            _repository.AddNewBadge(987, new List<string> { "W208", "W210", "E04" });
            _repository.AddNewBadge(654, new List<string> { "E911", "E03", "B575" });
            _repository.AddNewBadge(474, new List<string> { "N01", "W210", "E911" });
            _repository.AddNewBadge(00251, new List<string> { "S980", "S400", "S100" });
            _repository.AddNewBadge(1218, new List<string> { "SSC300", "N100", "E911" });
        }
    }
}
