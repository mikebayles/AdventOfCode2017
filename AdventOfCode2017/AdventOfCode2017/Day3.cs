using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode2017
{
    public class Day3
    {
        private Direction lastDirection = Direction.Up;
        private int size = 25;
        private int[,] array;
        private int r;
        private int c;


        public int Part2(int input)
        {
            array = new int[size, size];
            r = c = (int)Math.Floor(size / 2.0);
            array[r, c] = 1;
            array[r, ++c] = 1;

            while (array[r, c] < input)
            {
                var nextDirection = NextDirection();
                ApplyNextDirection(nextDirection);
            }

            return array[r, c];
        }

        enum Direction
        {
            Right,
            Up,
            Left,
            Down
        }

        void ApplyNextDirection(Direction desiredDirection)
        {
            switch (desiredDirection)
            {
                case Direction.Right:
                    array[r, c + 1] = SafeAccess(r, c) + SafeAccess(r - 1, c) + SafeAccess(r + 1, c) +
                                      SafeAccess(r - 1, c + 1) + SafeAccess(r + 1, c + 1) + SafeAccess(r - 1, c + 2) +
                                      SafeAccess(r + 1, c + 2) + SafeAccess(r, c + 2);
                    c++;
                    break;
                case Direction.Up:
                    array[r - 1, c] = SafeAccess(r, c) + SafeAccess(r - 1, c + 1) + SafeAccess(r, c + 1) +
                                      SafeAccess(r, c - 1) + SafeAccess(r - 1, c - 1) +
                                      SafeAccess(r - 2, c) + SafeAccess(r - 2, c - 1) + SafeAccess(r - 2, c + 1);
                    r--;
                    break;
                case Direction.Left:
                    array[r, c - 1] = SafeAccess(r, c) + SafeAccess(r - 1, c) + SafeAccess(r + 1, c) +
                                             SafeAccess(r, c - 2) + SafeAccess(r - 1, c - 1) +
                                             SafeAccess(r - 1, c - 2) + SafeAccess(r + 1, c - 1) + SafeAccess(r + 1, c - 2);
                    c--;
                    break;
                case Direction.Down:
                    array[r + 1, c] = SafeAccess(r, c) + SafeAccess(r, c + 1) + SafeAccess(r, c - 1) +
                                             SafeAccess(r + 1, c - 1) + SafeAccess(r + 1, c + 1) +
                                             SafeAccess(r + 2, c) + SafeAccess(r + 2, c - 1) + SafeAccess(r + 2, c + 1);
                    r++;
                    break;
                default:
                    break;
            }

            lastDirection = desiredDirection;
        }

        int SafeAccess(int r, int c)
        {
            try
            {
                return array[r, c];
            }
            catch
            {
                return 0;
            }
        }

        Direction NextDirection()
        {
            switch (lastDirection)
            {
                case Direction.Right:
                    return array[r - 1, c] != 0 ? Direction.Right : Direction.Up;
                case Direction.Up:
                    return array[r, c - 1] != 0 ? Direction.Up : Direction.Left;
                case Direction.Left:
                    return array[r + 1, c] != 0 ? Direction.Left : Direction.Down;
                case Direction.Down:
                    return array[r, c + 1] != 0 ? Direction.Down : Direction.Right;
                default:
                    return lastDirection;
            }
        }
    }
}
