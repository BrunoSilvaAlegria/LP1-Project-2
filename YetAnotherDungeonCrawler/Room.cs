using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YetAnotherDungeonCrawler
{
    public class Room
    {
        public int X { get; private set; }
        public int Y { get; private set; }
        public bool NorthExit { get; private set; }
        public bool SouthExit { get; private set; }
        public bool EastExit { get; private set; }
        public bool WestExit { get; private set; }
        public bool HasEnemy { get; private set; }
        public Item RoomItem { get; private set; }

        public Room(int x, int y, bool northExit, bool southExit, bool eastExit, bool westExit, bool hasEnemy, Item roomItem)
        {
            X = x; 
            Y = y;

            // Checks for an exit in a chosen direction
            NorthExit = northExit;
            SouthExit = southExit;
            EastExit = eastExit;
            WestExit = westExit;

            HasEnemy = hasEnemy; // Checks for the presence of an enemy
            RoomItem = roomItem; // Checks for the presence of an item
        }

        public void RemoveEnemy()
        {
            HasEnemy = false;
        }

        public void RemoveItem()
        {
            RoomItem = null;
        }
    }
}