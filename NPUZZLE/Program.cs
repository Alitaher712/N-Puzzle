using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;
namespace Puzzel
{
    class Program
    {
        //*************************************************************************
        public static int moves;//To save the goal steps that i want to reach in the final //O(1)   Congratulation
        static public bool check_solvable(int[] arr, int size, int rowofzero)//check if the puzzle can solved or not //O(N^2)
        {
            int inv_Count = 0;//to count the number of ele that greatter than and next to it
            size *= size;//to get the total size of the matrix
            for (int i = 0; i < size - 1; i++) //O(N^2)
            {
                for (int j = i + 1; j < size; j++) //O(N)
                {
                    if (arr[i] > arr[j] && arr[j] != 0)//check if the value is greatter than any next of it //O(1)
                    {
                        inv_Count++; //O(1)
                    }
                }
            }
           int _ind = size - rowofzero + 2;//to show the index from down //O(1)
            if ((size % 2 != 0 && inv_Count % 2 == 0))//lw el size Odd w el count even //O(1)
            {
                return true; //O(1)
            }
            else if ((size % 2 == 0 && inv_Count % 2 != 0 && _ind % 2 == 0)) //O(1)
            {//lw el size even w count off w el index mn down even
                return true; //O(1)
            }
            else if ((size % 2 == 0 && inv_Count % 2 == 0 && _ind % 2 != 0))//lw size even w el count even w mn down odd //O(1)
            {
                return true; //O(1)
            }
            else return false; //O(1)
        }
        //*************************************************************************
        static int Rowofzero;//store the index of zero value in row //O(1)
        static int ColOfZero;//store the index of zero value in col //O(1)
        public static void Ali()
        {
            Console.WriteLine(">>>>> Member 1 : ");
            Console.WriteLine();
            Console.WriteLine(" * * * * * * * * * * * * * * * *");
            Console.WriteLine(" * * * * * * * * * * * *");
            Console.WriteLine(" * * * * * * * * * * * * * * * * * ");
            Console.WriteLine(" * * * * * * * * * * * *");
            Console.WriteLine(" * * * * * * * * * * * * * * * * *");
            Console.WriteLine();
            Console.WriteLine("-----------------------------------------------------------------------------------------------------");
        }
        public static void mohammed()
        {
            Console.WriteLine(">>>>> Member 2 : ");
            Console.WriteLine();
            Console.WriteLine(" * * * * * * * * * * * * ");
            Console.WriteLine(" * * * * * * * * * * * * * ");
            Console.WriteLine(" * * * * * * * * * * * * * * * * * * * *");
            Console.WriteLine(" * * * * * * * * * * * * * * * ");
            Console.WriteLine(" * * * * * * * * * * * * * * * * * * ");
            Console.WriteLine();
            Console.WriteLine("-----------------------------------------------------------------------------------------------------");
        }
        public static void Aya()
        {
            Console.WriteLine(">>>>> Member 3 : ");
            Console.WriteLine();
            Console.WriteLine(" * * * * * * * * * * * * * * * * * * * * ");
            Console.WriteLine(" * * * * * * * * * * * * * * * * * ");
            Console.WriteLine(" * * * * * * * * * * * * * * * * * * * * * * * * * * ");
            Console.WriteLine(" * * * * * * * * * * * * * * * * ");
            Console.WriteLine(" * * * * * * * * * * * * * * * * * * * * * * * ");
            Console.WriteLine();
            Console.WriteLine("-----------------------------------------------------------------------------------------------------");
        }
        public static void Main(string[] args)
        {
            // Read Board From File
            bool manhattan = false;//check if user choose the manhattan test O(1)
            Console.WriteLine("*************************************** N Puzzle ***********************************");//O(1)
            string[] Tests = new string[]//store all tests name in it O(1)
            {
                  "8 Puzzle (1).txt",
                  "8 Puzzle (2).txt",
                  "8 Puzzle (3).txt",
                  "15 Puzzle - 1.txt ",
                  "24 Puzzle 1.txt",
                  "24 Puzzle 2.txt",
                 "8 Puzzle - Case 1.txt",
                 "8 Puzzle(2) - Case 1.txt",
                 "8 Puzzle(3) - Case 1.txt",
                 "15 Puzzle - Case 2.txt",
                 "15 Puzzle - Case 3.txt",
                 "50 Puzzle.txt",
                 "99 Puzzle - 1.txt",
                 "99 Puzzle - 2.txt",
                 "9999 Puzzle.txt",
                 "man_15 Puzzle 1.txt",
                 "man_15 Puzzle 3.txt",
                 "man_15 Puzzle 4.txt",
                 "man_15 Puzzle 5.txt",
                 "15 Puzzle 1 - Unsolvable.txt",
                 "99 Puzzle - Unsolvable Case 2.txt",
                 "9999 Puzzle_not_solve.txt",
                 "TEST.txt"
            };
            string target_test = "";//string to store the test name that the user choose O(1)
            Console.WriteLine(">> 1- Sample Test cases "); //O(1)
            Console.WriteLine(">> 2- Complete Test cases "); //O(1)
            Console.WriteLine(">> 3- Team members "); //O(1)
            string ans = Console.ReadLine();//read the choose from the user O(1)
            if (ans == "1") //O(1)
            {
                Console.WriteLine("*************************************** Sample Tests **********************************");
                Console.WriteLine(">> 1- Solveable Tests ");
                Console.WriteLine(">> 2- Unsolveable Tests");
                Console.Write(">> Press 1 Or 2: ");
                string ans1 = Console.ReadLine();//read the choose from the user O(1)
                if (ans1 == "1")
                {
                    Console.WriteLine("******************************************* Test Cases ********************************"); Console.WriteLine(">> Test 1 ");
                    Console.WriteLine(">> Test 2 ");
                    Console.WriteLine(">> Test 3 ");
                    Console.WriteLine(">> Test 4 ");
                    Console.WriteLine(">> Test 5 ");
                    Console.WriteLine(">> Test 6 ");
                    Console.Write(">> ");
                    string an = Console.ReadLine();//read the choose from the user O(1)
                    if (an == "1") //O(1)
                    {
                        target_test = Tests[0];//test1
                        moves = 8;
                    }
                    else if (an == "2") //O(1)
                    {
                        target_test = Tests[1]; //O(1)
                        moves = 20; //O(1)
                    }
                    else if (an == "3") //O(1)
                    {
                        target_test = Tests[2]; //O(1)
                        moves = 14; //O(1)
                    }
                    else if (an == "4") //O(1)
                    {
                        target_test = Tests[3]; //O(1)
                        moves = 5; //O(1)
                    }
                    else if (an == "5") //O(1)
                    {
                        target_test = Tests[4]; //O(1)
                        moves = 11; //O(1)
                    }
                    else if (an == "6") //O(1)
                    {
                        target_test = Tests[5]; //O(1)
                        moves = 24; //O(1)
                    }
                    else
                    {
                        Console.WriteLine("Wrong Choice !!!"); //O(1)
                        Main(null); //O(1)
                    }
                }
                else if (ans1 == "2")
                {
                    Console.WriteLine("******************************************* UnSolvable Cases ********************************");
                    Console.WriteLine(">> Test 1 ");
                    Console.WriteLine(">> Test 2 ");
                    Console.WriteLine(">> Test 3 ");
                    Console.WriteLine(">> Test 4 ");
                    Console.WriteLine(">> Test 5 ");
                    string an = Console.ReadLine(); //O(1)
                    if (an == "1") //O(1)
                    {
                        target_test = Tests[6]; //O(1)
                    }
                    else if (an == "2") //O(1)
                    {
                        target_test = Tests[7]; //O(1)
                    }
                    else if (an == "3") //O(1)
                    {
                        target_test = Tests[8]; //O(1)
                    }
                    else if (an == "4") //O(1)
                    {
                        target_test = Tests[9]; //O(1)
                    }
                    else if (an == "5") //O(1)
                    {
                        target_test = Tests[10]; //O(1)
                    }
                    else
                    {
                        Console.WriteLine("Wrong Choice !!!"); //O(1)
                        Main(null); //O(1)
                    }
                }
                else
                {
                    Console.WriteLine("Wrong Choice !!"); //O(1)
                    Main(null); //O(1)
                }
            }
            else if (ans == "2") //O(1)
            {
                Console.WriteLine("*************************************** Complete Tests **********************************");
                Console.WriteLine("1- Solvable Tests");
                Console.WriteLine("2- Unsoveable Tests");
                Console.WriteLine("3- Very large Test");
                string ans2 = Console.ReadLine(); //O(1)
                if (ans2 == "1") //O(1)
                {
                    Console.WriteLine("*************************************** Solvable Tests **********************************");
                    Console.WriteLine("1- Manhattan & Hamming");
                    Console.WriteLine("2- Manhattan Only");
                    string anss = Console.ReadLine(); //O(1)
                    if (anss == "1") //O(1)
                    {
                        Console.WriteLine("*************************************** Manhattan & Hamming **********************************");
                        Console.WriteLine(">> Test 1 ");
                        Console.WriteLine(">> Test 2 ");
                        Console.WriteLine(">> Test 3 ");
                        Console.WriteLine(">> Test 4 ");
                        string a = Console.ReadLine(); //O(1)
                        if (a == "1") //O(1)
                        {
                            target_test = Tests[11]; //O(1)
                            moves = 18; //O(1)
                        }
                        else if (ans == "2") //O(1)
                        {
                            target_test = Tests[12]; //O(1)
                            moves = 18; //O(1)
                        }
                        else if (ans == "3") //O(1)
                        {
                            target_test = Tests[13]; //O(1)
                            moves = 38; //O(1)
                        }
                        else if (ans == "4") //O(1)
                        {
                            target_test = Tests[14]; //O(1)
                            moves = 4; //O(1)
                        }
                        else
                        {
                            Console.WriteLine("Wrong Choice !"); //O(1)
                            Main(null); //O(1)
                        }
                    }
                    else if (anss == "2") //O(1)
                    {
                        manhattan = true;
                        Console.WriteLine("*************************************** Manhattan Only **********************************");
                        Console.WriteLine(">> Test 1 ");
                        Console.WriteLine(">> Test 2 ");
                        Console.WriteLine(">> Test 3 ");
                        Console.WriteLine(">> Test 4 ");
                        string a = Console.ReadLine(); //O(1)
                        if (a == "1") //O(1)
                        {
                            target_test = Tests[15]; //O(1)
                            moves = 46; //O(1)
                        }
                        else if (ans == "2") //O(1)
                        {
                            target_test = Tests[16]; //O(1)
                            moves = 38; //O(1)
                        }
                        else if (ans == "3") //O(1)
                        {
                            target_test = Tests[17]; //O(1)
                            moves = 44; //O(1)
                        }
                        else if (ans == "4") //O(1)
                        {
                            target_test = Tests[18]; //O(1)
                            moves = 45; //O(1)
                        }
                        else
                        {
                            Console.WriteLine("Wrong Choice !"); //O(1)
                            Main(null);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Wrong Choice !"); //O(1)
                        Main(null); //O(1)
                    }
                }
                else if (ans2 == "2") //O(1)
                {
                    Console.WriteLine("*************************************** Unsolvable Cases **********************************");
                    Console.WriteLine(">> Test 1 ");
                    Console.WriteLine(">> Test 2 ");
                    Console.WriteLine(">> Test 3 ");
                    string a = Console.ReadLine(); //O(1)
                    if (a == "1") //O(1)
                    {
                        target_test = Tests[19]; //O(1)
                    }
                    else if (ans == "2") //O(1)
                    {
                        target_test = Tests[20]; //O(1)
                    }
                    else if (ans == "3") //O(1)
                    {
                        target_test = Tests[21]; //O(1)
                    }
                    else
                    {
                        Console.WriteLine("Wrong Choice !"); //O(1)
                        Main(null); //O(1)
                    }
                }
                else if (ans2 == "3") //O(1)
                {
                    Console.WriteLine("*************************************** Final Case **********************************");
                    target_test = Tests[22]; //O(1)
                    moves = 56; //O(1)
                }
                else
                {
                    Console.WriteLine(" Wrong Choice !"); Main(null); //O(1)
                }
            }
            else if (ans == "3") //O(1)
            {
                Ali();
                mohammed();
                Aya();
                Main(null);
            }
            else
            {
                Console.WriteLine("Wrong Choice !");
                Main(null);
            }
            Console.WriteLine("*********************************************************************");
            //Read the target test
            FileStream fs = new FileStream(target_test, FileMode.Open, FileAccess.Read); //O(1)
            StreamReader sr = new StreamReader(fs); //O(1)
            while (sr.Peek() != -1)//read line by line from the text file O(N^2)
            {
                string s = sr.ReadLine();//read the line //O(1)
                string[] fields;//store element by element except space //O(1)
                fields = s.Split(' '); //O(1)
                int N; //O(1)
                N = int.Parse(fields[0]);//store the size of the matrix //O(1)
                int val; //O(1)
                int[] arr1d = new int[N * N];//to store the node in 1 d array //O(1)
                int[,] Node2d = new int[N, N];//to store the node in 2d array //O(1)
                int c = 0; //O(1)
                for (int i = 0; i < N; i++) //O(N^2)
                {
                    s = sr.ReadLine(); //O(1)
                    fields = s.Split(' '); //O(1)
                    for (int j = 0; j < N; j++) //O(N)
                    {
                        val = int.Parse(fields[j]); //O(1)
                        if (val == 0) //O(1)
                        {
                            Rowofzero = i; //O(1)
                            ColOfZero = j; //O(1)
                        }
                        Node2d[i, j] = val; //O(1)
                        arr1d[c++] = val; //O(1)
                    }
                }
                char ch; //O(1)
                if (!manhattan)//check if the user choose manhattan or not //O(N^2)
                {
                    //if he is not choose manhattan
                    Console.WriteLine(" - Press [1] To Using Hamming ."); //O(1)
                    Console.WriteLine(" - Press [2] To Using Manhattan ."); //O(1)
                    Console.WriteLine(" - Press [3] To using BFS ."); //O(1)
                    Console.Write(" - Enter Your Choice : "); //O(1)
                    ch = char.Parse(Console.ReadLine()); //O(1)
                }
                else
                {
                    // if user choose test manhattan only mack the choice 2
                    ch = '2'; //O(1)
                }
             //   ch = '2';
                if (ch == '1')
                {
                    if (check_solvable(arr1d, N, Rowofzero))//check the puzzle solved or not //O(N^2)
                    {
                        Console.WriteLine("Solving .........");
                        Console.WriteLine();
                        puzzel start = new puzzel(N, Node2d, Rowofzero, ColOfZero);//create the first node //O(N^2)
                        AS A = new AS();//creat object from A star class
                        A.A_Star(start, "Hamming");//Choose the hamming algo to solve the puzzle //O(E Log V)
                    }
                    else
                    {//if the puzzle can not solve
                        Console.WriteLine("No Solution For The Given Puzzle ");
                        Console.WriteLine();
                        Main(null);//going to the start page and running again
                    }
                }
                else if (ch == '2') //O(1)
                {
                    if (check_solvable(arr1d, N, Rowofzero))//check the puzzle solved or not //O(N^2)
                    {
                        Console.WriteLine("Solving .........");
                        Console.WriteLine();
                        puzzel start = new puzzel(N, Node2d, Rowofzero, ColOfZero);//create the first node //O(N^2)
                        AS A = new AS(); //creat object from A star class //O(1)
                        A.A_Star(start, "manhattan");//Choose the hamming algo to solve the Manhattan //O(E Log V)
                    }
                    else //O(1)
                    {
                        Console.WriteLine(" - No Solution For The Given Board ");
                        Console.WriteLine();
                        Main(null);
                    }
                }
                else if (ch == '3')//Bouns Section!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!! //O(N^2)
                {
                    if (check_solvable(arr1d, N, Rowofzero)) //O(N^2)
                    {
                        Console.WriteLine("Solving .........");
                        Console.WriteLine();
                        Bfs.readAndCalc(target_test);//solving using BFS //O(N^3)
                        Main(null);
                    }
                    else
                    {
                        Console.WriteLine(" - No Solution For The Given Board ");//O(1)
                        Console.WriteLine();//O(1)
                        Main(null);
                    }
                }
            }
        }
    }
}


