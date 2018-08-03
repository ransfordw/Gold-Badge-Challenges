using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_5
{
    class Program
    {

        //This challenge is not at all finished
        static void Main(string[] args)
        {
            CustomerRepository customerRepo = new CustomerRepository();
            List<Customer> customerList = customerRepo.GetCustomerList();

            Customer newCustomer = new Customer();
            Customer jim = new Customer("Jim", "Halpert", CustomerType.Current);
            Customer dwight = new Customer("Dwight", "Shrute", CustomerType.Potential);
            customerRepo.AddCustomerToList(jim);
            customerRepo.AddCustomerToList(dwight);

            int menuResponse = 0;
            while (menuResponse != 5)
            {
                //Sorts customerList alphabettically by last name.
                customerList.Sort(delegate (Customer customer1, Customer customer2) { return customer1.LastName.CompareTo(customer2.LastName); });

                Console.WriteLine($"Welcome to Komodo Insurance Customer Log!\n\nWhat would you like to do?\n\t1.See list of customers\n\t2.Add new customer\n\t3.Update current customer\n\t4.Delete current customer\n\t5.Exit program");
                menuResponse = int.Parse(Console.ReadLine());

                switch (menuResponse)
                {
                    case 1:
                        Console.WriteLine($"Here are all current customers:\nLast Name\tFirst Name\tCustomer Status\t\tSuggested Email");
                        foreach (Customer customer in customerList)
                        {
                            string email = "";
                            if (customer.CustomerType == CustomerType.Current)
                                email = "Thank you for your work with us. We appreciate your loyalty. Here's a coupon.";
                            if (customer.CustomerType == CustomerType.Past)
                                email = "It's been a long time since we've heard from you, we want you back!";
                            else email = " We currently have the lowest rates on Helicopter Insurance!";

                            Console.WriteLine($"{customer.LastName}\t\t{customer.FirstName}\t\t{customer.CustomerType}\t\t{email}");
                        }
                        Console.ReadLine();
                        break;
                    case 2:
                        Console.WriteLine($"Great! Let's add new customer info!\n\nPlease enter their first name:");
                        newCustomer.FirstName = Console.ReadLine();

                        Console.WriteLine("Please enter their last name: ");
                        newCustomer.LastName = Console.ReadLine();

                        Console.WriteLine("Please input customer status: Potential, Current, or Past");
                        var customerType = Console.ReadLine();
                        newCustomer.CustomerType = (CustomerType)Enum.Parse(typeof(CustomerType), customerType);
                        customerRepo.AddCustomerToList(newCustomer);
                        break;
                    case 3:
                        Console.WriteLine("Who would you like to update?");
                        var updateResponse = Console.ReadLine();
                        Console.WriteLine($"Would you like to:\n\t1. Change first name\n\t2.Change last name\n\t3.Change customer status");
                        var updateType = Console.ReadLine();
                        if (updateType == "1")

                         
                            break;
                    case 4:
                        //Only removes added customers. Not ones that are hard coded in.
                        Console.WriteLine($"Which customer would you like to remove?\n Enter First Name:");
                        var removeResponse = Console.ReadLine();
                        Console.WriteLine("Enter Last Name:");
                        var removeLast = Console.ReadLine();
                        if (newCustomer.FirstName == removeResponse && newCustomer.LastName == removeLast)
                        {
                            customerList.Remove(newCustomer);
                        }
                        break;
                    default:
                        menuResponse = 5;
                        break;



                }
            }
        }
    }
}