using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

    public class Badges
    {
        public Badges(){}

        // public Badges(int badge)
        // {
        //     Badge = badge;
        // }

        public Badges(int id, string doors)
        {
            ID = id;
            Doors = doors;
        }
        
        // public int Badge { get; set; }

        public int ID { get; set; }

        public string Doors { get; set; } 
    }
