using System.Diagnostics;

namespace Algorithms.Core.Eval.Expressions
{
    [DebuggerDisplay( "Literal:{Value}" )]
    class ExpressionLiteral : IExpression
    {
        public string Value { get; set; }

        public ExpressionLiteral(string value)
        {
            Value = value;
        }

        public float Eval( Environment environment )
        {
            return float.Parse( Value );
        }
    }
}
