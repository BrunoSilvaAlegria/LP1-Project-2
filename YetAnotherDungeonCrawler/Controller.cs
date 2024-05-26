using System;
using System.Collections.Generic;
using System.IO.Pipes;
using System.Linq;
using System.Threading.Tasks;

namespace YetAnotherDungeonCrawler
{
    public class Controller
    {
        private IView _view;
        private Player _player;
        private Board _board;
        private (int x, int y) _currentPosition;
        private Enemy _enemy;

        public Controller(string filePath)
        {
            _player = new Player();
            _board = new Board(filePath);
            _currentPosition = (1, 1);
        }

        public void StartGame(IView view)
        {
            _view = view; //Initialize the view variable
            
            view.MainMenu();
            string action = view.Choice();
            bool playing = true;

            while (playing)
            {
                Room currentRoom = _board.Rooms[_currentPosition.x, _currentPosition.y];
                if (currentRoom == null)
                {
                    Console.WriteLine("Correct this");
                    playing = false;
                    continue;
                }

                if (currentRoom.HasEnemy)
                {
                    _enemy = new Enemy();  //May want to initialize this with specific properties
                    view.EnemyDetection();
                }
                else
                {
                    _enemy = null;
                }

                //Cycle that keeps showing the actions menu until the player quits               // 
                do
                {
                    view.Choice();

                    switch (action)
                    {
                        case "move":
                            MovePlayer();
                            break;
                        case "search":
                            SearchRoom();
                            break;
                        case "use item":
                            UseItem();
                            break;
                        case "attack":
                            Attack();
                            break;
                        case "quit":
                            view.EndMessage();
                            playing = false;
                            break;

                        default:
                            view.InvalidAction();
                            break;
                    }
                } while (action != "quit");
            }
        }

        private void MovePlayer()
        {
            string direction = _view.Directions();
            Room currentRoom = _board.Rooms[_currentPosition.x, _currentPosition.y];

            switch (direction)
            {
                case "north":
                    if (_currentPosition.x > 0 && currentRoom.NorthExit && _board.Rooms[_currentPosition.x - 1, _currentPosition.y] != null)
                    {
                        _currentPosition.x--;
                    }
                    else
                        _view.CannotMoveThatWay();
                    break;
                case "south":
                    if (_currentPosition.x < 2 && currentRoom.SouthExit && _board.Rooms[_currentPosition.x + 1, _currentPosition.y] != null)
                        _currentPosition.x++;
                    else
                        _view.CannotMoveThatWay();
                    break;
                case "east":
                    if (_currentPosition.y < 2 && currentRoom.EastExit && _board.Rooms[_currentPosition.x, _currentPosition.y + 1] != null)
                        _currentPosition.y++;
                    else
                        _view.CannotMoveThatWay();
                    break;
                case "west":
                    if (_currentPosition.y > 0 && currentRoom.WestExit && _board.Rooms[_currentPosition.x, _currentPosition.y - 1] != null)
                        _currentPosition.y--;
                    else
                        _view.CannotMoveThatWay();
                    break;
                default:
                    _view.InvalidAction();
                    break;
            }
        }

        private void SearchRoom()
        {
            Room currentRoom = _board.Rooms[_currentPosition.x, _currentPosition.y];
            if (currentRoom.RoomItem != null)
            {
                _view.DisplayMessage($"You found an item: {currentRoom.RoomItem.Name}!");
                _player.AddItemToInventory();
                currentRoom.RemoveItem(); // Remove the item from the room after picking it up
            }
            else
            {
                _view.ItemNotFound();
            }
        }

        private void UseItem()
        {
            _view.DisplayMessage("Enter the name of the item to use:");
            string itemName = _view.GetUserInput();

            Item item = _player.Inventory.Find(i => i.Name.ToLower() == itemName.ToLower());
            if (item != null)
            {
                _player.UseItem(item);
                _view.DisplayMessage($"You used {item.Name} and restored {item.Healing} health.");
            }
            else
            {
                _view.DisplayMessage("You do not have that item.");
            }
        }

        private void Attack()
        {
            if (_enemy != null)
            {
                _enemy.Health -= _player.AttackPower;
                _view.PlayerAttack();

                if (_enemy.Health > 0)
                {
                    _player.Health -= _enemy.AttackPower;
                    _view.EnemyAttack();
                }
                else
                {
                    _view.EnemyDeath();
                    Room currentRoom = _board.Rooms[_currentPosition.x, _currentPosition.y];
                    currentRoom.RemoveEnemy();
                    _enemy = null;
                }

                if (_player.Health <= 0)
                {
                    _view.PlayerDeath();
                    Environment.Exit(0);
                }
            }
            else
            {
                _view.NoEnemy();
            }
        }
    }
}