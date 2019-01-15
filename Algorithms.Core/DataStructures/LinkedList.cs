using System;

namespace Algorithms.Core.DataStructures
{
    /// <summary>
    /// Связанный список
    /// </summary>
    /// <typeparam name="T">Тип</typeparam>
    public class LinkedList<T>
    {
        public LinkedList<T> Next { get; set; }
        public T Value { get; set; }

        public static LinkedList<T> Add( LinkedList<T> list, T value )
        {
            while ( list.Next != null )
                list = list.Next;

            var item = new LinkedList<T>() { Value = value };
            list.Next = item;

            return item;
        }

        public static void Remove( LinkedList<T> list, LinkedList<T> item )
        {
            if ( item == null )
                throw new ArgumentNullException( nameof( item ) );
            
            while ( list != null )
            {
                if ( list.Next == item )
                    list.Next = list.Next.Next;

                list = list.Next;
            }
        }

        public LinkedList<T> Reverse()
        {
            var result = new LinkedList<T>() { Value = Value };
            var list = Next;
            while ( list != null )
            {
                result = new LinkedList<T>() { Value = list.Value, Next = result };
                list = list.Next;
            }
            return result;
        }
    }
}
