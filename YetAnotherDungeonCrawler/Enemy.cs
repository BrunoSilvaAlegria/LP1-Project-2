using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YetAnotherDungeonCrawler
{
    public class Enemy
    {
        public int Health { get; set; }
        public int AttackPower { get; set; }

        public Enemy()
        {
            Health = 10; // Enemy health 
            AttackPower = 3; // Enemy attack power 
        }
    }
}