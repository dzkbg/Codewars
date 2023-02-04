/*
Task
You are at position [0, 0] in maze NxN and you can only move in one of the four cardinal directions (i.e. North, East, South, West). Return true if you can reach position [N-1, N-1] or false otherwise.

-Empty positions are marked ..
-Walls are marked W.
-Start and exit positions are empty in all test cases.
*/


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BFS_TEST
{
    class Program
    {
        public static int[] dir1 = { 0, 1, -1, 0 };
        public static int[] dir2 = { 1, 0, 0, -1 };

        public class Cell
        {
            public int val;
            public int row;
            public int col;

            public Cell(int val, int row, int col)
            {
                this.val = val;
                this.row = row;
                this.col = col;
            }
        }

        public static bool IsVisited(bool[][] vis, int i, int j)
        {
            if (i < 0 || i > vis.Length-1 || j < 0 || j > vis.Length-1)
            {
                return false;
            }

            if (!vis[i][j]) { return true; }

            return false; ;
        }

        public static void BFS(int[][] matrix, bool[][] visited, int i, int j)
        {
            Queue<Cell> q = new Queue<Cell>();
            Cell start = new Cell(matrix[i][j], i, j);
            q.Enqueue(start);
            visited[i][j] = true;

            while (q.Count > 0)
            {
                Cell toGo = q.Dequeue();
                //Console.Write(toGo.val + " ");

                for (int row = 0; row < 4; row++)
                {
                    if (IsVisited(visited, toGo.row + dir1[row], toGo.col + dir2[row]) &&
                        matrix[toGo.row + dir1[row]][toGo.col + dir2[row]] == 1
                        )
                    {
                        Cell notVisited = new Cell(matrix[toGo.row + dir1[row]][toGo.col + dir2[row]], toGo.row + dir1[row], toGo.col + dir2[row]);
                        q.Enqueue(notVisited);
                        visited[toGo.row + dir1[row]][toGo.col + dir2[row]] = true;
                    }
                }
            }
        }


        public static void Main(string[] args)
        {
            
            string d = "..W.WW.......\n" +
                        ".W.....WW.W..\n" +
                        "WW..WW.......\n" +
                        "W.....W...W.W\n" +
                        "...WWW..WW..W\n" +
                        ".....W.....W.\n" +
                        "W....W....WW.\n" +
                        "....W..WW...W\n" +
                        "W.W.W.WW..W..\n" +
                        "......WWW.W..\n" +
                        "W.WW.........\n" +
                        "W.W.W........\n" +
                        "....WWW..W...\n";
            


            int[][] arr = new int[d.IndexOf('\n')][];
            bool[][] visited = new bool[d.IndexOf('\n')][];
            for (int i = 0; i < d.IndexOf('\n'); i++)
            {
                arr[i] = new int[d.IndexOf('\n')];
                visited[i] = new bool[d.IndexOf('\n')];
            }


            int row = 0, col = 0;
            foreach (char c in d)
            {
                if(c == '.') { arr[row][col] = 1; col++; }
                if(c == 'W') { arr[row][col] = 0; col++; }
                if(c == '\n') { row++; col = 0; }
            }


            BFS(arr, visited, 0, 0);
            Console.Write("\n");
            Console.Write(visited[visited.Length - 1][visited.Length - 1] + "\n");
        }
    }
}
