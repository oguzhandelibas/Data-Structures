using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures.LinkedList.DoublyLinkedList
{
    public class DoublyLinkedList<T>
    {
        public DoublyLinkedListNode<T> Head { get; set; }
        public DoublyLinkedListNode<T> Tail { get; set; }
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
    }
}
