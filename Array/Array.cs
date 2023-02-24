using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DataStructures.Array
{
    public class Array<T> : IEnumerable<T>, ICloneable
    {
        private T[] InnerList;
        public int Count { get; private set; }
        public int Capacity => InnerList.Length;

        public Array()
        {
            InnerList = new T[2];
            Count = 0;
        }

        public Array(params T[] initial)
        {
            InnerList = new T[initial.Length];
            Count = 0;
            foreach (var item in initial)
                Add(item);
        }

        public Array(IEnumerable<T> collection)
        {
            InnerList = new T[collection.ToArray().Length];
            Count = 0;
            foreach (var item in collection)
                Add(item);
        }

        public void Add(T item)
        {
            if (InnerList.Length == Count)
                DoubleArray();

            InnerList[Count] = item;
            Count++;
        }

        public T RemoveLastElement()
        {
            if(Count == 0)
                throw new Exception("There is no more item to be removed from the array");

            if (InnerList.Length/4 == Count)
            {
                HalfArray();
            }

            var temp = InnerList[Count - 1];
            if(Count>0)
                Count--;

            return temp;
        }

        private void HalfArray()
        {
            if (InnerList.Length > 2)
            {
                var temp = new T[InnerList.Length / 2];
                System.Array.Copy(InnerList, temp, InnerList.Length / 4);
                InnerList = temp;
            }
        }

        public void RemoveAt(T item)
        {
            if (InnerList.Contains(item))
            {
                for (int i = 0; i < Count; i++)
                {
                    if (InnerList[i].Equals(item))
                    {
                        T[] temp1 = new T[Count];
                        T[] temp2 = new T[Count];


                        for (int j = 0; j < Count - i-1; j++)
                        {
                            temp1[j] = InnerList[j];
                        }

                        int x = 0;
                        for (int k = i + 1; k < Count; k++)
                        {  
                            temp2[x] = InnerList[k];
                            x++;
                        }

                        x = 0;
                        for (int a = Count - i-1; a < Count; a++)
                        {
                            temp1[a] = temp2[x];
                            x++;
                        }

                        InnerList = temp1;
                    }
                }
            }
            else
            {
                Console.WriteLine("Eşit Eleman Yok");
            }
        }

        public void PrintArray()
        {
            for (int i = 0; i < Count; i++)
            {
                Console.WriteLine(InnerList[i]);
            }
        }

        private void DoubleArray()
        {
            var temp = new T[InnerList.Length * 2];

            System.Array.Copy(InnerList, temp, InnerList.Length);
            InnerList = temp;
        }

        public object Clone()
        {
            //return this.MemberwiseClone();
            var arr = new Array<T>();
            foreach (var item in this)
                arr.Add(item);
            return arr;
        }
        public IEnumerator<T> GetEnumerator()
        {
            return InnerList.Take(Count).GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
