using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_3
{
    class Program
    {
        static void Main(string[] args)
        {
            OutingsRepository outingsRepo = new OutingsRepository();
            List<Outings> outingsList = outingsRepo.GetList();
            Outings royalPin = new Outings(EventType.Bowling, 15, "6/23/2018", 23.00m, 345.0m);
            Outings needToBreathe = new Outings(EventType.Concert, 6, "8/26/2018", 26.0m, 156.0m);
            Outings parThree = new Outings(EventType.Golf, 4, "7/31/2018", 15.0m, 60.0m);
            Outings pebbleBrooke = new Outings(EventType.Golf, 4, "6/30/2018", 25.0m, 100.0m);

            outingsRepo.AddToList(royalPin);
            outingsRepo.AddToList(needToBreathe);
            outingsRepo.AddToList(parThree);
            outingsRepo.AddToList(pebbleBrooke);

            string response = "0";
            while (response != "5")
            {
                Console.WriteLine($"What would you like to do?\n\n1. See all outings\n2. Add new outings to the list\n3. Determine total cost by outing type\n4. Determine current cost for all outstanding outings\n5. Exit Menu\n");
                response = Console.ReadLine();
                Console.Clear();

                if (response == "1")
                {
                    Console.Clear();
                    Console.WriteLine($"List of Outings\n\nOuting Type\tNumber Of People\tDate of Outing\t\tCost per Person\t\tTotal Cost");
                    foreach (Outings outing in outingsList)
                    {
                        Console.WriteLine($"{outing.Category}\t\t{outing.NumPpl} \t\t\t{outing.DateOfEvent}\t\t${outing.PerPersonCost}\t\t\t${outing.TotalEventCost}");
                    }
                    Console.WriteLine($"\nPress 'enter' to return to menu.");
                    Console.ReadLine();
                    Console.Clear();
                }

                if (response == "2")
                {
                    Outings outing = new Outings();
                    Console.WriteLine("Enter outing category: Golf = 1, Bowling = 2, Amusment Park = 3, Concert = 4, Other = 5");
                    string newCategory = Console.ReadLine();
                    int categoryInt = Int32.Parse(newCategory);
                    if (categoryInt == 1)
                    {
                        outing.Category = EventType.Golf;
                    }
                    if (categoryInt == 2)
                    {
                        outing.Category = EventType.Bowling;
                    }
                    if (categoryInt == 3)
                    {
                        outing.Category = EventType.AmusmentPark;
                    }
                    if (categoryInt == 4)
                    {
                        outing.Category = EventType.Concert;
                    }
                    if (categoryInt == 5)
                    {
                        outing.Category = EventType.Other;
                    }

                    Console.WriteLine("How manny people attended the event?");
                    outing.NumPpl = Int32.Parse(Console.ReadLine());

                    Console.WriteLine("When was the event? mm/dd/yyyy");
                    outing.DateOfEvent = Console.ReadLine();

                    Console.WriteLine("What was the cost per person?");
                    outing.PerPersonCost = Decimal.Parse(Console.ReadLine());
                    outing.TotalEventCost = outing.PerPersonCost * outing.NumPpl;
                    outingsRepo.AddToList(outing);

                    Console.WriteLine($"\nPress 'enter' to return to menu.");
                    Console.ReadLine();
                    Console.Clear();
                }

                if (response == "3")
                {
                    outingsRepo.GetList();
                    OutingsRepository totalCostRepo = new OutingsRepository();
                    List<Outings> listByType = totalCostRepo.GetList();
                    List<decimal> totalCostList = new List<decimal>();

                    Console.WriteLine("Enter desired outing type: Golf = 1, Bowling = 2, Amusment Park = 3, Concert = 4, Other = 5");
                    var desiredType = Int32.Parse(Console.ReadLine());

                    if (desiredType == 1)
                    {
                        
                        foreach (Outings outing in outingsList)
                        {
                            if (outing.Category == EventType.Golf)
                            {
                                totalCostRepo.AddToList(outing);
                            }
                        }
                        foreach (Outings outing in listByType)
                        {
                            totalCostList.Add(outing.TotalEventCost);
                        }
                        decimal desiredCost = totalCostList.Sum();
                        Console.WriteLine("Total cost of desired outing = " + desiredCost);
                    }
                    if (desiredType == 2)
                    {
                        foreach (Outings outing in outingsList)
                        {
                            if (outing.Category == EventType.Bowling)
                            {
                                totalCostRepo.AddToList(outing);
                            }
                        }
                        foreach (Outings outing in listByType)
                        {
                            totalCostList.Add(outing.TotalEventCost);
                        }
                        decimal desiredCost = totalCostList.Sum();
                        Console.WriteLine("Total cost of desired outing = " + desiredCost);
                    }
                    if (desiredType == 3)
                    {
                        foreach (Outings outing in outingsList)
                        {
                            if (outing.Category == EventType.AmusmentPark)
                            {
                                totalCostRepo.AddToList(outing);
                            }
                        }
                        foreach (Outings outing in listByType)
                        {
                            totalCostList.Add(outing.TotalEventCost);
                        }
                        decimal desiredCost = totalCostList.Sum();
                        Console.WriteLine("Total cost of desired outing = " + desiredCost);
                    }
                    if (desiredType == 4)
                    {
                        foreach (Outings outing in outingsList)
                        {
                            if (outing.Category == EventType.Concert)
                            {
                                totalCostRepo.AddToList(outing);
                            }
                        }
                        foreach (Outings outing in listByType)
                        {
                            totalCostList.Add(outing.TotalEventCost);
                        }
                        decimal desiredCost = totalCostList.Sum();
                        Console.WriteLine("Total cost of desired outing = " + desiredCost);
                    }
                    if (desiredType == 5)
                    {
                        foreach (Outings outing in outingsList)
                        {
                            if (outing.Category == EventType.Other)
                            {
                                totalCostRepo.AddToList(outing);
                            }
                        }
                        foreach (Outings outing in listByType)
                        {
                            totalCostList.Add(outing.TotalEventCost);
                        }
                        decimal desiredCost = totalCostList.Sum();
                        Console.WriteLine("Total cost of desired outing = " + desiredCost);
                    }
                    Console.WriteLine($"\nPress 'enter' to return to menu.");
                    Console.ReadLine();
                    Console.Clear();
                }

                if (response == "4")
                //Determine cost for all outstanding outings
                {
                    decimal sum = 0;
                    foreach (Outings outing in outingsList)
                    {
                        sum += outing.TotalEventCost;
                    }
                    Console.WriteLine("The outstanding total cost is: $" + sum);
                    Console.ReadLine();
                    Console.Clear();
                }
            }
        }
    }
}