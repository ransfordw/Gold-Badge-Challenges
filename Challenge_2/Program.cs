using System;
using System.Collections.Generic;
using static Challenge_2.Claims;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_2
{
    class Program
    {
        static void Main(string[] args)
        {
            ClaimsRepository claimsRepo = new ClaimsRepository();
            Queue<Claims> claimsQueue = claimsRepo.GetClaims();

            Claims bob = new Claims(1, TypeOfClaim.Car, "Accident on 65", 500.0m, "7/29/2018", "5/22/2018", false);
            Claims sue = new Claims(2, TypeOfClaim.Car, "Flat tire", 125.0m, "7/25/2018", "6/30/2018", true);
            claimsRepo.AddClaimToQueue(bob);
            claimsRepo.AddClaimToQueue(sue);

            Console.WriteLine("Main Menu");
            string response = "0";
            while (response != "4")
            {
                Console.Clear();
                Console.WriteLine($"1. See All Claims \n2. See Next Claim \n3. Enter New Claim \n4. Exit Menu");
                response = Console.ReadLine();

                if (response == "1")
                {
                    Console.Clear();
                    claimsRepo.GetClaims();

                    Console.WriteLine($"Claim ID# \t Type of claim \t Amount \t Date of Incident \t Date of Claim \t Is Valid \t Description");
                    foreach (Claims claim in claimsQueue)
                    {
                        Console.WriteLine($"{claim.ClaimID} \t\t {typeof(TypeOfClaim).GetEnumName(claim.Category)}\t\t ${claim.ClaimAmount} \t {claim.IncidentDate} \t\t {claim.ClaimDate} \t {claim.IsValid} \t\t {claim.Description}");
                    }
                    Console.WriteLine($"\nPress 'Enter' to return to menu.");

                    Console.ReadLine();
                }
                if (response == "2")
                {
                    Console.Clear();
                    Console.WriteLine($"{claimsQueue.Peek()}\n");
                    Console.WriteLine("Do you want to address this now? y/n");
                    string handleClaim = Console.ReadLine();

                    if (handleClaim == "y")
                    {
                        claimsRepo.RemoveQueueItem();
                    }
                    Console.Clear();
                }
                if (response == "3")
                {
                    Console.WriteLine("Enter new claim number: ");
                    var number = Console.ReadLine();
                    var id = Int32.Parse(number);

                    Console.WriteLine("Enter claim type: 1 = Car, 2 = Home, 3 = Theft, 4 = Other");
                    var newClaimType = Console.ReadLine();
                    var newClaimTypeInt = Int32.Parse(newClaimType);
                    TypeOfClaim type;
                    if (newClaimTypeInt == 1)
                    {
                        type = TypeOfClaim.Car;
                    }
                    if (newClaimTypeInt == 2)
                    {
                        type = TypeOfClaim.Home;
                    }
                    if (newClaimTypeInt == 3)
                    {
                        type = TypeOfClaim.Theft;
                    }
                    else
                        type = TypeOfClaim.Other;

                    Console.WriteLine("Describe the claim: ");
                    var description = Console.ReadLine();

                    Console.WriteLine("How much will the claim cost?");
                    var newAmount = Console.ReadLine();
                    decimal amount = Decimal.Parse(newAmount);

                    Console.WriteLine("When did the incident happen? mm/dd/yyyy");
                    var incidentDate = Console.ReadLine();

                    Console.WriteLine("When was the claim filed? mm/dd/yyyy");
                    var claimDate = Console.ReadLine();

                    Claims claim = new Claims();
                    {
                        claim.ClaimID = id;
                        claim.Category = type;
                        claim.Description = description;
                        claim.ClaimAmount = amount;
                        claim.ClaimDate = claimDate;
                        claim.IncidentDate = incidentDate;
                        claim.IsValid = claim.GetBoolean(claim);
                    }
                    claimsRepo.AddClaimToQueue(claim);
                }
                if (response == "4")
                {
                    break;
                }
            }
        }
    }
}
