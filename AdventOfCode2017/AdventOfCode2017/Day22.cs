using System;

namespace AdventOfCode2017
{
    public class Day22
    {
        private byte[,] arr;
        private int rows;
        private int cols;
        private int size = 40000;

        private const byte clean = 0;
        private const byte infected = 1;
        private const byte weakened = 2;
        private const byte flagged = 3;

        public Day22(string[] input)
        {

            arr = new byte[size, size];

            rows = input.Length;
            cols = input[0].Length;


            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < cols; c++)
                {
                    arr[r + (size / 2), c + (size / 2)] = (input[r][c] == '#' ? infected : clean);
                }
            }
        }

        public int Part1()
        {
            int currentR = (rows / 2) + (size / 2);
            int currentC = (cols / 2) + (size / 2);
            int bursts = 0;
            int infectedCount = 0;
            char direction = 'X';

            while (bursts < 10000)
            {
                byte currentNode = arr[currentR, currentC];

                if (currentNode == infected)
                {
                    direction = NextDirection(direction, 'R');
                    arr[currentR, currentC] = clean;
                }
                else if (currentNode == clean)
                {
                    direction = NextDirection(direction, 'L');
                    arr[currentR, currentC] = infected;
                    infectedCount++;
                }

                if (direction == 'L')
                    currentC--;
                else if (direction == 'U')
                    currentR--;
                else if (direction == 'R')
                    currentC++;
                else if (direction == 'D')
                    currentR++;

                bursts++;
            }

            return infectedCount;
        }

        public int Part2()
        {
            int currentR = (rows / 2) + (size / 2);
            int currentC = (cols / 2) + (size / 2);
            int bursts = 0;
            int infectedCount = 0;
            char direction = 'U';

            while (bursts < 10000000)
            {
                byte currentNode = arr[currentR, currentC];

                if (currentNode == clean)
                {
                    arr[currentR, currentC] = weakened;
                    direction = NextDirection(direction, 'L');
                }
                else if (currentNode == weakened)
                {
                    arr[currentR, currentC] = infected;
                    infectedCount++;
                }
                else if (currentNode == infected)
                {
                    arr[currentR, currentC] = flagged;
                    direction = NextDirection(direction, 'R');
                }
                else if (currentNode == flagged)
                {
                    arr[currentR, currentC] = clean;
                    direction = ReverseDirection(direction);
                }

                if (direction == 'L')
                    currentC--;
                else if (direction == 'U')
                    currentR--;
                else if (direction == 'R')
                    currentC++;
                else if (direction == 'D')
                    currentR++;

                bursts++;
            }

            return infectedCount;
        }

        private char NextDirection(char lastDirection, char turn)
        {
            switch (lastDirection)
            {
                case 'U':
                    return turn == 'L' ? 'L' : 'R';
                case 'R':
                    return turn == 'L' ? 'U' : 'D';
                case 'D':
                    return turn == 'L' ? 'R' : 'L';
                case 'L':
                    return turn == 'L' ? 'D' : 'U';
                case 'X':
                    return turn;
                default:
                    throw new Exception("Unknown direction " + lastDirection);
            }
        }

        private char ReverseDirection(char lastDirection)
        {
            switch (lastDirection)
            {
                case 'U':
                    return 'D';
                case 'R':
                    return 'L';
                case 'D':
                    return 'U';
                case 'L':
                    return 'R';
                default:
                    throw new Exception("Unknown direction " + lastDirection);
            }
        }
    }
}
