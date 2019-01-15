using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Core.Basics
{
    /// <summary>
    /// Базовые алгоритмы
    /// </summary>
    public static class Basic
    {
        /// <summary>
        /// Золотой треугольник. Спуск по треугольнику по самой максимальной цепочке по сумме
        /// </summary>
        /// <param name="items">Треугольный массив</param>
        /// <returns>Сумма</returns>
        public static int GoldenTriangle( int[][] items )
        {
            var result = new int[items.Length];

            // копируем основние пирамиды
            for ( int i = 0; i < items[items.Length - 1].Length; i++ )
                result[i] = items[items.Length - 1][i];

            // идем по пирамиде снизу-вверх и суммируем
            for ( int i = items.Length - 2; i >= 0; i-- )
            {
                var row = items[i];
                for ( int j = 0; j < row.Length; j++ )
                    result[j] = row[j] + Math.Max( result[j], result[j + 1] );
            }

            return result[0];
        }
    }
}
