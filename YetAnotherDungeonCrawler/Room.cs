using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YetAnotherDungeonCrawler
{
    public class Room
    {
    private int[,] board;

    public Board()
    {
        // Inicializar um board 3x3
        board = new int[3, 3];
    }

    // Atribuir Valores ao Board
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

    // Receber um Valor do Board
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

    // Print Board
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

    // Metodo para ver se uma posiçao e valida
    private bool IsValidPosition(int row, int col)
    {
        return row >= 0 && row < 3 && col >= 0 && col < 3;
    }

    }
}