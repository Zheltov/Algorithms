using System;

namespace Algorithms.Core.Arrays.Extensions
{
    public static class ArrayExtensions
    {
        /// <summary>
        /// Перемещение элемента в массиве с позиции from в позицию to со сдвигом массива
        /// </summary>
        /// <typeparam name="T">Тип</typeparam>
        /// <param name="items">Массив</param>
        /// <param name="from">Переместить с позиции</param>
        /// <param name="to">Переместить в позицию</param>
        public static void MoveWithShift<T>( this T[] items, int from, int to )
        {
            if ( from == to )
                return;

            // Сохраняем перемещаемое значение
            var value = items[from];

            // Сдвигаем массив влево или вправо
            if ( from < to )
                for ( int i = from; i < to; i++ )
                    items[i] = items[i + 1];
            else
                for ( int i = from; i > to; i-- )
                    items[i] = items[i - 1];

            // Записываем значение в позицию
            items[to] = value;
        }

        /// <summary>
        /// Поменять два элемента местами
        /// </summary>
        /// <typeparam name="T">Тип</typeparam>
        /// <param name="items">Массив</param>
        /// <param name="i">Позциция</param>
        /// <param name="j">Позциция</param>
        public static void Swap<T>( this T[] items, int i, int j )
        {
            var item = items[i];
            items[i] = items[j];
            items[j] = item;
        }

        /// <summary>
        /// Создать из массива кучу. Род Стивенс стр. 145
        /// </summary>
        /// <param name="items">Массив</param>
        public static void BinaryHeapMake<T>( this T[] items ) where T : IComparable<T>
        {
            // Идем по всем элементам массива
            for ( int i = 0; i < items.Length; i++ )
            {
                int index = i;
                while ( index != 0 )
                {
                    // Находим родителя
                    int parentIndex = ( index - 1 ) / 2;

                    // если рассматриваемое значение меньше или равна родителю, то она на своем месте
                    if ( items[index].CompareTo( items[parentIndex] ) <= 0 )
                        break;

                    // Записи надо поменять местами
                    items.Swap( index, parentIndex );

                    // Теперь рассматриваем родителя, возможно его тоже нужно двигать
                    index = parentIndex;
                }
            }
        }
        

        /// <summary>
        /// Удалить верхний элемент из кучи и перестроить ее
        /// </summary>
        /// <typeparam name="T">Тип</typeparam>
        /// <param name="items">Массив содержащий кучу</param>
        /// <returns>Верхний элемент</returns>
        public static T BinaryHeapRemoveTopItem<T>( this T[] items ) where T : IComparable<T>
        {
            return BinaryHeapRemoveTopItem( items, items.Length );
        }

        /// <summary>
        /// Удалить верхний элемент из кучи и перестроить ее
        /// </summary>
        /// <typeparam name="T">Тип</typeparam>
        /// <param name="items">Массив содержащий кучу</param>
        /// <param name="length">Число элементов кучи (массив может быть длинне)</param>
        /// <returns>Верхний элемент</returns>
        public static T BinaryHeapRemoveTopItem<T>( this T[] items, int length ) where T : IComparable<T>
        {
            // верхний элемент, есть результат
            var result = items[0];

            // ставим последний элемент в корень, после чего будем проваливать его вниз по бинарной куче
            items[0] = items[length - 1];
            //items[length - 1] = default( T );

            // начинаем проваливать вниз верхний элемент
            var index = 0;
            while ( true )
            {
                // Индексы детей
                var child1Index = 2 * index + 1;
                var child2Index = child1Index + 1;

                // Если выходим за границы length, то используем индекс родителя
                child1Index = child1Index >= length ? index : child1Index;
                child2Index = child2Index >= length ? index : child2Index;

                // Проверяем выполняется ли условие для кучи - родитель больше обоих детей
                if ( items[index].CompareTo( items[child1Index] ) >= 0 && items[index].CompareTo( items[child2Index] ) >= 0 )
                    break; // куча восстановлена

                // Индекс большей дочерней записи
                var swapIndex = items[child1Index].CompareTo( items[child2Index] ) > 0 ? child1Index : child2Index;

                items.Swap( index, swapIndex );

                index = swapIndex;
            }

            return result;
        }
    }
}
