using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

    public class MenuRepo
    {
        private readonly List<Menu> _menuItems = new List<Menu>();

        private int _count;
        public bool AddItemToMenu(Menu item)
        {
            // int startCount = _menuItems.Count();
            // _menuItems.Add(item);
            // bool wasAdded = (_menuItems.Count() > startCount) ? true : false;

            // return wasAdded;
            if(item != null)
            {
                _count++;
                item.MealNum = _count;
                _menuItems.Add(item);
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<Menu> GetAllItems()
        {
            return _menuItems;
        }

        public bool DeleteMenuItems(Menu item)
        {
            bool deleteItem = _menuItems.Remove(item);
            return deleteItem;
        }
    }
