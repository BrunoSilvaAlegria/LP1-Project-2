using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YetAnotherDungeonCrawler
{
    public class Player
    {
        public string Name { get; } //Name entered by player
        public int Health = 10; //Player's base life
        private int AttackPower = 2; //Player's base attack power

        public Player(string name)
        {
            Name = name;
        }
    }
}