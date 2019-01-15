using Algorithms.Core.Eval;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Algorithms.Test
{
    [TestClass]
    public class Eval
    {
        /// <summary>
        /// Проверка вычисления формул
        /// </summary>
        [TestMethod]
        public void Evals()
        {
            var items = new Dictionary<string, float>()
            {
                { "3 * 4 + b + 2 * 3 * 4", 41 },
                { "-(7 + 3) * 4 - 3 * (5 - 2 + 1)", -52 },
                { "1 + pow((1+a),2)", 17 }
            };

            var env = new Core.Eval.Environment()
            {
                Variables = new Dictionary<string, float>()
                {
                    {"a", 3 },
                    {"b", 5 }
                }
            };

            var ps = new Parser();
            foreach ( var kv in items )
            {
                var result = ps.Parse( kv.Key ).Eval( env );
                Assert.IsTrue( Math.Abs( result - kv.Value ) < 100 * float.Epsilon );
            }

        }
    }
}