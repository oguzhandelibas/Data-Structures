using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace DataStructures.LinkedList.DoublyLinkedList
{
    public class DoublyLinkedList<T> : IEnumerable
    {
        public DoublyLinkedListNode<T> Head { get; set; }
        public DoublyLinkedListNode<T> Tail { get; set; }
        public DoublyLinkedList()
        {

        }

        public DoublyLinkedList(IEnumerable<T> collection)
        {
            foreach (var item in collection)
            {
                AddLast(item);
            }
        }

        private bool isHeadNull => Head == null;
        private bool isTailNull => Tail == null;
        public void AddFirst(T value)
        {
            var newNode = new DoublyLinkedListNode<T>(value);
            newNode.Next = null;
            newNode.Prev = null;

            if (!isHeadNull)
            {
                Head.Prev = newNode;

            }

            newNode.Next = Head;
            newNode.Prev = null;
            Head = newNode;

            if (isTailNull) Tail = Head;
        }
        public void AddLast(T value)
        {
            if (isTailNull)
            {
                AddFirst(value);
                return;
            }

            var newNode = new DoublyLinkedListNode<T>(value);

            newNode.Next = null;
            newNode.Prev = Tail;
            Tail = newNode;
            return;
        }
        public void AddAfter(DoublyLinkedListNode<T> refNode,
            DoublyLinkedListNode<T> newNode)
        {
            if (refNode == null)
                throw new ArgumentNullException();

            if (refNode == Head && refNode == Tail)
            {
                refNode.Next = newNode;
                refNode.Prev = null;

                newNode.Next = null;
                newNode.Prev = refNode;

                Head = refNode;
                Tail = newNode;
                return;
            }

            if (refNode != Tail)
            {
                newNode.Next = refNode.Next;
                newNode.Prev = refNode;

                refNode.Next.Prev = newNode;
                refNode.Next = newNode;
            }
            else
            {
                newNode.Next = null;
                newNode.Prev = refNode;

                refNode.Next = newNode;

                Tail = newNode;
            }
        }
        public void AddBefore(DoublyLinkedListNode<T> refNode,
            DoublyLinkedListNode<T> newNode)
        {
            if (refNode == null)
                throw new ArgumentNullException();

            if (refNode == Head && refNode == Tail)
            {
                newNode.Next = refNode;
                newNode.Prev = null;

                refNode.Prev = newNode;
                refNode.Next = null;

                Tail = refNode;
                Head = newNode;
            }

            if (refNode == Head)
            {
                refNode.Prev = newNode;

                newNode.Next = Head;
                newNode.Prev = null;

                Head = newNode;
            }
            else if (refNode != Tail)
            {
                var refPrevNode = refNode.Prev;

                newNode.Next = refNode;
                newNode.Prev = refPrevNode;

                refNode.Prev = newNode;

                refPrevNode.Next = newNode;

            }
            else
            {
                var tailPrevNode = Tail.Prev;

                newNode.Prev = refNode.Prev;
                newNode.Next = refNode;

                tailPrevNode.Next = newNode;

                refNode.Prev = newNode;
                refNode.Next = null;

            }
        }

        public List<DoublyLinkedListNode<T>> GetAllNodes()
        {
            var list = new List<DoublyLinkedListNode<T>>();
            var current = Head;

            while (current != null)
            {
                list.Add(current);
                current = current.Next;
            }
            return list;
        }

        public IEnumerator GetEnumerator()
        {
            return GetAllNodes().GetEnumerator();
        }

        public void RemoveFirst()
        {
            if (isHeadNull)
                throw new Exception("");

            if (Head == Tail)
            {
                Head = null;
                Tail = null;
            }
            else
            {
                Head = Head.Next;
                Head.Prev = null;
            }
        }
        public void RemoveLast()
        {
            if (isTailNull)
                throw new Exception("Empty List");

            if (Tail == Head)
            {
                Head = null;
                Tail = null;
            }
            else
            {
                Tail.Prev.Next = null;
                Tail = Tail.Prev;
            }
        }
        public void Delete(T value)
        {
            if (isHeadNull)
                throw new Exception("Empty List");

            if (Head == Tail)
            {
                if (Head.Value.Equals(value))
                {
                    RemoveFirst();
                }
                return;
            }

            var current = Head;
            while (current != null)
            {
                if (current.Value.Equals(value))
                {
                    if (current.Prev == null)
                    {
                        current.Next.Prev = null;
                        Head = current.Next;
                    }
                    else if (current.Next == null)
                    {
                        current.Prev.Next = null;
                        Tail = current.Prev;
                    }
                    else
                    {
                        current.Prev.Next = current.Next;
                        current.Next.Prev = current.Prev;
                    }
                    break;
                }
                current = current.Next;
            }
        }
    }
}
