using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace TU_Challenge
{
    public class Pathfinding
    {
        private char[,] _grid;
        private int _width;
        private int _height;
        public char[,] Grid 
        {
            get { return _grid; }
            set { _grid = value; }
        }

        public Pathfinding(string map)
        {
            string[] lines = map.Split("\n");
            _grid = new char[lines.Length, lines[0].Length];
            _width = lines[0].Length;
            _height = lines.Length;
            for (int i = 0; i < lines.Length; i++)
            {
                for(int j = 0; j < lines[i].Length; j++)
                {
                    _grid[i, j] = lines[i][j];
                }
            }
        }

        public Path BreadthFirstSearch(Vector2 start, Vector2 destination)
        {
            Vector2[,] parent = new Vector2[_height,_width];

            for (int i = 0; i < _height; i++)
            {
                for (int j = 0; j < _width; j++)
                {
                    parent[i, j] = new Vector2(-1,-1);
                }
            }
            List <Vector2> exclude = new List<Vector2>();
            Queue <Vector2> queue = new Queue<Vector2>();
            queue.Enqueue(start);
            Vector2 position;
            bool isAtDestination = false;
            List<Vector2> solution = new List<Vector2>();
            while (queue.Count > 0 && !isAtDestination)
            {
                position = queue.Dequeue();
                if (position == destination)
                {
                    isAtDestination = true;
                    solution.Add(position);
                } else
                {
                    foreach (Vector2 neighboor in GetNeighboors(position, exclude))
                    {
                        if (!queue.Contains(position))
                        {
                            parent[neighboor.X, neighboor.Y] = position;
                            queue.Enqueue(neighboor);
                        }
                    }
                }
            }
            Path p = new Path(start);
            /*if (isAtDestination)
            {
                Vector2 par = destination;
                while (par != start)
                {
                    par = parent[par.X, par.Y];
                    solution.Add(par);
                }
                solution.Reverse();
                foreach (Vector2 v in solution)
                {
                    p = new Path(p, v);
                }
            }*/


            return p;
        }

        public char GetCoord(Vector2 el)
        {
            if (IsOutOfBound(el))
            {
                throw new ArgumentException();
            }
            return _grid[el.X, el.Y];
        }

        public List<Vector2> GetNeighboors(Vector2 vector2)
        {
            List<Vector2> neighboors = new List<Vector2>();
            for (int i = -1; i <= 1; i++)
            {
                for (int j = -1; j <= 1; j++)
                {
                    Vector2 neighboor = vector2 + new Vector2(i, j);
                    if (!IsOutOfBound(neighboor) && !(i == 0 && j == 0) && _grid[neighboor.X, neighboor.Y] != 'X')
                    {
                        neighboors.Add(neighboor);
                    }
                }
            }
            return neighboors;
        }

        public List<Vector2> GetNeighboors(Vector2 vector2, List<Vector2> exclude)
        {
            List<Vector2> neighboors = GetNeighboors(vector2);
            foreach (Vector2 neighbour in exclude)
            {
                neighboors.Remove(neighbour);
            }
            return neighboors;
        }

        public bool IsOutOfBound(Vector2 vector2)
        {
            return vector2.X < 0 || vector2.X >= _height || vector2.Y < 0 || vector2.Y >= _width;
        }
    }

}
