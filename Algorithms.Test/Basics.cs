using Algorithms.Core.Basics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Algorithms.Test
{
    [TestClass]
    public class Basics
    {
        /// <summary>
        /// Проверка алгоритма золотого треугольника
        /// </summary>
        [TestMethod]
        public void GoldenTriangle()
        {
            var triangle = new int[][]
            {
                new int[] { 7 },
                new int[] { 2, 3 },
                new int[] { 3, 3, 1 },
                new int[] { 3, 1, 5, 4 },
                new int[] { 3, 1, 3, 1, 3 },
                new int[] { 2, 2, 2, 2, 2, 2 },
                new int[] { 5, 6, 4, 5, 6, 4, 3 }
            };

            Assert.AreEqual( Basic.GoldenTriangle( triangle ), 29 );
        }
    }
}