using Algorithms.Core.Lots;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace Algorithms.Test
{
    [TestClass]
    public class Lots
    {
        [TestMethod]
        public void LotsOfLotGetAll()
        {
            var items = new int[] { 1, 2, 3, 4 };

            var result = items.LotsOfLotGetAll().OrderBy( x => x.Length ).ToList();

            Assert.AreEqual( result.Count, 15 );
        }
    }
}
