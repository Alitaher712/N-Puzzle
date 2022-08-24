using System;
using System.Collections.Generic;
using System.Diagnostics;

using System.IO;
using System.Linq;

namespace Puzzel
{
    class Bfs
    {
        private int row, column; //O(1)
        private int[,] board; //O(1)
        public List<Bfs> Main_List = new List<Bfs>(); //O(1)
        public List<Bfs> Based_List = new List<Bfs>(); //O(1)
        private int Value; //O(1)
        private List<Bfs> Neighboors; //O(1)
        private Bfs Parent; //O(1)
        private static FileStream file; //O(1)
        private static StreamReader str; //O(1)
        private static Dictionary<int, List<string>> Line; //O(1)
        private Bfs(int size, int val, int[,] brd)
        {
            this.Neighboors = new List<Bfs>(); //O(1)
            this.board = new int[size, size]; //O(1)
            Array.Copy(brd, this.board, size * size); //O(N^2)
            this.Value = val; //O(1) 
        }
        public Bfs()
        {
            this.Neighboors = new List<Bfs>(); //O(1)

            this.Value = 0; //O(1)
        }

        public void Get_Chileds(int size)//O(N²)
        {
            for (int i = 0; i < 4; i++) //O(N^2)
            {
                // check for availabilty of move 
                if (Can_Solve(this.row, this.column, i, size))//O(1)
                {
                    var ind = Tuple.Create(this.row, this.column); //O(1)
                    if (i == 0) //O(1)
                    {
                        ind = Tuple.Create(this.row + 1, this.column); //O(1)
                    }
                    else if (i == 1) //O(1) 
                    {
                        ind = Tuple.Create(this.row - 1, this.column); //O(1)
                    }
                    else if (i == 2) //O(1)
                    {
                        ind = Tuple.Create(this.row, this.column + 1); //O(1)
                    }
                    else if (i == 3) //O(1)
                    {
                        ind = Tuple.Create(this.row, this.column - 1); //O(1)
                    }
                    Bfs child = new Bfs(size, board[ind.Item1, ind.Item2], this.board);//O(N^2)
                    Array.Copy(this.board, child.board, size * size);//O(N²) 
                    int n = child.board[this.row, this.column]; //O(1)
                    child.board[this.row, this.column] = child.board[ind.Item1, ind.Item2]; //O(1)
                    child.board[ind.Item1, ind.Item2] = n; //O(1)
                    child.row = ind.Item1; //O(1)
                    child.column = ind.Item2; //O(1)
                    child.Parent = this; //O(1)
                    var temp = this.Parent; //O(1)
                    if (!(temp != null && temp.column == child.column && temp.row == child.row)) //O(1)
                    {
                        this.Neighboors.Add(child);//O(1) 
                    }
                }
            }
        }
        public bool found(Bfs child) //O(1)
        {
            return Main_List.Contains(child) && !Based_List.Contains(child); //O(1)
        }
        public Bfs BFS(Bfs start, int size, int[,] goalboard) //O(N^2)
        {
            Main_List.Add(start); //O(1)
            while (Main_List.Count != 0)//O(N^2)
            {
                Bfs current = Main_List[0]; //O(1)
                current.Get_Chileds(size);//O(N²)
                foreach (var child in current.Neighboors)//O(1)
                {
                    if (Check_Reach_Goal(child.board, goalboard, size))//O(N²)
                    {
                        return child; //O(1)
                    }
                    if (!found(child)) //O(N)
                    {
                        child.Parent = current; //O(1)
                        Main_List.Add(child);//O(1) 
                    }
                }
                int index = 0; //O(1)
                Main_List.RemoveAt(index); //O(1)
                Based_List.Add(current); //O(1)
            }
            return null;
        }
        bool Check_Reach_Goal(int[,] first, int[,] second, int size)//O(N²)
        {
            int count = 0; //O(1)
            for (int i = 0; i < size; i++) //O(N^2)
            {
                for (int j = 0; j < size; j++) //O(N)
                {
                    if (first[i, j] != second[i, j]) //O(1)
                    {

                        count++; //O(1)
                        break; //O(1)
                    }
                }

            }
            return count == 0; //O(1)
        }



