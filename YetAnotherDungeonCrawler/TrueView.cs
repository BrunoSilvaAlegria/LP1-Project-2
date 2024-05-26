using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YetAnotherDungeonCrawler
{
    public class TrueView : IView //Extends IView interface
    {
        private readonly Controller controller;
        private Player player;
        private Enemy enemy;

        public TrueView(Controller controller, Player player)
        {
            this.controller = controller;
            this.player = player;
        }

        public string DisplayMessage(string message)
        {
            return message;
        }

        public void MainMenu()
        {            
            Console.WriteLine("\ud83d\udde1\ufe0f Welcome to the dungeon adventurer! \ud83e\uddd9");
            Console.Write("You are in a dark room and need to find an exit!");
            Console.WriteLine("Explore the dungeon to find it.");
            Console.Write("But be careful, you're not alone in here...");
            Console.WriteLine("Defeat the enemies to continue your adventure!");
            Console.WriteLine("Also, be sure to search the rooms for items that" +
            " may help you on your journey");
            Console.WriteLine("Good Luck\n");
            Console.WriteLine("--------------------------------------------\n");
        }
        public string Choice()
        {
            Console.WriteLine("You have this available actions: ");
            Console.WriteLine("\nMove\nSearch\nUse Item\nAttack\nQuit");
            Console.WriteLine("What will you do?");
            return Console.ReadLine();
        }
        public void EndMessage()
        {
            Console.WriteLine("Thank You For Playing!");
        }
        public void InvalidAction()
        {
            Console.Error.WriteLine("Unknown action! Please try again.\n");
        }
        public void PlayerAttack()
        {
            Console.WriteLine($"You attacked the enemy and dealt {player.AttackPower} damage.");
        }
        public void EnemyAttack()
        {
            Console.WriteLine($"The enemy attacked you and dealt {enemy.AttackPower} damage.");
        }
        public void PlayerDeath()
        {
            Console.WriteLine("You have been defeated by the enemy.\n GAME OVER!");
        }
        public void EnemyDeath()
        {
            Console.WriteLine("You have defeated the enemy!");
        }

        public string Directions()
        {
            Console.WriteLine("In what direction would you like to go?");
            return Console.ReadLine();
        }
        
        public void CannotMoveThatWay()
        {
            Console.WriteLine("You cannot move that way.");
        }
        public string GetUserInput()
        {
            return Console.ReadLine();
        }
        public void EnemyDetection()
        {
            Console.WriteLine("There is an enemy in this room.");
        }
        public void NoEnemy()
        {
            Console.WriteLine("There is no enemy to attack.");
        }
        public void ItemFound()
        {

        }
        public void ItemNotFound()
        {
            Console.WriteLine("There is no item to be found here.");
        }

    }
}