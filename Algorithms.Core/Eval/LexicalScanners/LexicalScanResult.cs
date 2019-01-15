using System.Diagnostics;

namespace Algorithms.Core.Eval.LexicalScanners
{
    [DebuggerDisplay( "{Type}:{Value}" )]
    class LexicalScanResult
    {
        public string Value { get; set; }
        public LexicalScanResultType Type { get; set; }

        public LexicalScanResult( LexicalScanResultType type )
        {
            Type = type;
        }

        public LexicalScanResult( string value, LexicalScanResultType type )
            : this( type )
        {
            Value = value;
        }
        public LexicalScanResult( char value, LexicalScanResultType type )
            : this( value.ToString(), type )
        { }

    }
}
