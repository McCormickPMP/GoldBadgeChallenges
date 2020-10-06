using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Badges_Classes
{
    public class Badge
    {
        public int BadgeId { get; set; }
        //ICollection allows me to use in foreach 
        public ICollection<string> DoorId { get; set; }
        public Badge() { }
        public Badge(int badgeId, ICollection<string> doorId)
        {
            BadgeId = badgeId;
            DoorId = doorId;
        }
    }
}
