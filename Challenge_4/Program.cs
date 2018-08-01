﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_4
{
    class Program
    {
        static void Main(string[] args)
        {
            Badge badge = new Badge();
            BadgeRepository badgeRepo = new BadgeRepository();
            //List<string> doorAccessList = badgeRepo.GetList();
            Dictionary<int, List<string>> BadgeID = badgeRepo.GetDictionary();


            int response = 0;
            while (response != 4)
            {
                Console.WriteLine($"Hello Security Admin!\n\nWhat would you like to do?\n\n1. Add a badge\n2. Edit a badge\n3. List all badges\n4. Exit program\n");
                int newResponse = Int32.Parse(Console.ReadLine());
                Console.Clear();
                if (newResponse == 1)
                {

                    Console.WriteLine("Enter badge ID number:");
                    badge.BadgeNum = Int32.Parse(Console.ReadLine());

                    List<String> _newDoorsFromConsole = new List<string>();
                    bool doorAddLoop = true;
                    while (doorAddLoop)
                    {
                        Console.WriteLine("Assign new door: (A5, B3, C2, ect.)");
                        var newDoor = Console.ReadLine();
                        _newDoorsFromConsole.Add(newDoor);

                        Console.WriteLine("Would you like to add another door? y/n");
                        var addDoorResponse = Console.ReadLine();

                        if (addDoorResponse == "n")
                            doorAddLoop = false;
                    }
                    badge.DoorList = _newDoorsFromConsole;
                    badgeRepo.AddBadgeToDictionary(badge);

                }
                if (newResponse == 2)
                {
                    Console.WriteLine("Which badge would you like to edit?");
                    var desiredKey = Int32.Parse(Console.ReadLine());
                    List<string> newDoorList = BadgeID[desiredKey];
                    var doorString = badgeRepo.ListToString(newDoorList);
                    Console.WriteLine($"Badge: {desiredKey} has access to doors {doorString}\n\n");
                    Console.WriteLine($"What would you like to change?\n\t1. Remove a door\n\t2. Add a door\n\t3. Change nothing");
                    var updateResponse = Int32.Parse(Console.ReadLine());
                    if (updateResponse == 1)
                    {
                        Console.WriteLine($"Badge: {desiredKey} has access to doors {doorString}\n\n");
                        string removeResponse = "y";
                        while (removeResponse != "n")
                        {

                            Console.WriteLine("Which door would you like to remove?");
                            var removeDoor = Console.ReadLine();
                            newDoorList.Remove(removeDoor);
                            Console.WriteLine("Would you like to remove another door? y/n");
                            removeResponse = Console.ReadLine();
                        }
                    }
                    else while (updateResponse == 2)
                        {
                            Console.WriteLine("Enter door to be added.");
                            var newDoor = Console.ReadLine();
                            newDoorList.Add(newDoor);
                            //Console.WriteLine($"Badge: {desiredKey} now has access to doors {doorString}\n\n");
                            Console.WriteLine("Would you like to add another door? y/n");
                            var newDoorResponse = Console.ReadLine();
                            if (newDoorResponse == "y")
                            updateResponse = 2;
                            else updateResponse = 4;
                        }
                }
                if (newResponse == 3)
                {
                    Console.WriteLine($"Here is a list of current badges: \n\nBadge ID number\t\tDoor Access\n");

                    foreach (KeyValuePair<int, List<string>> newBadgeID in BadgeID)
                    {
                        var doorString = badgeRepo.ListToString(newBadgeID.Value);
                        Console.WriteLine($"{newBadgeID.Key}\t\t{doorString}");
                    }
                    Console.ReadLine();
                }if (newResponse == 4)
                break;
            }
        }
    }
}