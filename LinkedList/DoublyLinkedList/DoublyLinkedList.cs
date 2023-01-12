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
    }
}
