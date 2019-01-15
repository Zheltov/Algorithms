using Algorithms.Core.Eval.Expressions;
using Algorithms.Core.Eval.LexicalScanners;
using System;
using System.Collections.Generic;

namespace Algorithms.Core.Eval
{
    public class Parser
    {
        LexicalScanner _lexicalScanner;
        string _expression;

        public IExpression Parse( string expression )
        {
            _expression = expression;
            _lexicalScanner = new LexicalScanner( expression );

            return ParseExpression();
        }

        IExpression ParseExpression()
        {
            _lexicalScanner.Next();

            return ParseBinary();
        }

        int OperationPriority( string operation )
        {
            if ( operation == null )
                return 0;
            if ( "*/".Contains( operation ) )
                return 2;
            else if ( "+-".Contains( operation ) )
                return 1;
            else
                return 0;
        }

        /// <summary>
        /// Идея: Expression Parser::parse_binary_expression(int min_priority) {
        /// https://ru.stackoverflow.com/questions/23842/%D0%9F%D0%B0%D1%80%D1%81%D0%B5%D1%80-%D0%BC%D0%B0%D1%82%D0%B5%D0%BC%D0%B0%D1%82%D0%B8%D1%87%D0%B5%D1%81%D0%BA%D0%B8%D1%85-%D0%B2%D1%8B%D1%80%D0%B0%D0%B6%D0%B5%D0%BD%D0%B8%D0%B9
        /// </summary>
        /// <param name="priorPriority"></param>
        /// <returns></returns>
        IExpression ParseBinary( int priorPriority = 0 )
        {
            var left = ParseUnary();

            while( _lexicalScanner.Current != null )
            {
                var currentPriority = OperationPriority( _lexicalScanner.Current.Value );
                if ( currentPriority <= priorPriority )
                    return left;

                var op = _lexicalScanner.Current.Value[0];
                _lexicalScanner.Next();
                var right = ParseBinary( currentPriority );
                left = new ExpressionBinary( op, left, right );
            }

            return left;
        }

        IExpression ParseUnary()
        {
            var lex = _lexicalScanner.Current;
            if ( lex.Type == LexicalScanResultType.Operation )
            {

                if ( "+-".Contains( lex.Value ) )
                {
                    var op = lex.Value;
                    _lexicalScanner.Next();
                    return new ExpressionUnary( op[0], ParseUnary() );
                }
                
            }

           return ParsePrimary();
        }

        IExpression ParsePrimary()
        {
            IExpression result;

            var lex = _lexicalScanner.Current;
            switch ( lex.Type )
            {
                case LexicalScanResultType.Numeric:
                    result = new ExpressionLiteral( lex.Value );
                    break;
                case LexicalScanResultType.Variable:
                    result = new ExpressionVariable( lex.Value );
                    break;
                case LexicalScanResultType.BracketOpen:
                    result = ParseExpression();
                    if ( _lexicalScanner.Current == null )
                        throw new IndexOutOfRangeException();
                    else if ( _lexicalScanner.Current.Type != LexicalScanResultType.BracketClose )
                        throw new NotSupportedException( $"Not expected expression {_lexicalScanner.Current.Value}, expected ')'" );
                    break;
                case LexicalScanResultType.Function:
                    var name = _lexicalScanner.Current.Value;
                    var args = new List<IExpression>();
                    while ( _lexicalScanner.Current != null && _lexicalScanner.Current.Type != LexicalScanResultType.BracketClose )
                    {
                        args.Add( ParseExpression() );
                    }
                    _lexicalScanner.Next();
                    result = new ExpressionFunction( name, args );
                    break;
                default:
                    throw new NotImplementedException();
            }

            _lexicalScanner.Next();
            return result;
        }
    }
}
