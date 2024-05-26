using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YetAnotherDungeonCrawler
{
    /// <summary>
    /// Interface responsible for showing all
    /// outputs from class TrueView
    /// </summary> <summary>
    /// 
    /// </summary>
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
        void SuccessfulMove();
        void InvalidAction();
        string Directions();
        void CannotMoveThatWay();
        void EnemyDetection();
        void NoEnemy();
        void ItemFound();
        void ItemNotFound();
        void ItemUsage();
        void NoItemInInventory();
    }
}