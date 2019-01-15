using System;

namespace Algorithms.Core.DataStructures
{
    public class StackOnArray<T>
    {
        private T[] items;
        private int index = 0;

        public int Capacity { get; set; }

        public StackOnArray()
            : this( 16 )
        { }

        public StackOnArray( int capacity )
        {
            Capacity = capacity;
            items = new T[Capacity];
        }

        public T Pop()
        {
            if ( index == 0 )
                throw new InvalidOperationException();

            index--;
            return items[index];
        }

        public void Push( T item )
        {
            if ( index >= items.Length )
            {
                var itemsNew = new T[items.Length + Capacity];
                for ( int i = 0; i < items.Length; i++ )
                    itemsNew[i] = items[i];
                items = itemsNew;
            }

            items[index] = item;
            index++;
        }
    }
}
