using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Puzzel
{
    class PriorityQueue
    {
        public List<puzzel> data; //O(1)//to store the elements in the list
        public PriorityQueue()
        {
            this.data = new List<puzzel>();//O(1)//constractor to intialize 
        }
        public void Enqueue(puzzel item) //O(Log V)
        {
            data.Add(item);//O(1)// Add item in the list
            heapifyup();//O(Log V)//
        }
        public void heapifyup() //O(Log V)
        {
            int pos = data.Count - 1; //O(1)//
            while (pos > 0) //O(Log V)
            {
                int parent_index = (pos - 1) / 2; //O(1) // If child item is larger than (or equal) parent so we're done
                if (data[pos].cost.CompareTo(data[parent_index].cost) >= 0)
                    break; //O(1)
                else
                {                                                                   // Else swap parent & child
                    puzzel tmp = data[pos]; data[pos] = data[parent_index]; data[parent_index] = tmp; //O(1)
                    pos = parent_index; //O(1)
                }
            }
        }
        public puzzel Dequeue() //O(Log V)
        {
            // assumes pq is not empty; up to calling code
            int pos = data.Count - 1; // last index (before removal) //O(1)
            puzzel frontItem = data[0]; // fetch the front //O(1)
            data[0] = data[pos]; // last item be the root //O(1)
            data.RemoveAt(pos); //O(1)
            heapifydown(); //O(Log N)
            return frontItem;
        }
        //********************************************************************
        public void heapifydown() //O(Log V)
        {
            int pos = data.Count - 1; //last index (after removal) //O(1)
            int parent_index = 0; // parent index. start at front of pq //O(1)
            while (true) //O(Log V)
            {
                int child_index = parent_index * 2 + 1; // left child index of parent //O(1)
                if (child_index > pos) break; // no children so done //O(1)
                int right_child = child_index + 1; // right child //O(1)
                                                   // if there is a right child , and it is smaller than left child, use the rc instead
                if (right_child <= pos && data[right_child].cost.CompareTo(data[child_index].cost) < 0) //O(1)
                    child_index = right_child; //O(1)
                                               // If parent is smaller than (or equal to) smallest child so done
                if (data[parent_index].cost.CompareTo(data[child_index].cost) <= 0) break; //O(1)
                                                                                           // Else swap parent and child
                puzzel tmp = data[parent_index]; data[parent_index] = data[child_index]; data[child_index] = tmp; //O(1)
                parent_index = child_index; //O(1)
            }
        }
        public int Size() //O(1)
        {
            return data.Count; //O(1)
        }
        public Boolean is_empty() //O(1)
        {
            if (data.Count == 0) return true; //O(1)
            else return false; //O(1)
        }
    }
}

