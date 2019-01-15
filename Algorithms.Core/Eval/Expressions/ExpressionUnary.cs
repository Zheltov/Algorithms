using System;
using System.Diagnostics;

namespace Algorithms.Core.Eval.Expressions
{
    [DebuggerDisplay( "Unary:{Operation.ToString()}" )]
    class ExpressionUnary : IExpression
    {
        public char Operation { get; set; }
        public IExpression Expression { get; set; }

        public ExpressionUnary( char operation, IExpression expression )
        {
            Operation = operation;
            Expression = expression;
        }

        public float Eval( Environment environment )
        {
            switch ( Operation )
            {
                case '+':
                    return +Expression.Eval( environment );
                case '-':
                    return -Expression.Eval( environment );
                default:
                    throw new NotSupportedException();
            }
        }
    }
}
