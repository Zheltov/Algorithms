using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Algorithms.Core.Tree
{
    [DebuggerDisplay( "{Value}" )]
    public class TreeBinary<T> where T : IComparable<T>
    {
        public T Value { get; set; }

        public TreeBinary<T> Left { get; set; }
        public TreeBinary<T> Right { get; set; }

        public TreeBinary() { }
        public TreeBinary( T value )
        {
            Value = value;
        }

        public void TraversePreOrder( Action<TreeBinary<T>> action )
        {
            if ( action == null )
                return;

            action( this );

            Left?.TraversePreOrder( action );
            Right?.TraversePreOrder( action );
        }

        public void TraverseInOrder( Action<TreeBinary<T>> action )
        {
            if ( action == null )
                return;

            Left?.TraverseInOrder( action );
            action( this );
            Right?.TraverseInOrder( action );
        }

        public void TraversePostOrder( Action<TreeBinary<T>> action )
        {
            if ( action == null )
                return;

            Left?.TraversePostOrder( action );
            Right?.TraversePostOrder( action );
            action( this );
        }

        public void TraverseDepth( Action<TreeBinary<T>> action )
        {
            if ( action == null )
                return;

            var queue = new Queue<TreeBinary<T>>();

            queue.Enqueue( this );
            while ( queue.Count > 0 )
            {
                var node = queue.Dequeue();
                action( node );

                if ( node.Left != null )
                    queue.Enqueue( node.Left );

                if ( node.Right != null )
                    queue.Enqueue( node.Right );
            }
        }

        public void OrderedAdd( T value )
        {
            if ( value.CompareTo( Value ) < 0 )
            {
                if ( Left == null )
                    Left = new TreeBinary<T>( value );
                else
                    Left.OrderedAdd( value );
            }
            else
            {
                if ( Right == null )
                    Right = new TreeBinary<T>( value );
                else
                    Right.OrderedAdd( value );
            }
        }

        public TreeBinary<T> OrderedFind( T value )
        {
            if ( value.CompareTo( Value ) == 0 )
                return this;

            if ( value.CompareTo( Value ) < 0 )
            {
                return Left?.OrderedFind( value );
            }
            else
                return Right?.OrderedFind( value );
        }
    }
}
