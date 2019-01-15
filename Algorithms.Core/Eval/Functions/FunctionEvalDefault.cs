using System;

namespace Algorithms.Core.Eval.Functions
{
    public class FunctionEvalDefault : IFunctionEval
    {
        public float Eval( string name, float[] args )
        {
            name = name.ToLower();

            if ( name == "sin" )
                return (float)Math.Sin( args[0] );
            else if ( name == "pow" )
                return (float)Math.Pow( args[0], args[1] );
            else
                throw new NotImplementedException();
        }
    }
}
