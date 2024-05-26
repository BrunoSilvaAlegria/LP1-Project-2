using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YetAnotherDungeonCrawler
{
    /// <summary>
    /// Class responsible for
    /// creating Item
    /// </summary>
    public class Item
    {
        public string Name { get; set; } = "Healing Potion";
        public int Healing { get; set; }

        /// <summary>
        /// Set Item Healing Power
        /// and Name
        /// </summary>
        public Item(string name, int healing)
        {
            Name = name;
            Healing = healing;
        }  
    }
}