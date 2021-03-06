﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_4
{
    public class BadgeRepository
    {
        private List<string> _doorAccessList = new List<string>();
        private Dictionary<int, List<string>> BadgeID = new Dictionary<int, List<string>>();

        public List<string> GetList()
        {
            return _doorAccessList;
        }

        public void AddDoorToList(string door)
        {
            _doorAccessList.Add(door);
        }

        public void RemoveDoorFromList (string door)
        {
            _doorAccessList.Remove(door);
        }

        public void AddBadgeToDictionary (Badge badge)
        {
            BadgeID.Add(badge.BadgeNum, badge.DoorList);
        }

        public Dictionary< int, List<string>>  GetDictionary()
        {
            return BadgeID;
        }

        public string ListToString(List<string>doorString)
        {
            StringBuilder builder = new StringBuilder();
            foreach (string door in doorString)
            {
                builder.Append(door).Append(", ");
            }
            builder.Length -= 2;
            string result = builder.ToString();
            return result;
        }
    }
}