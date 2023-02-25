using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures.Tree.BST
{
    public class Node<T>
    {
        public int Value { get; set; }
        public Node<T> Left { get; set; }
        public Node<T> Right { get; set; }
        public Node()
        {

        }
        public Node(T value)
        {

        }
        public override string ToString()
        {
            return $"{Value}";
        }
    }
}
