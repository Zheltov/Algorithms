using System.Collections.Generic;

namespace Algorithms.Core.EightQueens
{
    class Queen
    {
        public byte X { get; set; }
        public byte Y { get; set; }


        public Queen()
        {

        }

        public Queen( byte x, byte y )
        {
            X = x;
            Y = y;
        }

        public bool IsIntersect( IEnumerable<Queen> queens )
        {
            foreach ( var queen in queens )
                if ( IsIntersect( queen ) )
                    return true;

            return false;
        }

        public bool IsIntersect( Queen queen )
        {
            // X & Y
            if ( X == queen.X || Y == queen.Y )
                return true;

            // Diagonal 1
            if ( X + Y == queen.X + queen.Y )
                return true;

            // Diagonal 2
            if ( X - Y == queen.X - queen.Y )
                return true;

            return false;
        }
    }
}
