using System;
using System.Collections.Generic;
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

        public Controller(IView view, string filePath)
        {
            _view = view;
            _player = new Player();
            _board = new Board(filePath);
            _currentPosition = (0, 0);
        }

        public void StartGame()
        {
            _view.InitialMessage();
            bool playing = true;

            while (playing)
            {
                Room currentRoom = _board.Rooms[_currentPosition.x, _currentPosition.y];
                if (currentRoom == null)
                {
                    _view.DisplayMessage("This room does not exist.");
                    playing = false;
                    continue;
                }

                _view.DisplayMessage($"Exits: North: {currentRoom.NorthExit}, South: {currentRoom.SouthExit}, East: {currentRoom.EastExit}, West: {currentRoom.WestExit}");
                if (currentRoom.HasEnemy)
                {
                    _enemy = new Enemy();  // You may want to initialize this with specific properties
                    _view.DisplayMessage("There is an enemy here.");
                }
                else
                {
                    _enemy = null;
                }
                if (currentRoom.RoomItem != null) _view.DisplayMessage($"There is an item here: {currentRoom.RoomItem.Name}");

                //Cycle that keeps showing the actions menu until the player quits               // 
                do
                {
                    _view.Choice();
                    string action = _view.GetUserInput().ToLower();

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
                            playing = false;
                            _view.EndMessage();
                            break;

                        default:
                            _view.InvalidAction();
                            break;
                    }
                } while (action == "quit");
            }
        }

        private void MovePlayer()
        {
            _view.DisplayMessage("Enter direction (north, south, east, west):");
            string direction = _view.GetUserInput().ToLower();

            switch (direction)
            {
                case "north":
                    if (_currentPosition.x > 0 && _board.Rooms[_currentPosition.x - 1, _currentPosition.y]?.NorthExit == true)
                        _currentPosition.x--;
                    else
                        _view.DisplayMessage("You can't move north.");
                    break;
                case "south":
                    if (_currentPosition.x < 2 && _board.Rooms[_currentPosition.x + 1, _currentPosition.y]?.SouthExit == true)
                        _currentPosition.x++;
                    else
                        _view.DisplayMessage("You can't move south.");
                    break;
                case "east":
                    if (_currentPosition.y < 2 && _board.Rooms[_currentPosition.x, _currentPosition.y + 1]?.EastExit == true)
                        _currentPosition.y++;
                    else
                        _view.DisplayMessage("You can't move east.");
                    break;
                case "west":
                    if (_currentPosition.y > 0 && _board.Rooms[_currentPosition.x, _currentPosition.y - 1]?.WestExit == true)
                        _currentPosition.y--;
                    else
                        _view.DisplayMessage("You can't move west.");
                    break;
                default:
                    _view.DisplayMessage("Invalid direction. Try again.");
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
                _view.DisplayMessage("There is no item to be found here.");
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
                _view.DisplayMessage("There is no enemy here to attack.");
            }
        }
    }
}