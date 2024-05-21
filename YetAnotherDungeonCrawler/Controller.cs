using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YetAnotherDungeonCrawler
{
    public class Controller
    {
        private readonly List<Item> itemList;

        private IView view;

        public Controller(List<Item> items)
        {
            itemList = items;
        }

        public void Start(IView view)
        {
            this.view = view;

            string option;

            do
            {
                option = view.MainMenu();
            } while (option == "North"||option == "South"||option == "East"||option == "West")
        }
    }
}