using Algorithms.Core.Basics;
using Algorithms.Core.Tree;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text;

namespace Algorithms.Test
{
    [TestClass]
    public class Trees
    {
        /// <summary>
        /// Проверка обходов деревьев
        /// </summary>
        [TestMethod]
        public void TreeBinaryTraverse()
        {
            /*     D
                   /\
                  B  E
                 /\
                A  C      */

            var root = new TreeBinary<char>( 'D' );
            root.Left = new TreeBinary<char>( 'B' );
            root.Right = new TreeBinary<char>( 'E' );
            root.Left.Left = new TreeBinary<char>( 'A' );
            root.Left.Right = new TreeBinary<char>( 'C' );

            // TraversePreOrder
            var result = new StringBuilder();
            root.TraversePreOrder( ( node ) =>
            {
                result.Append( node.Value );
            } );

            Assert.AreEqual( result.ToString(), "DBACE" );

            // TraverseInOrder
            result = new StringBuilder();
            root.TraverseInOrder( ( node ) =>
            {
                result.Append( node.Value );
            } );

            Assert.AreEqual( result.ToString(), "ABCDE" );

            // TraversePostOrder
            result = new StringBuilder();
            root.TraversePostOrder( ( node ) =>
            {
                result.Append( node.Value );
            } );

            Assert.AreEqual( result.ToString(), "ACBED" );

            // TraverseDepth
            result = new StringBuilder();
            root.TraverseDepth( ( node ) =>
            {
                result.Append( node.Value );
            } );

            Assert.AreEqual( result.ToString(), "DBEAC" );
        }

        /// <summary>
        /// Проверка упорядоченных бинарных деревьев
        /// </summary>
        [TestMethod]
        public void TreeBinaryOrdered()
        {
            var root = new TreeBinary<char>( '\0' );

            root.OrderedAdd( 'A' );
            root.OrderedAdd( 'D' );
            root.OrderedAdd( 'C' );
            root.OrderedAdd( 'B' );
            root.OrderedAdd( 'E' );

            var result = new StringBuilder();
            root.TraverseInOrder( ( node ) =>
            {
                result.Append( node.Value );
            } );

            Assert.AreEqual( result.ToString(), "\0ABCDE" );

            Assert.AreEqual( root.OrderedFind( 'A' ).Value, 'A' );
            Assert.AreEqual( root.OrderedFind( 'C' ).Value, 'C' );
            Assert.AreEqual( root.OrderedFind( 'E' ).Value, 'E' );
            Assert.AreEqual( root.OrderedFind( 'Z' ), null );
            Assert.AreEqual( root.OrderedFind( '2' ), null );
        }
    }
}