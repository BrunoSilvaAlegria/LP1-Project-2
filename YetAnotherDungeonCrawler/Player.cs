using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YetAnotherDungeonCrawler
{
    /// <summary>
    /// Class responsible for registering Player
    /// information, such as, Name, Health Points,
    /// Attack Power and Inventory
    /// </summary>
    public class Player
    {
        public int Health { get; set; }
        public int AttackPower { get; set; }
        public List<Item> Inventory { get; private set; }

        public Player()
        {
            Health = 20; // Player health 
            AttackPower = 5; // Player attack power 
            Inventory = new List<Item>();
        }

        public void AddItemToInventory()
        {
            //Health Potion restores 10 health
            Item healthPotion = new Item("Health Potion", 10); 
            Inventory.Add(healthPotion);
        }

        public void UseItem(Item item)
        {
            Health += item.Healing;
            Inventory.Remove(item);
        }
    }
}
