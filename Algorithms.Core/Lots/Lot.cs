using System.Collections.Generic;

namespace Algorithms.Core.Lots
{
    public static class Lot
    {
        public static List<T[]> LotsOfLotGetAll<T>( this T[] items )
        {
            var result = new List<T[]>();
            foreach ( var item in items )
            {
                var n = new T[] { item };
                result.Add( n );
                var count = result.Count;
                for ( int i = 0; i < count - 1; i++ )
                {
                    var nlist = new List<T>( result[i] );
                    nlist.Add( item );
                    n = nlist.ToArray();
                    result.Add( n );
                }
            }

            return result;
        }
    }
}
