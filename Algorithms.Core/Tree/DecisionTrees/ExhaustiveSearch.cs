using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Core.Tree.DecisionTrees
{
    /// <summary>
    /// Исчерпывающий поиск
    /// </summary>
    public static class ExhaustiveSearchExtension
    {
        public static Tuple<int[], int[]> DivideHalfByWeight( this int[] items )
        {
            int[] r1 = null;
            int[] r2 = null;
            var list1temp = new List<int>();
            var list2temp = new List<int>();

            DivideHalfByWeight( items, 0, ref r1, ref r2, list1temp, list2temp );

            return new Tuple<int[], int[]>( r1, r2 );
        }

        static void DivideHalfByWeight( int[] items, int index, ref int[] r1, ref int[] r2, IList<int> list1temp, IList<int> list2temp )
        {
            if ( index == items.Length - 1 )
            {
                if ( r1 == null || Math.Abs( list1temp.Sum() - list2temp.Sum() ) < Math.Abs( r1.Sum() - r2.Sum() ) )
                {
                    r1 = list1temp.ToArray();
                    r2 = list2temp.ToArray();
                }
            }
            else
            {
                // Относим очередной элемент к группе 0
                list1temp.Add( items[index] );
                DivideHalfByWeight( items, index + 1, ref r1, ref r2, list1temp, list2temp );
                list1temp.Remove( list1temp.Last() );

                // Относим очередной элемент к группе 1
                list2temp.Add( items[index] );
                DivideHalfByWeight( items, index + 1, ref r1, ref r2, list1temp, list2temp );
                list2temp.Remove( list2temp.Last() );
            }
        }
    }
}