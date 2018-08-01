using System;
using Challenge_1;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Challenge_Tests
{
    [TestClass]
    public class Challenge_1_Tests
    {
        private MenuRepository menuItems;

        [TestInitialize]
        public void Arrange()
        {
            menuItems = new MenuRepository();
        }

        [TestMethod]
        public void MenuRepository_AddItemToMenu_ShouldIncreaseCountByOne()
        {
            MenuItem meal = new MenuItem(1, "Broccoli", "Steamed Broccoli", "Broccoli, butter, spices", 2.0m);
            menuItems.AddItemToMenu(meal);

            var actual = menuItems.ProduceMenu().Count;
            var expected = 1;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void MenuRepository_RemoveItemFromMenu_ShouldReduceCountByOne()
        {
            MenuItem meal = new MenuItem(1, "Broccoli", "Steamed Broccoli", "Broccoli, butter, spices", 2.0m);
            MenuItem mealTwo = new MenuItem(2, "Corn", "Steamed corn", "corn, butter, spices", 2.0m);
            menuItems.AddItemToMenu(meal);
            menuItems.AddItemToMenu(mealTwo);

            menuItems.RemoveItemFromMenu(meal);
            var actual = menuItems.ProduceMenu().Count;
            var expected = 1;

            Assert.AreEqual(expected, actual);
        }

        /*[TestMethod]
    public void MenuItem_MenuItemMealNumber_ShouldBeSetToInt()
    {
        //Arrange
        MenuItem meal = new MenuItem(1, "Broccoli", "Steamed Broccoli", "Broccoli, butter, spices", 2.0m);

        //Act
        int actual = meal.MealNumber;
        int expected = 1;

        //Assert
        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void MenuItem_MenuItemMealName_ShouldBeSetToString()
    {
        //Arrange
        MenuItem meal = new MenuItem(1, "Broccoli", "Steamed Broccoli", "Broccoli, butter, spices", 2.0m);

        //Act
        string actual = meal.MealName;
        string expected = "Broccoli";

        //Assert
        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void  MenuItem_MenuDescription_ShouldBeSetToString ()
    {
        //Arrange
        MenuItem meal = new MenuItem(1, "Broccoli", "Steamed Broccoli", "Broccoli, butter, spices", 2.0m);

        //Act
        string actual = meal.Description;
        string expected = "Steamed Broccoli";

        //Assert
        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void MenuItem_MealIngredients_ShouldBeSetToString ()
    {
        //Arrange
        MenuItem meal = new MenuItem(1, "Broccoli", "Steamed Broccoli", "Broccoli, butter, spices", 2.0m);

        //Act
        string actual = meal.Ingredients;
        string expected = "Broccoli, butter, spices";

        //Assert
        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void MenuItem_MealPrice_ShouldBeSetToDecimal ()
    {
        //Arrange
        MenuItem meal = new MenuItem(1, "Broccoli", "Steamed Broccoli", "Broccoli, butter, spices", 2.0m);

        //Act
        decimal actual = meal.MealPrice;
        decimal expected = 2.0m;

        //Assert
        Assert.AreEqual(expected, actual);
    }
}*/
    }
}