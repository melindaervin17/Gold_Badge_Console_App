using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

    public class Badges
    {
        public Badge(){}

        public Badge(int badgeID, List<Door> doors)
        {
            BadgeID = badgeID;
            Doors = doors;
        }

        public int BadgeID { get; set; }

        public List<Door> Doors { get; set; } 
    }
