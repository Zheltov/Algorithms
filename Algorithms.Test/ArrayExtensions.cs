using Algorithms.Core.Arrays.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Algorithms.Test
{
    [TestClass]
    public class ArrayExtensions
    {
        /// <summary>
        /// Проверка MoveWithShift операции над массивами
        /// </summary>
        [TestMethod]
        public void ArrayExtensionsInsertWithShift()
        {
            var source = new int[] { 7, 5, 6, 1, 3, 2, 8, 0 };
            source.MoveWithShift( 5, 2 );
            CollectionAssert.AreEqual( source, new int[] { 7, 5, 2, 6, 1, 3, 8, 0 } );

            source.MoveWithShift( 2, 5 );
            CollectionAssert.AreEqual( source, new int[] { 7, 5, 6, 1, 3, 2, 8, 0 } );
        }

        /// <summary>
        /// Проверка Swap операции над массивами
        /// </summary>
        [TestMethod]
        public void ArrayExtensionsSwap()
        {
            var source = new int[] { 7, 5, 6, 1, 3, 2, 8, 0 };
            source.Swap( 5, 2 );

            CollectionAssert.AreEqual( source, new int[] { 7, 5, 2, 1, 3, 6, 8, 0 } );
        }
    }
}