        private static bool Can_Solve(int x, int y, int i, int size)//O(1)
        {
            if (i == 0) //O(1)
            {
                if (x + 1 >= size) //O(1)
                {
                    return false; //O(1)
                }
                else
                {
                    return true; //O(1)
                }
            }
            else if (i == 1) //O(1)
            {
                if (x - 1 < 0) //O(1)
                {
                    return false; //O(1)
                }
                else
                {
                    return true; //O(1)
                }
            }
            else if (i == 2) //O(1)
            {
                if (y + 1 >= size) //O(1)
                {
                    return false; //O(1)
                }
                else
                {
                    return true; //O(1)
                }
            }
            else if (i == 3) //O(1)
            {
                if (y - 1 < 0) //O(1)
                {
                    return false; //O(1)
                }
                else
                {
                    return true; //O(1)
                }
            }
            return false; //O(1)
        }
        public static void readAndCalc(string t)
        {
            file = new FileStream(t, FileMode.Open, FileAccess.Read); //O(1)
            str = new StreamReader(file); //O(1)
            string line = str.ReadLine(); //O(1)
            int size = int.Parse(line); //O(1)
            int[,] goal = new int[size, size]; //O(1)
            line = str.ReadLine(); //O(1)
            Line = new Dictionary<int, List<string>>(); //O(1)
            int ii = 0, jj = 0; //O(1)
            for (int i = 0; i < size;) //O(N^2)
            {
                if (line == "") //O(1)
                {
                    line = str.ReadLine(); //O(1)
                    i = 0; //O(1)
                    continue;
                }
                Line.Add(i, new List<string>()); //O(1)
                List<string> vertices = line.Split(' ').ToList(); //O(1)
                Line[i] = vertices; //O(1)
                for (int j = 0; j < size; j++) //O(N)
                {
                    int g = i * size + (j + 1); //O(1)
                    goal[i, j] = g; //O(1)
                    jj = j; //O(1)
                }
                ii = i; //O(1)
                i++; //O(1)
                line = str.ReadLine(); //O(1)
            }

            goal[ii, jj] = 0; //O(1)
            str.Close(); //O(1)
            file.Close(); //O(1)
            int[,] board = new int[size, size]; //O(1)
            Bfs Bfs_start = new Bfs(); //O(1)
            for (int i = 0; i < size; i++) //O(N)
            {
                foreach (var element in Line[i]) //O(1)
                {
                    int j = Line[i].IndexOf(element); //O(1)
                    board[i, j] = int.Parse(element); //O(1)
                }
            }
            Bfs[,] graph = new Bfs[size, size]; //O(1)
            Bfs firstnode = new Bfs(); //O(1)
            for (int i = 0; i < size; i++) //O(N^3)
            {
                foreach (var element in Line[i]) //O(N^2)
                {
                    int j = Line[i].IndexOf(element); //O(1)
                    graph[i, j] = new Bfs(size, int.Parse(element), board) //O(N^2)
                    {
                        Parent = null, //O(1)
                        row = i, //O(1)
                        column = j, //O(1)
                    };
                    board[i, j] = int.Parse(element); //O(1)
                    if (element.Equals("0")) //O(1)
                    {
                        firstnode = graph[i, j]; //O(1)
                    }
                }
            }
            Stopwatch bfswatch = new Stopwatch(); //O(1)
            bfswatch.Start(); //O(1)
            Bfs Goal = firstnode.BFS(firstnode, size, goal); //O(N^2)
            Bfs_start = Goal; //O(1)
            bfswatch.Stop(); //O(1)

            int step = 0; //O(1)
            List<Bfs> nodes = new List<Bfs>(); //O(1)
            Console.WriteLine("Childs From Down To Top");
            while (Bfs_start != null) //O(N^2)
            {
                Console.WriteLine("Chiled ", step);
                step++; //O(1)
                for (int i = 0; i < size; i++) //O(N^2)
                {
                    for (int j = 0; j < size; j++) //O(N)
                    {
                        Console.Write(Bfs_start.board[i, j]); //O(1)
                        Console.Write(" ");
                    }
                    Console.WriteLine();
                }
                Console.WriteLine();
                Bfs_start = Bfs_start.Parent; //O(1)
            }
            Console.WriteLine("Time : " + bfswatch.Elapsed);
        }


    }
}