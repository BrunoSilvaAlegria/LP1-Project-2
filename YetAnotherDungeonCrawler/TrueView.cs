using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YetAnotherDungeonCrawler
{
    /// <summary>
    /// Class responsible for IView Outputs
    /// </summary>
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
        /// <summary>
        /// Method responsible for displaying message
        /// </summary>
        public string DisplayMessage(string message)
        {
            return message;
        }

        /// <summary>
        /// Method responsible for printing Main Menu
        /// </summary>
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
        /// <summary>
        /// Method responsible for Player Choice
        /// </summary>
        public string Choice()
        {
            Console.WriteLine("You have this available actions: ");
            Console.WriteLine("\nMove\nSearch\nUse Item\nAttack\nQuit");
            Console.WriteLine("What will you do?\n");
            Console.Write("> ");
            return Console.ReadLine().ToLower(); //Makes the player's input into lowercase
        }
        /// <summary>
        /// Method responsible for End Game message
        /// </summary>
        public void EndMessage()
        {
            Console.WriteLine("Thank You For Playing!");
        }
        /// <summary>
        /// Method responsible for printing error message
        /// when Player give Invalid Option
        /// </summary>
        public void InvalidAction()
        {
            Console.Error.WriteLine("Unknown action! Please try again.\n");
        }
        /// <summary>
        /// Method responsible for printing attack message
        /// when Player attacks
        /// </summary>
        public void PlayerAttack()
        {
            Console.WriteLine($"You attacked the enemy and dealt {player.AttackPower} damage.");
        }
        /// <summary>
        /// Method responsible for for printing enemy attack
        /// when attacked by an Enemy
        /// </summary>
        public void EnemyAttack()
        {
            Console.WriteLine($"The enemy attacked you and dealt {enemy.AttackPower} damage.");
        }
        /// <summary>
        /// Method responsible for printing Death message
        /// when Player dies
        /// </summary>
        public void PlayerDeath()
        {
            Console.WriteLine("You have been defeated by the enemy.\n GAME OVER!");
        }
        /// <summary>
        /// Method responsible for printing Enemy's death
        /// message
        /// </summary>
        public void EnemyDeath()
        {
            Console.WriteLine("You have defeated the enemy!");
        }
        /// <summary>
        /// Method responsible for asking which direction
        /// Player wants to go
        /// </summary>
        public string Directions()
        {
            Console.WriteLine("In what direction would you like to go?");
            return Console.ReadLine();
        }
        /// <summary>
        /// Method responsible for printing invalid
        /// direction
        /// </summary>
        public void CannotMoveThatWay()
        {
            Console.WriteLine("You cannot move that way.");
        }
        /// <summary>
        /// Method responsible for registering Player Input
        /// </summary>
        /// <returns></returns>
        public string GetUserInput()
        {
            return Console.ReadLine();
        }
        /// <summary>
        /// Method responsible for telling Enemy 
        /// presence in Room if true
        /// </summary>
        public void EnemyDetection()
        {
            Console.WriteLine("There is an enemy in this room.");
        }
        /// <summary>
        /// Method responsible for detecting no Enemy
        /// presence in room
        /// </summary>
        public void NoEnemy()
        {
            Console.WriteLine("There is no enemy to attack.");
        }
        /// <summary>
        /// Method responsible for telling Item 
        /// presence in Room if true
        /// </summary>
        public void ItemFound()
        {
            Console.WriteLine($"You found an item: Healing Potion!");
        }
        /// <summary>
        /// Method responsible for detecting no Item
        /// presence in room
        /// </summary>
        public void ItemNotFound()
        {
            Console.WriteLine("There is no item to be found here.");
        }

    }
}