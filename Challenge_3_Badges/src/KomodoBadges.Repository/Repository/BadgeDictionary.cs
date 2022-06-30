using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

    public class BadgeDictionary
    {
        private readonly Dictionary<int, Badges> _dictionaryRepo = new Dictionary<int, Badges>();

        private readonly List<Badges> _listRepo = new List<Badges>();

        private readonly List<Door> _doorList = new List<Door>();

        private int _count;

        public bool AddBadgeToDictionary(Badges badge)
        {
            if(badge != null)
            {
            _count++;
            badge.ID = _count;
            _dictionaryRepo.Add(badge.ID, badge);

            return true;
            }
            else
            {
            return false;
            }
        }

        public Dictionary<int, Badges> GetBadge()
        {
            return _dictionaryRepo;
        }

        public Dictionary<int, Badges> GetAllBadges()
        {
            return _dictionaryRepo;
        }
        public Badges GetBadgeByKey(int keyInput)
        {
            foreach(KeyValuePair<int, Badges> badge in _dictionaryRepo)
            {
                if(badge.Key == keyInput)
                {
                    return badge.Value;
                }
            }
            return null;
        }

        public bool UpdateBadgeInfo(int keyInput, Badges newBadgeInfo)
        {
            var oldBadgeInfo = GetBadgeByKey(keyInput);

            if(oldBadgeInfo is null)
            {
                return false;
            }
                oldBadgeInfo.Doors = newBadgeInfo.Doors;
                return true;
            // else
            // {
            //     return false;
            // }
        }

        public Dictionary<int, Badges> ListAllBadges()
        {
            return _dictionaryRepo;
        }

        public List<Door> GetDoor()
        {
            return _doorList;
        }

        public bool AddDoorAccess(Door doors)
        {
            if(doors != null)
            {
                _doorList.Add(doors);
                return true;
            }

            return false;
        }
    }
