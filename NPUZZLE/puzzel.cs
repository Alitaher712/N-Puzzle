using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Puzzel
{
    class puzzel
    {
        private int Size; //O(1)

        private int Number_Of_Levels; //O(1)
        private int Row_index_of_zero; //O(1)
        private int Manhattan_Sum; //O(1)
        public string direction; //O(1)
        public int cost; //O(1) 
        private int Col_index_of_zero; //O(1) 
        private int Hamming_Sum; //O(1)
        public int[,] Node2d; //O(1)
        public puzzel parent; //O(1)
        public string key = ""; //O(1)
        //initial constructor 
        public puzzel(int size, int[,] puzz, int r, int c) //O(N^2)
        {
            this.Size = size; //O(1)
            this.Node2d = new int[Size, Size]; //O(1)
            for (int i = 0; i < size; i++) //O(N^2)
            {
                for (int j = 0; j < size; j++) //O(N)
                {
                    this.Node2d[i, j] = puzz[i, j]; //O(1)
                    this.key += puzz[i, j]; //O(1)
                }
            }
            this.direction = "Root"; //O(1)
            this.Row_index_of_zero = r;//O(1) 
            this.Col_index_of_zero = c; //O(1)
            this.Number_Of_Levels = 0; //O(1)

            this.parent = null; //O(1)
        }
        //*******************************************************************
        //child constructor 
        public puzzel(puzzel p) //O(N^2)
        {
            this.Size = p.Size; //O(1)
            this.Node2d = new int[Size, Size]; //O(1)
            for (int i = 0; i < this.Size; i++) //O(N^2)
            {
                for (int j = 0; j < this.Size; j++) //O(1)
                {

                    this.Node2d[i, j] = p.Node2d[i, j]; //O(1)
                }
            }
            this.Row_index_of_zero = p.Row_index_of_zero; //O(1) 
            this.Col_index_of_zero = p.Col_index_of_zero; //O(1)
            this.Number_Of_Levels = p.Number_Of_Levels + 1; //O(1)
            this.parent = p.parent; //O(1)

        }
        //*******************************************************************
        //Equal constructor 
        public puzzel(puzzel p, int _default) //O(N^2)
        {
            this.Size = p.Size; //O(1)
            this.Node2d = new int[Size, Size]; //O(1)
            for (int i = 0; i < this.Size; i++) //O(N^2)
            {
                for (int j = 0; j < this.Size; j++) //O(N)
                {

                    this.Node2d[i, j] = p.Node2d[i, j]; //O(1)
                }
            }
            this.Row_index_of_zero = p.Row_index_of_zero; //O(1)
            this.Col_index_of_zero = p.Col_index_of_zero; //O(1)
            this.Number_Of_Levels = p.Number_Of_Levels; //O(1)
            this.Hamming_Sum = p.Hamming_Sum; //O(1)
            this.Manhattan_Sum = p.Manhattan_Sum; //O(1)
            this.cost = p.cost; //O(1)
            this.parent = p; //O(1)
            this.key = p.key;//O(1)

        }

        //*******************************************************************
        //calc min cost using hamming 
        public void Calc_Min_Cost_Hamm() //O(1)
        {
            this.cost = this.Number_Of_Levels + this.Hamming_Sum; //O(1)
        }
        //*******************************************************************
        //calc min cost using manhattan 
        public void Calc_Min_Cost_Man() //O(1)
        {
            this.cost = this.Number_Of_Levels + this.Manhattan_Sum; //O(1)
        }
        public bool Hamming_Rech_Goal()//O(1)
        {
            return this.Hamming_Sum == 0; //O(1)
        }
        public bool Manhattan_rech_goal() //O(1)
        {
            return this.Manhattan_Sum == 0; //O(1)
        }
        //*******************************************************************
        public puzzel Move(string type) //O(1)
        {
            if (type == "Left") //O(1)
            {
                this.Node2d[this.Row_index_of_zero, this.Col_index_of_zero] = this.Node2d[this.Row_index_of_zero, this.Col_index_of_zero - 1];
                this.Node2d[this.Row_index_of_zero, this.Col_index_of_zero - 1] = 0; //O(1)
                //catch blank_tile
                this.Col_index_of_zero = this.Col_index_of_zero - 1; //O(1)
            }
            else if (type == "Right") //O(1)
            {
                this.Node2d[this.Row_index_of_zero, this.Col_index_of_zero] = this.Node2d[this.Row_index_of_zero, this.Col_index_of_zero + 1];
                this.Node2d[this.Row_index_of_zero, this.Col_index_of_zero + 1] = 0; //O(1)
                //catch blank_tile
                this.Col_index_of_zero = this.Col_index_of_zero + 1; //O(1)
            }
            else if (type == "Up") //O(1) 
            {
                this.Node2d[this.Row_index_of_zero, this.Col_index_of_zero] = this.Node2d[this.Row_index_of_zero - 1, this.Col_index_of_zero];
                this.Node2d[this.Row_index_of_zero - 1, this.Col_index_of_zero] = 0; //O(1)
                //catch blank_tile
                this.Row_index_of_zero = this.Row_index_of_zero - 1; //O(1)
            }
            else if (type == "Down") //O(1)
            {
                this.Node2d[this.Row_index_of_zero, this.Col_index_of_zero] = this.Node2d[this.Row_index_of_zero + 1, this.Col_index_of_zero];
                this.Node2d[this.Row_index_of_zero + 1, this.Col_index_of_zero] = 0; //O(1)
                //catch blank_tile
                this.Row_index_of_zero = this.Row_index_of_zero + 1; //O(1)
            }
            return this;
        }
        public bool Check(string type) //O(1)
        {
            if (type == "Left") //O(1)
            {
                if (this.Col_index_of_zero != 0) //O(1)
                    return true; //O(1) 
                return false;
            }
            else if (type == "Right") //O(1)
            {
                if (this.Col_index_of_zero != this.Size - 1) //O(1)
                    return true;
                return false;
            }
            else if (type == "Up") //O(1)
            {
                if (this.Row_index_of_zero != 0) //O(1)
                    return true; //O(1)
                return false;
            }
            else if (type == "Down") //O(1)
            {
                if (this.Row_index_of_zero != this.Size - 1) //O(1)
                    return true; //O(1)
                return false;
            }
            else
            {
                return true; //O(1)
            }

        }
        public void Generate_Hamming() //O(N^2)
        {
            int counter = 1; //O(1)
            for (int i = 0; i < this.Size; i++) //O(1)
            {
                for (int j = 0; j < this.Size; j++) //O(1)
                {
                    this.key += this.Node2d[i, j]; //O(1)
                    if (this.Node2d[i, j] != counter && this.Node2d[i, j] != 0) { this.Hamming_Sum++; } //O(1)
                    counter++; //O(1)
                }
            } 
        }
        //********************************************************************
        public void display() //O(N^2)
        {
            for (int i = 0; i < this.Size; i++) //O(N^2)
            {
                for (int j = 0; j < this.Size; j++) //O(N)
                {
                    Console.Write(this.Node2d[i, j]); //O(1)
                    Console.Write(" ");
                }
                if (i == 0) { Console.WriteLine("         " + this.direction); } //O(1)
                else { Console.WriteLine(); }
            }
            Console.WriteLine();
        }

        //**********************************************************************
      
        //**********************************************************************
        public void Generate_Man() //O(N^2)
        {
            int count = 0; //O(1)
            int expected = 0; //O(1)
            for (int row = 0; row < this.Size; row++) //ON^2)
            {

                for (int col = 0; col < this.Size; col++) //O(N)
                {
                    this.key += this.Node2d[row, col]; //O(1)
                    int value = this.Node2d[row, col]; //O(1)
                    expected++; //O(1)
                    if (value != 0 && value != expected) //O(1)
                    {

                        count += Math.Abs(row - ((value - 1) / this.Size)) //O(1)
                                + Math.Abs(col - ((value - 1) % this.Size));
                    }
                }
            }

            this.Manhattan_Sum = count; //O(1)
        }
       
    }
}