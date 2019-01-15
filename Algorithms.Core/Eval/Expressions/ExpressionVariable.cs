using System.Diagnostics;

namespace Algorithms.Core.Eval.Expressions
{
    [DebuggerDisplay( "Variable:{Value}" )]
    class ExpressionVariable : IExpression
    {
        public string Value { get; set; }

        public ExpressionVariable( string value)
        {
            Value = value;
        }

        public float Eval( Environment environment )
        {
            return environment.Variables[Value];
        }
    }
}
