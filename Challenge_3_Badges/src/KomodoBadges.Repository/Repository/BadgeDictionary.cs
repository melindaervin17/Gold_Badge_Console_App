using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

    public class BadgeDictionary
    {
        private readonly Dictionary<id, Doors> _dictionaryRepo = new Dictionary<id, Doors>();

        private int _count = 0;

        public bool AddBadgeToDictionary(Badges badge)
        {
            if(badge is null)
            {
                return false;
            }

            _count++;
            badge.ID = _count;
            _dictionaryRepo.Add(badge.ID, badge);

            return true;
        }

                public bool UpdateBadgeInfo(int ID, BadgeDictionary newBadgeInfo)
        {
            var oldBadgeInfo = GetBadgeByID(id);

            if(oldBadgeInfo != null)
            {
                oldBadgeInfo.Doors = newBadgeInfo.Doors;
                return true;
            }
            else
            {
                return false;
            }
        }

        public Dictionary<id, Doors> ListAllBadges()
        {
            return _dictionaryRepo;
        }
    }
