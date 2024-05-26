using System;
using System.Collections.Generic;
using System.IO.Pipes;
using System.Linq;
using System.Threading.Tasks;

namespace YetAnotherDungeonCrawler
{
    /// <summary>
    /// Class responsible for Player
    /// actions inside each room
    /// </summary>
    public class Controller
    {
        private IView _view;
        private Player _player;
        private Board _board;
        private (int x, int y) _currentPosition;
        private Enemy _enemy;

        public Controller(string filePath)
        {
            _player = new Player(); //Initialize the player
            _board = new Board(filePath); //Initialize the board (map)
            _currentPosition = (1, 1); //Sets the player's initial coordinates
        }
        
        /// <summary>
        /// Method responsible for registering
        /// PLayer actions until he dies or leave
        /// dungeon
        /// </summary>
        public void StartGame(IView view)
        {
            _view = view;
            
            view.MainMenu(); //Shows the initial and main menu of the game
            string action; //Initialize the player's action
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
                    //Initialize this enemy with its health and attack power values
                    _enemy = new Enemy(10,5);  
                    view.EnemyDetection();
                }
                else
                {
                    _enemy = null;
                }

                
                do
                {
                    //Gives the player the opportunity to choose what action 
                    //it wants to perform
                    action = view.Choice();

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
        /// <summary>
        /// Method responsible for Player
        /// Movement
        /// </summary>
        private void MovePlayer()
        {
            //Shows the directions the player can choose to go
            string direction = _view.Directions();
            Room currentRoom = _board.Rooms[_currentPosition.x, _currentPosition.y];

            
            switch (direction)
            {
                case "north":
                    if (_currentPosition.y > 0 && currentRoom.NorthExit == true && _board.Rooms[_currentPosition.x, _currentPosition.y - 1] != null)
                    {
                        _currentPosition.y--; //Goes up into the dungeon, in a grid format
                        _view.SuccessfulMove();
                    }
                    else
                        _view.CannotMoveThatWay();
                    break;
                case "south":
                    if (_currentPosition.y < 2 && currentRoom.SouthExit == true && _board.Rooms[_currentPosition.x, _currentPosition.y + 1] != null)
                    {
                        _currentPosition.x++; //Goes down into the dungeon, in a grid format
                        _view.SuccessfulMove();
                    }
                    else
                        _view.CannotMoveThatWay();
                    break;
                case "east":
                    if (_currentPosition.y < 2 && currentRoom.EastExit == true && _board.Rooms[_currentPosition.x + 1, _currentPosition.y] != null)
                    {
                        _currentPosition.y++; //Goes right into the dungeon, in a grid format
                        _view.SuccessfulMove();
                    }
                    else
                        _view.CannotMoveThatWay();
                    break;
                case "west":
                    if (_currentPosition.y > 0 && currentRoom.WestExit == true && _board.Rooms[_currentPosition.x - 1, _currentPosition.y] != null)
                    {
                        _currentPosition.y--; //Goes left into the dungeon, in a grid format
                        _view.SuccessfulMove();
                    }
                    else
                        _view.CannotMoveThatWay();
                    break;
                default:
                    _view.InvalidAction();
                    break;
            }
        }
        /// <summary>
        /// Method responsible for 
        /// Player search current room,
        /// and remove item from the room
        /// if he picks it up
        /// </summary>
        private void SearchRoom()
        {
            Room currentRoom = _board.Rooms[_currentPosition.x, _currentPosition.y];
            if (currentRoom.RoomItem != null)
            {
                _view.ItemFound(); //Show item found message
                _player.AddItemToInventory(); //Adds the item to the player's inventory
                currentRoom.RemoveItem(); //Removes the item from the room after collecting it
            }
            else
            {
                _view.ItemNotFound(); //Show item not found message
            }
        }
        /// <summary>
        /// Method responsible for
        /// using requested item, and
        /// verifying if the Player
        /// actually have it to use
        /// </summary>
        private void UseItem()
        {
            foreach (Item item in _player.Inventory) //Sees all the items in the inventory
            {
                if (item != null)
                {
                    _player.UseItem(item); //Used the item and removes it from the inventory
                    _view.ItemUsage(); //Shows item usage message
                }
                else
                {
                    _view.NoItemInInventory();//Shows that there is no item to be used
                }
            }
        }
        /// <summary>
        /// Method responsible for the
        /// action Attack, it also verify if an enemy
        /// exists.
        /// This method also verify enemy Hp
        /// and if it is hp<0 kills enemy
        /// </summary>
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