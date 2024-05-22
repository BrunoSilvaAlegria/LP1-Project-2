using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YetAnotherDungeonCrawler
{
    /// <summary>
    /// This class is responsible for the creation
    /// of the dungeon and the rooms 
    /// /// </summary>
    public class Board
    {
        private int[,] board;
    /// <summary>
    /// This constructor is responsible for the size 
    /// of the dungeon in this case 3x3
    /// </summary>
    public Board()
    {
        board = new int[3, 3];
    }

    /// <summary>
    /// This method gives a value to each room
    /// </summary>
    /// <param name="row"></param>
    /// <param name="col"></param>
    /// <param name="value"></param>
    public void SetValue(int row, int col, int value)
    {
        if (IsValidPosition(row, col))
        {
            board[row, col] = value;
        }
        else
        {
            Console.WriteLine("Invalid position!");
        }
    }

    /// <summary>
    /// This method picks the value from the
    /// chosen room, in case an invalid room
    /// in case the selected room is chosen
    /// gives invalid 
    /// </summary>
    /// <param name="row"></param>
    /// <param name="col"></param>
    /// <returns></returns> <summary>
    /// 
    /// </summary>
    /// <param name="row"></param>
    /// <param name="col"></param>
    /// <returns></returns>
    public int GetValue(int row, int col)
    {
        if (IsValidPosition(row, col))
        {
            return board[row, col];
        }
        else
        {
            Console.WriteLine("Invalid position!");
            return -1; // Receber uma exceçao
        }
    }

    /// <summary>
    /// Method responsible for printing the dungeon
    /// </summary>
    public void PrintBoard()
    {
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                Console.Write(board[i, j] + " ");
            }
            Console.WriteLine();
        }
    }

    /// <summary>
    /// Method responsible for verifying valid position
    /// in the array
    /// </summary>
    /// <param name="row"></param>
    /// <param name="col"></param>
    /// <returns></returns> <summary>
    /// 
    /// </summary>
    /// <param name="row"></param>
    /// <param name="col"></param>
    /// <returns></returns>
    private bool IsValidPosition(int row, int col)
    {
        return row >= 0 && row < 3 && col >= 0 && col < 3;
    }
    }
}