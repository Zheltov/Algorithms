using System;
using System.Diagnostics;

namespace Algorithms.Core.Eval.Expressions
{
    [DebuggerDisplay( "Binary:{Operation.ToString()}" )]
    class ExpressionBinary : IExpression
    {
        public char Operation { get; set; }
        public IExpression Left { get; set; }
        public IExpression Right { get; set; }

        public ExpressionBinary( char operation )
        {
            Operation = operation;
        }

        public ExpressionBinary( char operation, IExpression left, IExpression right )
            : this(operation)
        {
            Left = left;
            Right = right;
        }

        public float Eval( Environment environment )
        {
            switch ( Operation )
            {
                case '+':
                    return Left.Eval( environment ) + Right.Eval( environment );
                case '-':
                    return Left.Eval( environment ) - Right.Eval( environment );
                case '*':
                    return Left.Eval( environment ) * Right.Eval( environment );
                case '/':
                    return Left.Eval( environment ) / Right.Eval( environment );
                default:
                    throw new NotSupportedException();
            }
        }
    }
}
