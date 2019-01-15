using System;

namespace Algorithms.Core.DataStructures
{
    public class StackOnLinkedList<T>
    {
        readonly LinkedList<T> items = new LinkedList<T>();

        public T Pop()
        {
            var item = items;
            while ( item.Next != null )
            {
                if ( item.Next.Next == null )
                {
                    // Нашли предпоследний элемент
                    var result = item.Next.Value;
                    item.Next = null;

                    return result;
                }

                item = item.Next;
            }

            throw new InvalidOperationException();
        }

        public void Push( T item )
        {
            LinkedList<T>.Add( items, item );
        }

    }
}
