using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace odev23
{
    public class BinaryTree<T> where T : IComparable<T>
    {
        public class Node : IComparable
        {
            public Node Left { get; set; }
            public Node Right { get; set; }
            public Node Parent { get; set; }
            public T Item { get; set; }

            public Node(T item)
            {
                Item = item;
            }

            public int CompareTo(object obj)
            {
                return Item.CompareTo((obj as Node).Item);
            }

            public override string ToString()
            {
                string s = string.Empty;
                if (Left != null)
                {
                    s += Left.Item;
                }
                s += "-(" + Item + ")-";
                if (Right != null)
                {
                    s += Right.Item;
                }
                return s;
            }
        }
        public Node Root { get; private set; }

        public int Size { get; private set; }

        public BinaryTree()
        {

        }

        public void Add(T item)
        {
            if (Contains(item))
            {
                throw new ArgumentException($"bu eleman zaten ağaçta bulunmakta: (item)");
            }

            Node newNode = new Node(item);
            if (Root == null)
            {
                Root = newNode;
            }
            else
            {
                AddTo(Root, newNode);
            }
            Size++;
        }
        public bool Contains(T item)
        {
            if (Root != null)
            {
                Node node = GetNode(Root, item);
                    return node != null;
            }
            return false;
        }

        public void InOrderTraversel( T Root)
        {
            //writeLine("sıralı hali :")
            if (Root != null)
            {
                InOrderTraversel(Root);
            }
        }

        public bool Remove(T item)
        {
            bool isRemoved = false;
            if (!Contains(item))
            {
                throw new Exception($"silinecek nesne ağaçta bulunmuyor: (item) ");
            }
            if (Root != null)
            {
                Node removed = GetNode(Root, item);
                // case 1:
                // leaf node
                if (removed.Left == null && removed.Right == null)
                {
                    UpdateLinks(removed, null);
                }
                // case 2:
                // does not have right child but have left child
                else if (removed.Right == null && removed.Left != null)
                {
                    UpdateLinks(removed, removed.Left);
                    removed.Left.Right = removed.Right;
                }
                // case 3:
                // has right child and it does not have a left child
                else if (removed.Right != null && removed.Right.Left == null)
                {
                    UpdateLinks(removed, removed.Right);
                    removed.Right.Left = removed.Left;
                }
                else if (removed.Right != null && removed.Right.Left != null)
                {
                    var leftMostOfRight = removed.Right.Left;
                    while (leftMostOfRight.Left != null)
                    {
                        leftMostOfRight = leftMostOfRight.Left;
                    }
                    leftMostOfRight.Parent.Left = leftMostOfRight.Right;
                    leftMostOfRight.Left = removed.Left;
                    leftMostOfRight.Right = removed.Right;

                    UpdateLinks(removed, leftMostOfRight);
                }
                isRemoved = true;
                Size--;
            }

            return isRemoved;
        }

        

        private void UpdateLinks(Node removedNode, Node newNode)
        {
            if (removedNode == Root)
            {
                Root = newNode;
            }
            else
            {
                var isLeft = removedNode.CompareTo(removedNode.Parent) < 0;
                if (isLeft)
                {
                    removedNode.Parent.Left = newNode;
                }
                else
                {
                    removedNode.Parent.Right = newNode;
                }
                if (newNode != null)
                {
                    newNode.Parent = removedNode.Parent;
                }
            }
        }

        private void AddTo(Node node, Node newNode)
        {
            if (newNode.CompareTo(node) < 0)
            {
                if (node.Left != null)
                {
                    AddTo(node.Left, newNode);
                }
                else
                {
                    node.Left = newNode;
                    newNode.Parent = node;
                }
            }
            else
            {
                if (node.Right != null)
                {
                    AddTo(node.Right, newNode);
                }
                else
                {
                    node.Right = newNode;
                    newNode.Parent = node;
                }
            }
        }

        private void InOrderTraversal(Node node)
        {
          if (node != null)
            {
                InOrderTraversel(node.Left);
                //writeLine(node.Item);
                InOrderTraversel(node.Right);
            }
        }

        private void InOrderTraversel(Node node)
        {
            throw new NotImplementedException();
        }

        private Node GetNode(Node node, T item)
        {
            if (node == null)
            {
                return null;
            }

            if (item.CompareTo(node.Item) < 0)
            {
                return GetNode(node.Left, item);
            }
            else if (item.CompareTo(node.Item) > 0)
            {
                return GetNode(node.Right, item);
            }
            else
            {
                return node;
            }
        }



    }


   
}
