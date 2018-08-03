using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_1
{
    public class Program
    {
        static void Main(string[] args)
        {
            MenuRepository menuList = new MenuRepository();
            List<MenuItem> menuItems = menuList.ProduceMenu();
            MenuItem arrozConPollo = new MenuItem(1, "Arroz con Pollo", "Mexican rice with grilled chicken and white cheese.", "Rice, Chicken, Cheese, Spices.", 12.0m);
            MenuItem macNCheese = new MenuItem(2, "Mac N' Cheese", "Kraft macaroni and cheese", "Macaroni pasta, milk, butter, powdered cheese mix.", 1.50m);
            MenuItem hambuger = new MenuItem(3, "Flame-grilled Hamburger", "Delicious burger grilled over open flame lightly seasoned.", "Ground beef, brioche bun, sal, pepper, rosemary, butter.", 14.0m);

            menuList.AddItemToMenu(arrozConPollo);
            menuList.AddItemToMenu(macNCheese);
            menuList.AddItemToMenu(hambuger);
           
            string response = "0";
            while (response != "4")
            {
                
                Console.WriteLine($"Menu Options \n 1. Add Menu Item \n 2. Remove Menu Item \n 3. Print Menu \n 4. Finish");
                response = Console.ReadLine();
                Console.Clear();
                if (response == "1")
                {
                    Console.Clear();
                    Console.WriteLine("Menu item number: ");
                    var number = Console.ReadLine();
                    var mealNum = Int32.Parse(number);

                    Console.WriteLine("Meal name: ");
                    string mealName = Console.ReadLine();

                    Console.WriteLine("Meal description: ");
                    var description = Console.ReadLine();

                    Console.WriteLine("Meal price: ");
                    string priceString = Console.ReadLine();
                    decimal price = decimal.Parse(priceString);

                    bool ingredientsLoop = true;

                    List<String> _ingredientsFromConsole = new List<string>();

                    while (ingredientsLoop)
                    {
                        Console.WriteLine("Name an ingredient: ");
                        var ingredient = Console.ReadLine();
                        _ingredientsFromConsole.Add(ingredient);

                        Console.WriteLine("Would you like to add another ingredient? y/n");
                        var addIngredientResponse = Console.ReadLine();

                        if (addIngredientResponse == "n")
                            ingredientsLoop = false;
                    }

                    StringBuilder builder = new StringBuilder();
                    foreach (string ingredient in _ingredientsFromConsole)
                    {
                        builder.Append(ingredient).Append(", ");
                    }
                    builder.Length -= 2;
                    string result = builder.ToString();

                    MenuItem newMenuItem = new MenuItem()
                    {
                        MealNumber = mealNum,
                        MealName = mealName,
                        Description = description,
                        Ingredients = result,
                        MealPrice = price
                    };
                    menuList.AddItemToMenu(newMenuItem);
                    Console.Clear();
                }
                else if (response == "2")
                {
                    Console.Clear();
                    Console.WriteLine("Which item number should be removed?");
                    var removalNum = Int32.Parse(Console.ReadLine());
                    foreach (MenuItem meal in menuItems)
                    {
                        if (meal.MealNumber == removalNum)
                        {
                            menuList.RemoveItemFromMenu(meal);
                            break;
                        }
                    }
                    Console.Clear();
                }
                else if (response == "3")
                {
                    foreach (MenuItem meal in menuItems)
                    {
                        Console.WriteLine($"Menu item: {meal.MealName} \n Meal Number:  {meal.MealNumber} \n Description: {meal.Description} \n Ingredients: {meal.Ingredients} \n Price: {meal.MealPrice}");
                    }
                    Console.WriteLine("Press 'Enter' to return to menu.");
                    Console.ReadLine();
                    Console.Clear();
                }
            }
        }
    }

}