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

        public TrueView(Controller controller, Player player)
        {
            this.controller = controller;
            this.player = player;
        }

        public string MainMenu()
        {            
            Console.WriteLine("\ud83d\udde1\ufe0f Welcome adventurer! \ud83e\uddd9");

            return "Hi";
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