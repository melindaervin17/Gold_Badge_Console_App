using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

    public class MenuRepo
    {
        private readonly List<Menu> _menuItems = new List<Menu>();

        public bool AddItemToMenu(Menu item)
        {
            int count = _menuItems.Count();
            _menuItems.Add(item);
            bool wasAdded = (_menuItems.Count() > count) ? true : false;

            return wasAdded;
        }

        public List<Menu> ViewMenuItems()
        {
            return _menuItems;
        }

        public bool DeleteMenuItems(Menu item)
        {
            bool deleteItem = _menuItems.Remove(item);
            return deleteItem;
        }
    }
