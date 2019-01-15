using Algorithms.Core.Eval.Functions;
using System.Collections.Generic;

namespace Algorithms.Core.Eval
{
    public class Environment
    {
        public IDictionary<string, float> Variables { get; set; }
        public IFunctionEval FunctionEval { get; set; }

        public Environment()
            : this( new Dictionary<string, float>() )
        { }

        public Environment( IDictionary<string, float> variables )
            : this( new FunctionEvalDefault(), variables )
        { }

        public Environment( IFunctionEval functionEval, IDictionary<string, float> variables )
        {
            Variables = variables;
            FunctionEval = functionEval;
        }
    }
}
