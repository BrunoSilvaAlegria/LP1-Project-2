using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;

namespace YetAnotherDungeonCrawler
{
    /// <summary>
    /// This class is responsible for the creation
    /// of the dungeon and the rooms 
    /// /// </summary>
    public class Board
    {
        public Room[,] Rooms { get; private set; } //Stores the rooms

        public Board(string filePath)
        {
            Rooms = new Room[3, 3];
            ReadBoardData(filePath);
        }
        /// <summary>
        /// Method responsible for reading the rooms description file and
        /// constructing the board.
        /// The information of the text file is given in this order:
        /// X,Y,NorthExitAvailable,SouthExitAvailable,EastExitAvailable,
        /// WestExitAvailable,HasEnemy,HasItem
        /// </summary>
        /// <param name="filePath"></param>
        private void ReadBoardData(string filePath)
        {
            //Reads the rooms.txt file
            using (StreamReader sr = new StreamReader(filePath)) 
            {
                string line  = sr.ReadLine(); //Reads each line of the text file
                while (line != null)
                {
                    //Splits the room information by commas(,)
                    //The information is 
                    string[] roomParts = line.Split(',');           

                    int x = int.Parse(roomParts[0]); //First component of the line
                    int y = int.Parse(roomParts[1]); //Second component of the line
                    bool northExit = roomParts[2] == "1"; //Third component of the line
                    bool southExit = roomParts[3] == "1"; //Fourth component of the line
                    bool eastExit = roomParts[4] == "1"; //Fifth component of the line
                    bool westExit = roomParts[5] == "1"; //Sixth component of the line
                    bool hasEnemy = roomParts[6] == "1"; //Seventh component of the line
                    bool hasItem = roomParts[7] == "1"; //Last component of the line

                    //Starts has null, with the room not having an item
                    Item roomItem = null; 
                    if (hasItem) //Sees if there is an item
                    {
                        roomItem = new Item("Health Potion", 10); //Creates the item
                    }
                    //Creates each room with the given description
                    Rooms[x, y] = new Room(x, y, northExit, southExit, eastExit,
                     westExit, hasEnemy, roomItem);
                }
            }
        }
    }
}
