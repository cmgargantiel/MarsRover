using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover
{
    public class Rover
    {
        private int _roverId;
        private Point _position;
        private Directions _direction;
        private string _movement;
        private Point _area;

        public int RoverId
        {
            get => _roverId;
            set => _roverId = value;
        }
        public Point Position
        {
            get => _position;
            set => _position = value;
        }

        public Directions Direction
        {
            get => _direction;
            set => _direction = value;
        }

        public string Movement
        {
            get => _movement;
            set => _movement = value;
        }

        public Point Area
        {
            get => _area;
            set => _area = value;
        }

        public Rover(int id, Point position, Directions direction, string movement, Point area)
        {
            _roverId = id;
            _position = position;
            _direction = direction;
            _movement = movement;
            _area = area;
        }

        public enum Directions
        {
            N, E, S, W
        }

        public void Start()
        {
            foreach(var action in _movement)
            {
                switch(action)
                {
                    case 'L':
                        TurnLeft();
                        break;
                    case 'R':
                        TurnRight();
                        break;
                    case 'M':
                        Move();
                        break;
                    default:
                        throw new Exception($"Rover {_roverId}: Invalid control in input");
                }
            }
        }

        private void Move()
        {
            //if facing north, increase y axis
            //if facing east, increase x axis
            //if facing west, decrease x axis
            //if facing south, decrease y axis
            switch(_direction)
            {
                case Directions.N:
                    _position.Y++;
                    break;
                case Directions.E:
                    _position.X++;
                    break;
                case Directions.S:
                    _position.Y--;
                    break;
                case Directions.W:
                    _position.X--;
                    break;
            }

            if(_position.X > _area.X || _position.Y > _area.Y
                || _position.X < 0 || _position.Y < 0)
            {
                throw new Exception($"Rover {_roverId}: Out of bounds!");
            }
        }

        private void TurnRight()
        {
            if (_direction == Directions.W) 
            {
                _direction = Directions.N; //go back to north
            }
            else
            {
                _direction = ++_direction;
            }

        }

        private void TurnLeft()
        {
            if (_direction == Directions.N)
            {
                _direction = Directions.W; //go back to west
            }
            else
            {
                _direction = --_direction;
            }
        }
    }
}
