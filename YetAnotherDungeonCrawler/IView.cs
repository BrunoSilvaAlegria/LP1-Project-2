using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YetAnotherDungeonCrawler
{
    public interface IView
    {
        void InitialMessage();
        string MainMenu();
        Player PlayerDetails();
        void PlayerAttack();
        void EnemyAttack();
        void PlayerDeath();
        void EnemyDeath();
        void EndMessage();
        void Choice();
        void InvalidAction();
        void DisplayMessage(string message);
        string GetUserInput();
    }
}