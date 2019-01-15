using Algorithms.Core.Arrays;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace Algorithms.Test
{
    [TestClass]
    public class Arrays
    {
        /// <summary>
        /// Проверка сортировки массивов вставкой 
        /// </summary>
        [TestMethod]
        public void ArraySortByInsert()
        {
            var source = new int[] { 7, 5, 6, 1, 3, 2, 8, 0 };
            var result = new int[] { 0, 1, 2, 3, 5, 6, 7, 8 };

            Sort.SortByInsert( source );

            CollectionAssert.AreEqual( source, result );
        }

        /// <summary>
        /// Проверка сортировки массивов выбором
        /// </summary>
        [TestMethod]
        public void ArraySortByChoose()
        {
            var source = new int[] { 7, 5, 6, 1, 3, 2, 8, 0 };
            var result = new int[] { 0, 1, 2, 3, 5, 6, 7, 8 };

            Sort.SortByChoose( source );

            CollectionAssert.AreEqual( source, result );
        }

        /// <summary>
        /// Проверка сортировки массивов пузырьком
        /// </summary>
        [TestMethod]
        public void ArraySortBubble()
        {
            var source = new int[] { 7, 5, 6, 1, 3, 2, 8, 0 };
            var result = new int[] { 0, 1, 2, 3, 5, 6, 7, 8 };

            Sort.SortBubble( source );

            CollectionAssert.AreEqual( source, result );
        }

        /// <summary>
        /// Проверка пирамидальной сортировки массивов 
        /// </summary>
        [TestMethod]
        public void ArraySortHeap()
        {
            var source = new int[] { 7, 5, 6, 1, 3, 2, 8, 0 };
            var result = new int[] { 0, 1, 2, 3, 5, 6, 7, 8 };

            Sort.SortHeap( source );

            CollectionAssert.AreEqual( source, result );
        }

        /// <summary>
        /// Проверка быстрой сортировки массива на основе стэков
        /// </summary>
        [TestMethod]
        public void SortQuickWithStack()
        {
            var source = new int[] { 7, 1, 10, 4, 6, 9, 2, 11, 3, 5, 12, 8, 15 };

            Sort.SortQuickWithStack( source );

            CollectionAssert.AreEqual( source, source.OrderBy( x => x ).ToArray() );
        }

        /// <summary>
        /// Проверка бинарного поиска
        /// </summary>
        [TestMethod]
        public void SearchBinary()
        {
            var source = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            Assert.AreEqual( 4, source.SearchBinary( 5 ) );
            Assert.AreEqual( 0, source.SearchBinary( 1 ) );
            Assert.AreEqual( 8, source.SearchBinary( 9 ) );
            Assert.AreEqual( -1, source.SearchBinary( 10 ) );
            Assert.AreEqual( -1, source.SearchBinary( 0 ) );
        }

        /// <summary>
        /// Проверка интерполяционного поиска
        /// </summary>
        [TestMethod]
        public void SearchInterpolation()
        {
            const int length = 100;
            var source = new int[length];

            for ( int i = 0; i < length; i++ )
                source[i] = i * i + i;

            for ( int i = 0; i < length; i = i + 10 )
                Assert.AreEqual( i, source.SearchInterpolation( source[i] ) );
        }
    }
}