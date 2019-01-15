using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Algorithms.Core.Eval.Expressions
{
    [DebuggerDisplay( "Function:{Name}" )]
    class ExpressionFunction : IExpression
    {
        public string Name { get; set; }
        public IList<IExpression> Args { get; set; }

        public ExpressionFunction( string name )
        {
            Name = name;
        }

        public ExpressionFunction( string name, IList<IExpression> args )
            : this( name )
        {
            Args = args;
        }
        public float Eval( Environment environment )
        {
            return environment.FunctionEval.Eval( Name, Args.Select( x => x.Eval( environment ) ).ToArray() );
        }
    }
}
