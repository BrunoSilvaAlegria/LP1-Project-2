using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YetAnotherDungeonCrawler
{
    public interface IView
    {
        string InitialMessage();
        string MainMenu();
        Player PlayerDetails();
        string PlayerAttack();
        string EnemyAttack();
        string PlayerDeath();
        string EnemyDeath();
        void EndMessage();
        void Choice();
        void InvalidAction();
        void DisplayMessage(string message);
        string GetUserInput();
    }
}