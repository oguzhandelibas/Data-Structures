using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace DataStructures.Tree.BST
{
    class BST<T> : IEnumerable<T>
        where T: IComparable
    {
        public Node<T> Root { get; set; }
        public BST()
        {

        }
        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
        public void Add(T value)
        {
            if (value == null)
                throw new ArgumentNullException();
            var newNode = new Node<T>(value);
            if (Root == null)
            {
                Root = newNode;
            }
            else
            {
                var current = Root;
                Node<T> parent;
                while (true)
                {
                    parent = current;
                    if (value.CompareTo(current.Value) < 0)
                    {// Left Subtree
                        current = current.Left;
                        if (current == null)
                        {
                            parent.Left = newNode;
                            break;
                        }
                    }
                    else
                    {// Right Subtree
                        current = current.Right;
                        if (current == null)
                        {
                            parent.Right = newNode;
                            break;
                        }
                    }
                }
            }
        }
    }
}
