using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YetAnotherDungeonCrawler
{
    /// <summary>
    /// Class responsible for registering Player
    /// information, such as, Health Points,
    /// Attack Power and Inventory
    /// </summary>
    public class Player
    {
        public int Health { get; set; }
        public int AttackPower { get; set; }
        public List<Item> Inventory { get; private set; }

        /// <summary>
        /// Set Player Health, Attack Power
        /// and Inventory List
        /// </summary>
        public Player()
        {
            Health = 30;
            AttackPower = 10; 
            Inventory = new List<Item>();
        }

        /// <summary>
        /// Method responsible for adding items
        /// in inventory
        /// </summary>
        public void AddItemToInventory()
        {
            Item healthPotion = new Item("Health Potion", 10); 
            Inventory.Add(healthPotion);
        }
        /// <summary>
        /// Method responsible for using item
        /// inside the inventory
        /// </summary>
        /// <param name="item"></param>
        public void UseItem(Item item)
        {
            Health += item.Healing;
            Inventory.Remove(item);
        }
    }
}
