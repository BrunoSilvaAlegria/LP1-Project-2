using System;

namespace YetAnotherDungeonCrawler
{
    public class Program
    {
        static void Main(string[] args)
        {
            IView view = new TrueView();
            
            string filePath = "YetAnotherDungeonCrawler/rooms.txt";
            Controller controller = new Controller(view, filePath);

            controller.StartGame();
        }
    }
}
