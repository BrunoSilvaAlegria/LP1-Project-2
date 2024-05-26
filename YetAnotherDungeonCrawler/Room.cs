using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YetAnotherDungeonCrawler
{
    /// <summary>
    /// Class responsible for creating each Room
    /// with exits, enemy or item
    /// </summary>
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

        /// <summary>
        /// Constructor responsible for giving position for
        /// the room and checking exits, enemy and item  
        /// </summary>
        public Room(int x, int y, bool northExit, bool southExit, bool eastExit, bool westExit, bool hasEnemy, Item roomItem)
        {
            X = x;
            Y = y;

            NorthExit = northExit;
            SouthExit = southExit;
            EastExit = eastExit;
            WestExit = westExit;

            HasEnemy = hasEnemy;
            RoomItem = roomItem;
        }
        /// <summary>
        /// Method responsible for removing Enemy
        /// </summary>
        public void RemoveEnemy()
        {
            HasEnemy = false;
        }

        /// <summary>
        /// Method responsible for removing Item
        /// </summary>
        public void RemoveItem()
        {
            RoomItem = null;
        }
    }
}