using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Algorithms.Test
{
    [TestClass]
    public class DataSctructures
    {

        /// <summary>
        /// Связанный список. Первый элемент содержит данные
        /// </summary>
        [TestMethod]
        public void LinkedList()
        {
            var list = new Core.DataStructures.LinkedList<int>() { Value = 7 };
            Core.DataStructures.LinkedList<int>.Add( list, 2 );
            var itemToRemove = Core.DataStructures.LinkedList<int>.Add( list, 5 );
            Core.DataStructures.LinkedList<int>.Add( list, 1 );
            Core.DataStructures.LinkedList<int>.Add( list, 3 );
            Core.DataStructures.LinkedList<int>.Remove( list, itemToRemove );

            var result = new List<int>();
            var item = list;
            while ( item != null )
            {
                result.Add( item.Value );
                item = item.Next;
            }

            CollectionAssert.AreEqual( result, new List<int>() { 7, 2, 1, 3 } );
        }

        /// <summary>
        /// Связанный список с заглушкой. Первый элемент не содерижат данных
        /// </summary>
        [TestMethod]
        public void LinkedListStub()
        {
            var list = new Core.DataStructures.LinkedList<int>();
            Core.DataStructures.LinkedList<int>.Add( list, 7 );
            Core.DataStructures.LinkedList<int>.Add( list, 2 );
            var itemToRemove = Core.DataStructures.LinkedList<int>.Add( list, 5 );
            Core.DataStructures.LinkedList<int>.Add( list, 1 );
            Core.DataStructures.LinkedList<int>.Add( list, 3 );

            Core.DataStructures.LinkedList<int>.Remove( list, itemToRemove );

            var result = new List<int>();
            var item = list;
            while ( item.Next != null )
            {
                item = item.Next;
                result.Add( item.Value );
            }

            CollectionAssert.AreEqual( result, new List<int>() { 7, 2, 1, 3 } );
        }
    }
}
