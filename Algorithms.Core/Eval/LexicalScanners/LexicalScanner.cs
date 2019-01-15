using System.Text;

namespace Algorithms.Core.Eval.LexicalScanners
{
    class LexicalScanner
    {
        readonly string _expression;

        int _current;
        LexicalScanResult _currentResult;

        public LexicalScanResult Current { get { return _currentResult; } }

        public LexicalScanner( string expression )
        {
            _expression = expression.Replace( " ", "" );
        }

        public LexicalScanResult Next()
        {
            if ( _current >= _expression.Length )
                _currentResult = null;
            else if ( _expression[_current] == '(' )
                _currentResult = NextSingleSymbol( LexicalScanResultType.BracketOpen );
            else if ( _expression[_current] == ')' )
                _currentResult = NextSingleSymbol( LexicalScanResultType.BracketClose );
            else if ( _expression[_current] == ',' )
                _currentResult = NextSingleSymbol( LexicalScanResultType.ParameterDelimiter );
            else if ( "+-*/".Contains( _expression[_current].ToString() ) )
                _currentResult = NextSingleSymbol( LexicalScanResultType.Operation );
            else if ( "0123456789".Contains( _expression[_current].ToString() ) )
                _currentResult = NextNumeric();
            else
                _currentResult = NextFunctionOrVariable();

            return _currentResult;
        }

        LexicalScanResult NextSingleSymbol( LexicalScanResultType type )
        {
            var result = new LexicalScanResult( _expression[_current], type );
            _current++;
            return result;
        }

        LexicalScanResult NextNumeric()
        {
            var sb = new StringBuilder();
            while ( _current < _expression.Length && "0123456789.".Contains( _expression[_current].ToString() ) )
            {
                sb.Append( _expression[_current] );
                _current++;
            }

            return new LexicalScanResult( sb.ToString(), LexicalScanResultType.Numeric );
        }

        LexicalScanResult NextFunctionOrVariable()
        {
            var sb = new StringBuilder();

            while ( true )
            {
                if ( _current >= _expression.Length )
                    throw new System.IndexOutOfRangeException();

                var symbolLower = _expression[_current].ToString().ToLower();
                if ( _current < _expression.Length && "abcdefghijklmnopqrstuvwxyz_".Contains( symbolLower ) )
                {
                    sb.Append( _expression[_current] );
                    _current++;
                    continue;
                }

                if ( symbolLower == "(" )
                {
                    _current++;
                    return new LexicalScanResult( sb.ToString(), LexicalScanResultType.Function );
                }
                else
                {
                    return new LexicalScanResult( sb.ToString(), LexicalScanResultType.Variable );
                }
            }
        }
    }
}
