using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YetAnotherDungeonCrawler
{
    public class TrueView : IView
    {
        private readonly Controller controller;

        public TrueView(Controller controller)
        {
            this.controller = controller;
        }

        public string MainMenu()
        {            
            Console.WriteLine("\ud83d\udde1\ufe0f Welcome adventurer! \ud83e\uddd9");

            return "Hi";
        }

        public Player PlayerDetails()
        {
            string name;

            Console.WriteLine("What is your name?");
            name = Console.ReadLine();

            return new Player(name);
        }
    


    }
}