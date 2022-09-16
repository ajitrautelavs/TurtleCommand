using System;

namespace TurtleCommand
{
    public class Turtle
    {
        private BoardPosition _currentPosition = null;
        private bool _isPlacedOnBoard = false;

        public Turtle()
        {
        }

        public bool IsPlacedOnBoard {
            get { return _isPlacedOnBoard; }
            set { _isPlacedOnBoard = value; }
        }

        public BoardPosition CurrentPosition
        {
            get { return _currentPosition; }
        }

        public void PlaceOnBoard(BoardPosition position)
        {
            _isPlacedOnBoard = true;
            _currentPosition = position;
        }

        public void MoveOnBoard()
        {
            switch (_currentPosition.F)
            {
                case DirectionEnum.NORTH:
                    //Cant go North of UpperBound Y
                    if (_currentPosition.Y < BoardPosition.UpperBoundY)
                    {
                        _currentPosition.Y += 1;
                    }
                    break;
                case DirectionEnum.SOUTH:
                    //Cant go South of 1
                    if (_currentPosition.Y > BoardPosition.LowerBoundY)
                    {
                        _currentPosition.Y -= 1;
                    }
                    break;
                case DirectionEnum.EAST:
                    //Cant go East of UpperBound X
                    if (_currentPosition.X < BoardPosition.UpperBoundX)
                    {
                        _currentPosition.X += 1;
                    }
                    break;
                case DirectionEnum.WEST:
                    //Cant go West of 1
                    if (_currentPosition.X > BoardPosition.LowerBoundX)
                    {
                        _currentPosition.X -= 1;
                    }
                    break;
                default:
                    //Invalid move, remain in position
                    break;
            }
        }

        public void TurnOnBoard(CommandEnum commandDirection)
        {
            int direction = (int)_currentPosition.F;

            if (commandDirection == CommandEnum.LEFT)
            {
                direction -= 1;
                _currentPosition.F = (DirectionEnum)direction;
                if (direction < 0)
                    _currentPosition.F = DirectionEnum.WEST;    //Reset to West if rotate left from North

            }
            else
            {
                direction += 1;
                _currentPosition.F = (DirectionEnum)direction;
                if (direction > 3)
                    _currentPosition.F = DirectionEnum.NORTH;    //Reset to North if rotate right from West
            }
        }

        public DirectionEnum GetDirectionFromCurrentPosition()
        {
            return _currentPosition.F;
        }
    }

    public class BoardPosition
    {
        public const int LowerBoundX = 0;
        public const int LowerBoundY = 0;
        public const int UpperBoundX = 4;
        public const int UpperBoundY = 4;

        public int X { get; set; }
        public int Y { get; set; }
        public DirectionEnum F { get; set; }
    }

}
