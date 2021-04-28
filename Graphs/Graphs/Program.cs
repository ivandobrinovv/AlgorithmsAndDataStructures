using System;
using System.Collections.Generic;

namespace Graphs
{
    // Задачата намира път между два зададени върха в граф
    // Решението на задачата е работещо, но не е оптимално
    class Program
    {
        // Можете да промените матрицата на зависимостите, за да тествате с различни данни
        static readonly int[,] dependencies = new int[,]
        {
            { 0, 1, 0, 1, 0},
            { 1, 0, 0, 1, 0},
            { 0, 0, 0, 0, 1},
            { 1, 1, 0, 0, 1},
            { 0, 0, 1, 1, 0}
        };

        static readonly int rowLength = dependencies.GetLength(0);

        static bool IsThereAPath(int from, int to, List<int> path)
        {
            if(dependencies[from, to] != 0)
            {
                path.Add(to);
                return true;
            }

            for (int i = 0; i < rowLength; i++)
            {
                if (dependencies[from, i] == 0 || from == i || path.Contains(i))
                {
                    continue;
                }

                path.Add(i);
                if(IsThereAPath(i, to, path))
                {
                    return true;
                }
                else
                {
                    path.Remove(i);
                }
            }

            return false;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("From where should the path start?");
            int from = int.Parse(Console.ReadLine());
            Console.WriteLine("Where should the path end?");
            int to = int.Parse(Console.ReadLine());
            List<int> path = new List<int>();
            path.Add(from);

            if(IsThereAPath(from, to, path))
            {
                Console.WriteLine($"There is at least one path between {from} and {to}:");
                foreach(int node in path)
                {
                    Console.WriteLine(node);
                }
            }
            else
            {
                Console.WriteLine($"There is no path between {from} and {to}");
            }
        }
    }
}
