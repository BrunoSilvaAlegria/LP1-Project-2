using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YetAnotherDungeonCrawler
{
    /// <summary>
    /// Class responsible for
    /// creating Enemy
    /// </summary>
    public class Enemy
    {
        public int Health { get; set; }
        public int AttackPower { get; set; }
         /// <summary>
        /// Set Enemy Health and Attack Power 
        /// accordingly to the wanted values
        /// </summary>
        public Enemy(int health, int attackPower)
        {
            Health = health; 
            AttackPower = attackPower; 
        }
    }
}