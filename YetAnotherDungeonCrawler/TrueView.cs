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

        public void InitialMessage()
        {            
            Console.WriteLine("\ud83d\udde1\ufe0f Welcome to the dungeon adventurer! \ud83e\uddd9");
        }
        public string MainMenu()
        {
            Console.WriteLine("");

            return Console.ReadLine();
        }
        public void Choice()
        {
            Console.WriteLine("What will you do?");
        }
        public void EndMessage()
        {
            Console.WriteLine("Thank You For Playing!");
        }
        public void InvalidAction()
        {
            Console.Error.WriteLine("\n>>> Unknown action! <<<\n");
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

        public Player PlayerDetails() //eliminate
        {
            string name;

            Console.WriteLine("What is your name?");
            name = Console.ReadLine();

            return new Player();
        }

        public void DisplayMessage(string message)
        {
            Console.WriteLine(message);
        }

        public string GetUserInput()
        {
            return Console.ReadLine();
        }
    


    }
}