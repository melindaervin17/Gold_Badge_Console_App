using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

    public class DoorList
    {
        private readonly List<Doors> _doorRepo = new List<Doors>();

        public bool UpdateBadgeAccess(int badgeID, BadgeDictionary newBadgeData)
        {
            var oldBadgeData = GetBadgeByID(badgeID);

            if(oldBadgeData != null)
            {
                oldBadgeData.Doors = newBadgeData.Doors;
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool DeleteBadgeAccess()
        {

        }

        public bool ViewAllBadges()
        {
            
        }
    }
