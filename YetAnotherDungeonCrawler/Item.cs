using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YetAnotherDungeonCrawler
{
    public class Item
    {
        public string Name { get; set; }
        public int Healing { get; set; }

        public Item(string name, int healing)
        {
            Name = name;
            Healing = healing;
        }  
    }
}