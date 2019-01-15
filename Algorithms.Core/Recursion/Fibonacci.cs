namespace Algorithms.Core.Recursion
{
    public static class Fibonacci
    {
        public static int ClassicRecursion( int n )
        {
            if ( n <= 1 ) return n;
            return ClassicRecursion( n - 1 ) + ClassicRecursion( n - 2 );
        }

        public static int DirectWithArray( int n )
        {
            var result = new int[n + 1];
            result[1] = 1;
            for ( int i = 2; i < n + 1; i++ )
            {
                result[i] = result[i - 1] + result[i - 2];
            }
            return result[n];
        }

        public static int Direct( int n )
        {
            var pp = 0;
            var p = 1;
            for ( int i = 2; i < n + 1; i++ )
            {
                var c = pp + p;
                pp = p;
                p = c;
            }
            return p;
        }
    }
}
 