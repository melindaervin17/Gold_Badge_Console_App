using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

    public class Menu
    {
        public Menu(){}

        public Menu(int mealNum, string name, string description, string ingredients, double price)
        {
            MealNum = mealNum;
            Name = name;
            Description = description;
            Ingredients = ingredients;
            Price = price;
        }

        public int MealNum { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Ingredients { get; set; }
        public double Price { get; set; }
    }
