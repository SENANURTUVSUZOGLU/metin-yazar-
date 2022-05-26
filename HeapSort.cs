using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace odev23
{
    public class HeapSort
    {
        public Node root;
        public Node pointer;
        public int count;

        public HeapSort(Node[] node)
        {
            count = 0;
            for (int i = 0; i < node.Count(); i++)
            {
                Add(node[i]);
            }
        }

        public void Add(Node node)
        {
            if (root == null)
            {
                root = node;
                count++;
            }
            else
            {
                pointer = root;
                string bitcount = Convert.ToString(count + 1, 2);
                for (int i = 1; i < bitcount.Length; i++)
                {
                    if (bitcount[i] == '0')
                    {
                        if (pointer.Left == null)
                        {
                            pointer.Left == new Node(pointer);
                        }
                        pointer = pointer.Left
                    }
                    else
                    {
                        if (pointer.Right == null)
                        {
                            pointer.Right = new Node(pointer);
                        }
                        pointer = pointer.Right
                    }
                }
                pointer.Item = node.Item;
                while (true)
                {
                    if (pointer == root)
                    {
                        break;
                    }
                    if (pointer.Item < pointer.Parent.Item)
                    {
                        int tempdata = pointer.Item;
                        pointer.Item = pointer.Parent.Item;
                        pointer.Parent.Item = tempdata;
                        pointer = pointer.Parent;
                    }
                    else
                    {
                        break;
                    }
                }
                count++;
            }
        }
        public int Remove()
        {
            int output = root.Item;
            pointer = root;
            string bitcount = Convert.ToString(count, 2);
            for (int i =1; i < bitcount.Length; i++)
            {
                if (bitcount[i] == '0')
                {
                    pointer = pointer.Left;
                }
                else
                {
                    pointer = pointer.Right;
                }
            }
            root.Item = pointer.Item;
            try
            {
                if (pointer.Parent.Left == pointer)
                {
                    pointer.Parent.Left = null;
                }
                else
                {
                    pointer.Parent.Right = null;
                }
                count--;
               
            }
            catch
            {
                root = null;
            }
        }

        private void Heapify()
        {
            Node compare;
            pointer = root;
            while(true)
            {
                if (pointer.Left == null)
                {
                    break;
                }
                if (pointer.Right == null)
                {
                    compare = pointer.Left;
                }
                else
                {

                }
            }
        }
    }
}
