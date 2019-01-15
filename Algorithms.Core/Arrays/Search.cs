using System;

namespace Algorithms.Core.Arrays
{
    public static class Search
    {
        public static int SearchBinary<T>( this T[] items, T value ) where T : IComparable<T>
        {
            int minIndex = 0;
            int maxIndex = items.Length - 1;

            while ( minIndex <= maxIndex )
            {
                int midIndex = ( minIndex + maxIndex ) / 2;
                var compareResult = value.CompareTo( items[midIndex] );
                if ( compareResult < 0 )
                    maxIndex = midIndex - 1;
                else if ( compareResult > 0 )
                    minIndex = midIndex + 1;
                else
                    return midIndex;
            }

            return -1;
        }
        
        public static int SearchInterpolation<T>( this T[] items, T value ) where T : struct, IComparable<T>
        {
            int minIndex = 0;
            int maxIndex = items.Length - 1;

            while ( minIndex <= maxIndex )
            {
                // смещаем середину
                int midIndex = minIndex + ( maxIndex - minIndex ) * ( (dynamic)value - (dynamic)items[minIndex] ) / ( (dynamic)items[minIndex] + (dynamic)items[maxIndex] );
                if ( midIndex <= minIndex || midIndex >= maxIndex )
                    midIndex = ( minIndex + maxIndex ) / 2;

                var compareResult = value.CompareTo( items[midIndex] );
                if ( compareResult < 0 )
                    maxIndex = midIndex - 1;
                else if ( compareResult > 0 )
                    minIndex = midIndex + 1;
                else
                    return midIndex;
            }

            return -1;
        }
    }
}
