using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YetAnotherDungeonCrawler
{
    public interface IView
    {
        string DisplayMessage(string message);
        
        void MainMenu();
        void PlayerAttack();
        void EnemyAttack();
        void PlayerDeath();
        void EnemyDeath();
        void EndMessage();
        string Choice();
        void InvalidAction();
        string Directions();
        void CannotMoveThatWay();
        void EnemyDetection();
        void NoEnemy();
        void ItemFound();
        void ItemNotFound();
        string GetUserInput();
    }
}