using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;

namespace YetAnotherDungeonCrawler
{
    public class Board
    {
        public Room[,] Rooms { get; private set; }

        public Board(string filePath)
        {
            Rooms = new Room[3, 3];
            ReadBoardData(filePath);
        }

        private void ReadBoardData(string filePath)
        {
            using (StreamReader sr = new StreamReader(filePath))
            {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] parts = line.Split(',');
                        if (parts.Length != 8)
                        {
                            //Console.WriteLine("Error: Line does not contain exactly 8 values.");
                            continue;
                    }

                    int x = int.Parse(parts[0]);
                    int y = int.Parse(parts[1]);
                    bool northExit = parts[2] == "1";
                    bool southExit = parts[3] == "1";
                    bool eastExit = parts[4] == "1";
                    bool westExit = parts[5] == "1";
                    bool hasEnemy = parts[6] == "1";
                    bool hasItem = parts[7] == "1";

                    Item roomItem = null;
                    if (hasItem)
                    {
                        roomItem = new Item("Health Potion", 10); // Fixed item for all rooms that contain an item
                    }
                    Rooms[x, y] = new Room(x, y, northExit, southExit, eastExit, westExit, hasEnemy, roomItem);
                    Console.WriteLine($"Created room at ({x},{y}) with northExit: {northExit}, southExit: {southExit}, eastExit: {eastExit}, westExit: {westExit}, hasEnemy: {hasEnemy}, hasItem: {hasItem}");
                }
            }
        }
    }
}
