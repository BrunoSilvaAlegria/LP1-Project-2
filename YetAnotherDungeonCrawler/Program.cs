using System;

namespace YetAnotherDungeonCrawler
{
    public class Program
    {
        static void Main(string[] args)
        {
            Player player = new Player();
            
            string filePath = "YetAnotherDungeonCrawler/rooms.txt";
            Controller controller = new Controller(filePath);

            IView view = new TrueView(controller, player);
            
            controller.StartGame(view);
        }
    }
}
