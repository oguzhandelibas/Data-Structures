using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace DataStructures.LinkedList.SinglyLinkedList
{
    public class SinglyLinkedList<T>: IEnumerable<T>
    {
        public SinglyLinkedList()
        {}

        public SinglyLinkedList(IEnumerable<T> collection)
        {
            foreach (var item in collection)
            {
                this.AddFirst(item);
            }
        }

        public SinglyLinkedListNode<T> Head { get; set; }
        private bool isHeadNull => Head == null;
        public void AddFirst(T value)
        {
            var newNode = new SinglyLinkedListNode<T>(value);
            newNode.Next = Head;
            Head = newNode;
        }

        public void AddLast(T value)
        {
            var newNode = new SinglyLinkedListNode<T>(value);
            var current = Head;

            if (isHeadNull)
            {
                Head = newNode;
                return;
            }

            while (current != null) 
            {
                current = current.Next;
            }

            current.Next = newNode;
        }

        public void AddAfter(SinglyLinkedListNode<T> node, T value)
        {
            if(node == null) throw new ArgumentException("Node is null");
            if (isHeadNull) { AddFirst(value); return;}

            var newNode = new SinglyLinkedListNode<T>(value);
            var current = Head;

            while (current!=null)
            {
                if (current.Equals(node))
                {
                    newNode.Next = current.Next;
                    current.Next = newNode;
                    return;
                }
                current = current.Next;
            }
            throw new ArgumentException("The reference node is not exist in this list");
        }

        public void AddAfter(SinglyLinkedListNode<T> refNode, SinglyLinkedListNode<T> newNode)
        {
            if (newNode == null || refNode == null) throw new ArgumentException("Node is null");
            if (isHeadNull) { AddFirst(refNode.Value); return; }

            var current = Head;
            while (current!=null)
            {
                //53 33 12 23
                if (current.Equals(refNode))
                {
                    newNode.Next = refNode.Next;
                    refNode.Next = newNode;
                    return;
                }
                current = current.Next;
            }
            throw new ArgumentException("The reference node is not exist in this list");
        }

        public void AddBefore(SinglyLinkedListNode<T> node, T value)
        {
            if (node == null) throw new ArgumentException("Node is null");
            if (isHeadNull) { AddFirst(value); return; }

            var newNode = new SinglyLinkedListNode<T>(value);
            var current = Head;
            var prev = current;

            while (current != null)
            {
                if (current.Equals(node))
                {
                    prev.Next = newNode;
                    newNode.Next = current;
                    return;
                }
                prev = current;
                current = current.Next;
            }
            throw new ArgumentException("The reference node is not exist in this list");
        }

        public void AddBefore(SinglyLinkedListNode<T> refNode, SinglyLinkedListNode<T> newNode)
        {
            if (refNode == null) throw new ArgumentException("Node is null");
            if (isHeadNull) { AddFirst(newNode.Value); return; }

            var current = Head;
            var prev = current;

            while (current != null)
            {
                if (current.Equals(refNode))
                {
                    prev.Next = newNode;
                    newNode.Next = current;
                    return;
                }
                prev = current;
                current = current.Next;
            }
            throw new ArgumentException("The reference node is not exist in this list");
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new SinglyLinkedListEnumerator<T>(Head);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    
        public void RemoveFirst()
        {
            if(isHeadNull) throw new ArgumentException("The List is Null");
            Head = Head.Next;
        }

        public void RemoveLast()
        {
            if(isHeadNull) throw new ArgumentException("There is no item to remove!");
            var current = Head;
            var prev = current;

            while (current.Next != null)
            {
                prev = current;
                current = current.Next;
            }
            prev.Next = null;

        }
    
        public void Remove(T value)
        {
            if (isHeadNull)
                throw new Exception("Underflow! Nothing to remove.");

            if (value == null)
                throw new ArgumentException();

            var current = Head;
            SinglyLinkedListNode<T> prev = null;

            do
            {
                if (current.Value.Equals(value))
                {
                    if (current.Next == null)
                    {
                        if (prev == null)
                        {
                            Head = null;
                            return;
                        }
                        else
                        {
                            prev.Next = null;
                            return;
                        }
                    }
                    else
                    {
                        if (prev == null)
                        {
                            RemoveFirst();
                            return;
                        }
                        else
                        {
                            prev.Next = current.Next;
                            return;
                        }
                    }
                }
                prev = current;
                current = current.Next;
            } while (current != null);

            throw new ArgumentException("The value could not be found in the list");
        }
    }
}
