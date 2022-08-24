using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
namespace Puzzel
{
    class AS
    {
        private List<puzzel> Solution_Route;// To save every Step in the solution route    
        private List<puzzel> Based_List;// To store every node that i deleted from the main
        private PriorityQueue Main_List;// To store every in it to set the min hur in the top and eleted it
        private Dictionary<string, puzzel> Main_Map;//to search fast
        private Dictionary<string, puzzel> Based_Map;//to search fast
        private Stopwatch st;
        public AS()//to intialize structures O(1)
        {
             st = new Stopwatch();
                Based_List = new List<puzzel>();//O(1) Intialize The list that contain the deleted nodes
            Solution_Route = new List<puzzel>();//O(1) Intialize the dict the declare the status of each node
            Main_Map = new Dictionary<string, puzzel>();//O(1) Intialize the main dect
            Based_Map = new Dictionary<string, puzzel>();//O(1) intialize the base dict
            Main_List = new PriorityQueue();//O(1) intialize the pq
        }
        //*******************************************************
        public void A_Star(puzzel start,string kind)//Total complexity O(E*log(v)) num of itr=E * Body Log(v)
        {
            Main_List.Enqueue(start);//O(Log(V)) Insert the first node in the priority queue 
            Main_Map.Add(start.key, start);//O(1) to insert the node key string in the dictionary
            while (!Main_List.is_empty())//O(E))//to check that the queue empty or not
            {
                st.Start();
                puzzel temp = Main_List.Dequeue();//O(1)  Delete the 
                puzzel current = new puzzel(temp, 0);//O(1) Create the puzzle of child
                if (!check_in_Based(current))//O(1) Check if it found in 
                {
                    Based_List.Add(current);//O(1) insert it in the based
                    Based_Map.Add(current.key, current);//O(1) insert it in the dict
                    Find_Neighboors(current,kind);//O(1) find the neigboors of the child t
                }
            }
        }
        //*******************************************************
        public void Find_Neighboors(puzzel p,string kind)//O(1) To generate the child 
        {
            if (p.Check("Left"))//O(1) Check if I can move it to Left
            {
                puzzel ch = new puzzel(p);//O(1) Create new node
                ch.Move("Left");//O(1) // Moving the node to left
                if (kind == "manhattan")//check if user Choose Manhattan 
                {
                    ch.Generate_Man();//O(N^2) Generate the manhattan of the node
                    ch.Calc_Min_Cost_Man();//O(1) Calculate the Cost of the node
                    if (ch.Manhattan_rech_goal())//O(1) check if i Reach the Goal
                    {
                        ch.direction = "GOAL";//O(1) give it direction
                        // Add Goal Board
                        Solution_Route.Add(ch);//O(1)
                        Get_Route(ch);//O(1)
                    }
                }
                else
                {
                    ch.Generate_Hamming();//O(N^2)
                    ch.Calc_Min_Cost_Hamm();//O(1)
                    if (ch.Hamming_Rech_Goal())//O(1)
                    {
                        ch.direction = "Goal";//O(1)
                        // Add Goal Board
                        Solution_Route.Add(ch);//O(1)
                        Get_Route(ch);//O(1)
                    }
                }
                ch.direction = "Left";//O(1)
                
                //check if child in Main list or not
                bool flag;//O(1)
                flag = check_in_Main(ch);//O(1)
                if (flag == false) {//O(1)
                    Main_List.Enqueue(ch);//O(Log(v)
                    Main_Map.Add(ch.key, ch);//O(1)
                }

            }
            if (p.Check("Right"))//O(1)
            {
                puzzel c = new puzzel(p);//O(1)
                c.Move("Right");//O(1)
                if (kind == "manhattan")//O(1)
                {
                    c.Generate_Man();//O(N^2)
                    c.Calc_Min_Cost_Man();//O(1)
                    if (c.Manhattan_rech_goal())//O(1)
                    {
                        c.direction = "Goal";//O(1)
                        // Add Goal Board
                        Solution_Route.Add(c);//O(1)
                        Get_Route(c);//O(1)
                    }
                }
                else
                {
                    c.Generate_Hamming();//O(n^2)
                    c.Calc_Min_Cost_Hamm();//O(1)
                    if (c.Hamming_Rech_Goal())//O(1)
                    {
                        c.direction = "Goal";//O(1)
                        // Add Goal Board
                        Solution_Route.Add(c);//O(1)
                        Get_Route(c);//O(1)
                    }
                }
                c.direction = "Right";//O(1)
                //check if child in open list or not
                bool flag;//O(1)
                flag = check_in_Main(c);//O(1)
                if (flag == false)//O(1)
                {
                    Main_List.Enqueue(c);////O(Log(V)) 
                    Main_Map.Add(c.key, c);//O(1)
                }
            }
            if (p.Check("Up"))//O(1)
            {
                puzzel c = new puzzel(p);//O(1)
                c.Move("Up");//O(1)
                if (kind == "manhattan")//O(1)
                {
                    c.Generate_Man();//O(N^2)
                    c.Calc_Min_Cost_Man();//O(1)
                    if (c.Manhattan_rech_goal())//O(1)
                    {
                        c.direction = "Goal";//O(1)
                        Solution_Route.Add(c);//O(1)
                        Get_Route(c);//O(1)
                    }
                }
                else
                {
                    c.Generate_Hamming();//O(N^2)
                    c.Calc_Min_Cost_Hamm();//O(1)
                    if (c.Hamming_Rech_Goal())//O(1)
                    {
                        c.direction = "Goal";//O(1)
                        Solution_Route.Add(c);//O(1)
                        Get_Route(c);//O(1)
                    }
                }
                c.direction = "Up";//O(1)
                bool flag;//O(1)
                flag = check_in_Main(c);//O(1)
                if (flag == false) 
                { Main_List.Enqueue(c); //O(Log(V))
                    Main_Map.Add(c.key, c);////O(1)
                }
             
            }
            if (p.Check("Down"))//O(1)
            {
                puzzel c = new puzzel(p);//O(1)
                c.Move("Down");//O(1)
                if (kind == "manhattan")//O(1)
                {
                    c.Generate_Man();//O(1)
                    c.Calc_Min_Cost_Man();//O(1)
                    if (c.Manhattan_rech_goal())//O(1)
                    {
                        c.direction = "Goal";//O(1)
                        Solution_Route.Add(c);//O(1)
                        Get_Route(c);//O(1)
                    }
                }
                else
                {
                    c.Generate_Hamming();//O(N^2)
                    c.Calc_Min_Cost_Hamm();//O(1)
                    if (c.Hamming_Rech_Goal())//O(1)
                    {
                        c.direction = "Goal";//O(1)
                        Solution_Route.Add(c);//O(1)
                        Get_Route(c);//O(1)
                    }
                }
                c.direction = "Down";//O(1)
                //check if child in open list or not
                bool flag;//O(1)
                flag = check_in_Main(c);//O(1)
                if (flag == false)
                {//O(1)
                    Main_List.Enqueue(c);//O(log(V)
                    Main_Map.Add(c.key, c);//O(1)
                }
            }
        }
        //**********************************************
        public bool check_in_Based(puzzel c)//O(1) Check if it found in the based or not
        {
            if (Based_Map.ContainsKey(c.key))//O(1)
            {
                puzzel _key = Based_Map[c.key];//O(1)
                if (_key.cost < c.cost) {//O(1)
                    Main_List.Enqueue(_key);//O(1)
                    Main_Map.Add(_key.key, _key);//O(1)
                }
                return true;//O(1)
            }
            return false;//O(1)
        }
        //**********************************************
        public bool check_in_Main(puzzel c)
        {
                   
            return Main_Map.ContainsKey(c.key);//O(1)
        }

        //**************************************************
        public void display_Solution_Route()//O(1)
        {
            int n = Solution_Route.Count();//O(1)
            int Steps = n - 1;//O(1)
            for (int i = Steps; i >= 0; i--)//O(1)
            {
                Solution_Route[i].display();
            }
            Console.WriteLine(" - Num of Moves = " + Steps);////O(1)
            Console.WriteLine();//O(1)
            if (Steps == Program.moves)//O(1)
            {
                Console.WriteLine("Congratulation !!!!!");//O(1)
                Console.WriteLine();//O(1)
            }
            else Console.WriteLine("Wrong answer Expected " + Steps + " Recived " + Program.moves);//O(1)
            Program.Main(null);
        }
        //**************************************************
        public void Get_Route(puzzel goal)//O(1)
        {

            st.Stop();
            Console.WriteLine("Time : " + st.Elapsed);
            // Get Path
            puzzel p = goal.parent;//O(1)
            while (p.parent != null)//O(1)
            {

                Solution_Route.Add(p);//O(1)
                p = p.parent;//O(1)
            }
            // Add Start Board
            Solution_Route.Add(p);//O(1)
            // call Display Solution_Route
            display_Solution_Route();//O(1)
        }
        //*****************************************************
    }
}
