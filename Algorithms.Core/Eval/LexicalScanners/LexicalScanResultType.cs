namespace Algorithms.Core.Eval.LexicalScanners
{
    enum LexicalScanResultType
    {
        Operation,
        BracketOpen,
        BracketClose,
        Numeric,
        Function,
        ParameterDelimiter,
        Variable
    }
}
