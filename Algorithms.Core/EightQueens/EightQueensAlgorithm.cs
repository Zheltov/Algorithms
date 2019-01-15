using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Core.EightQueens
{
    public static class EightQueensAlgorithm
    {
        public static void ClassicAlgorithm()
        {
            var queens = new List<Queen>();

            if ( ClassicAlgorithm( queens ) )
            {
                Console.WriteLine();
                Console.WriteLine( "The solve" );
                Console.Write( " ABCDEFGH" );
                for ( byte x = 0; x < 8; x++ )
                {
                    Console.WriteLine();
                    Console.Write( x + 1 );
                    for ( byte y = 0; y < 8; y++ )
                    {
                        if ( queens.Any( z => z.X == x && z.Y == y ) )
                            Console.Write( 'X' );
                        else
                            Console.Write( '-' );
                    }
                }

            }
            else
                Console.WriteLine( "Solve not found" );
        }


        static bool ClassicAlgorithm( IList<Queen> queens )
        {
            var lastQueen = queens.LastOrDefault();
            byte lastX = lastQueen != null ? lastQueen.X : (byte)0;
            byte lastY = lastQueen != null ? lastQueen.Y : (byte)0;

            if ( queens.Count == 8 )
                return true;

            var queen = new Queen();
            for ( byte x = lastX; x < 8; x++ )
            {
                queen.X = x;
                for ( byte y = x == lastX ? lastY : (byte)0; y < 8; y++ )
                {
                    queen.Y = y;
                    if ( !queen.IsIntersect( queens ) )
                    {
                        queens.Add( queen );
                        if ( ClassicAlgorithm( queens ) )
                            return true;

                        queens.Remove( queen );
                    }
                }
            }

            return false;
        }
    }
}
