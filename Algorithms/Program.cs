using System;
using System.Linq;
using Algorithms.Core.Lots;
using Algorithms.Core.DataStructures;

namespace Algorithms
{
    partial class Program
    {
        static void Main( string[] args )
        {

            var list = new LinkedList<int>();
            var current = list;
            for ( int i = 1; i < 5; i++ )
            {
                current.Next = new LinkedList<int>() { Value = i };
                current = current.Next;
            }
            //current.Next.Value = 6;

            current = list;
            while ( current != null )
            {
                Console.Write( string.Format( "{0}, ", current.Value ) );
                current = current.Next;
            }
            Console.WriteLine();

            current = Reverse( list );
            while ( current != null )
            {
                Console.Write( string.Format( "{0}, ", current.Value ) );
                current = current.Next;
            }

            Console.WriteLine( "Press any key..." );
            Console.ReadKey();
        }

        static LinkedList<T> Reverse<T>( LinkedList<T> list )
        {
            var result = new LinkedList<T>() { Value = list.Value };
            list = list.Next;
            while ( list != null )
            {
                result = new LinkedList<T>() { Value = list.Value, Next = result };
                list = list.Next;

                //var next = list.Next;
                //var nextNext = 
                //if ( list.Next == null )
                //    return list;

            }
            return result;
        }

    }
}
