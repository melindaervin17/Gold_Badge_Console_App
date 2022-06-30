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

        public Menu GetItemByNum(int mealNum)
        {
            foreach (Menu m in _menuItems)
            {
                if (m.MealNum == mealNum)
                {
                    return m;
                }
            }
            return null;
        }

        public bool DeleteMenuItems(int mealNum)
        {
            var item = GetItemByNum(mealNum);
            if(item != null)
            {
                _menuItems.Remove(item);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
