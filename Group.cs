using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grupp_ja_liikmed
{
    class Group
    {
        public List<string> Members { get; } = new List<string>();
        private int MaxSpaces { get; }
        private List<Liik> AllCandidates { get; }

        public Group(int maxSpaces, List<Liik> allCandidates)
        {
            MaxSpaces = maxSpaces;
            AllCandidates = allCandidates;
        }

        public bool AddMember(string name, int age)
        {
            if (Members.Count < MaxSpaces && !Members.Contains(name))
            {
                Members.Add(name);
                return true;
            }
            return false;
        }

        public bool HasAvailableSpace()
        {
            return Members.Count < MaxSpaces;
        }

        public string GetOldestMember()
        {
            if (Members.Count == 0)
            {
                return "No members in the group.";
            }

            int maxAge = 0;
            string oldestMember = "";

            foreach (var memberName in Members)
            {
                var candidate = AllCandidates.FirstOrDefault(x => x.Name == memberName);
                if (candidate != null && candidate.Age > maxAge)
                {
                    maxAge = candidate.Age;
                    oldestMember = candidate.Name;
                }
            }

            return $"The oldest member is {oldestMember} with an age of {maxAge} years.";
        }
    }
}