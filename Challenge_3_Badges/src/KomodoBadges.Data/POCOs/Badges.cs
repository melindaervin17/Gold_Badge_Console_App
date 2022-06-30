using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

    public class Badges
    {
        public Badges(){}

        // public Badges(int id)
        // {
        //     ID = id;
        // }

        public Badges(/*int id,*/ Door doors)
        {
            // ID = id;
            Doors = doors;

        }

        public int ID { get; set; }

        public Door Doors { get; set; } 

        public int DoorID { get; set; }
    }
