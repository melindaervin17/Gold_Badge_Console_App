using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

    public class Badges
    {
        public Badges(){}

        public Badges(Door doors)
        {
            Doors = doors;

        }

        public int ID { get; set; }

        public Door Doors { get; set; } 

        public int DoorID { get; set; }
    }
