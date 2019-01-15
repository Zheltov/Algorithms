using System;
using System.Collections.Generic;
using Algorithms.Core.Arrays.Extensions;

namespace Algorithms.Core.Arrays
{
    public static class Sort
    {
        /// <summary>
        /// Сортировка вставкой
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="items">Массив</param>
        public static void SortByInsert<T>( this T[] items ) where T : IComparable<T>
        {
            for ( int i = 0; i < items.Length; i++ )
                for ( int j = 0; j < i; j++ )
                    if ( items[j].CompareTo( items[i] ) > 0 )
                        items.MoveWithShift( i, j );
        }

        /// <summary>
        /// Сортировка выбором
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="items">Массив</param>
        public static void SortByChoose<T>( this T[] items ) where T : IComparable<T>
        {
            for ( int i = 0; i < items.Length; i++ )
            {
                var minIndex = i;
                for ( int j = i; j < items.Length; j++ )
                    if ( items[j].CompareTo( items[minIndex] ) < 0 )
                        minIndex = j;

                items.Swap( i, minIndex );
            }
        }

        /// <summary>
        /// Сортировка пузырьком
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="items">Массив</param>
        public static void SortBubble<T>( this T[] items ) where T : IComparable<T>
        {
            bool sorted = false;

            while ( !sorted )
            {
                sorted = true;
                for ( int i = 0; i < items.Length - 1; i++ )
                    if ( items[i].CompareTo( items[i + 1] ) > 0 )
                    {
                        items.Swap( i, i + 1 );
                        sorted = false;
                    }
            }
        }

        /// <summary>
        /// Сортировка пузырьком оптимизированная
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="items">Массив</param>
        public static void SortBubbleOptimized<T>( this T[] items ) where T : IComparable<T>
        {
            bool sorted = false;
            while ( !sorted )
            {
                sorted = true;
                for ( int i = 0; i < items.Length - 1; i++ )
                    if ( items[i].CompareTo( items[i + 1] ) > 0 )
                    {
                        // нашли элемент который не на своем месте
                        var indexFrom = i + 1;
                        var indexTo = i;

                        // мы могли бы просто поменять местами indexFrom и indexTo, но возможно, что
                        // ниже indexTo также более большие элементы чем indexFrom
                        while ( indexTo > 0 )
                        {
                            if ( items[indexTo - 1].CompareTo( items[indexFrom] ) < 0 )
                                break;
                            indexTo--;
                        }

                        // В отличии от обычного пузырька не меняем местами а перемещаем со сдвигом
                        items.MoveWithShift( indexFrom, indexTo );
                        sorted = false;
                        break;
                    }
            }
        }

        /// <summary>
        /// Пирамидальная сортировка
        /// </summary>
        /// <typeparam name="T">Тип</typeparam>
        /// <param name="items">Массив</param>
        public static void SortHeap<T>( this T[] items ) where T : IComparable<T>
        {
            // Делаем бинарную кучу из массива
            ArrayExtensions.BinaryHeapMake( items );

            // Идем по куче от конца, на каждом цикле извлекаем из кучи верхний элемент и перестраиваем ее
            // после чего в куче остается на 1 элемент меньше и верхних элемент размещаем в конце массива.
            // На следующем шаге будет опять извлечен верхний элемент и помещен в конец массива перед предыдущим
            for ( int i = items.Length - 1; i >= 0; i-- )
            {
                // i + 1 - так как надо передать длинну кучу
                var element = ArrayExtensions.BinaryHeapRemoveTopItem( items, i + 1 );
                items[i] = element;
            }
        }

        /// <summary>
        /// Быстрая сортировка. Род Стивенс стр. 151
        /// </summary>
        /// <typeparam name="T">Тип</typeparam>
        /// <param name="items">Массив</param>
        public static void SortQuickWithStack<T>( this T[] items ) where T : IComparable<T>
        {
            SortQuickWithStack( items, 0, items.Length - 1, new Stack<T>(), new Stack<T>() );
        }

        /// <summary>
        /// Быстрая сортировка. Моя версия, навеянная Род Стивенс стр. 153
        /// </summary>
        /// <typeparam name="T">Тип</typeparam>
        /// <param name="items">Массив</param>
        public static void SortQuickOnOneArray<T>( this T[] items ) where T : IComparable<T>
        {
            SortQuickOnOneArray( items, 0, items.Length - 1  );
        }

        static void SortQuickOnOneArray<T>( this T[] items, int minIndex, int maxIndex ) where T : IComparable<T>
        {
            // Сортировать надо всего один элемент, т.е. он отсортирован
            if ( maxIndex - minIndex <= 1 )
                return;

            // получаем индекс разделяющего элемента
            var dividerIndex = minIndex + ( maxIndex - minIndex ) / 2; //random.Next( minIndex, maxIndex );
            var divider = items[dividerIndex];

            // перемещаем делитель в начало
            items.Swap( minIndex, dividerIndex );
            dividerIndex = minIndex;

            // ищем элементы которые меньше делителя
            for( int i = minIndex; i <= maxIndex; i++ )
            {
                if ( items[i].CompareTo(divider)<0)
                {
                    // элемент меньше делителя, перемещаем на его место со смещение делителя
                    items.MoveWithShift( i, dividerIndex );
                    dividerIndex++; // позиция делителя стала на 1 больше
                }
            }

            SortQuickOnOneArray( items, minIndex, dividerIndex - 1 );
            SortQuickOnOneArray( items, dividerIndex,  maxIndex );

        }

        /// <summary>
        /// Быстрая сортировка на стэках
        /// </summary>
        /// <typeparam name="T">Тип</typeparam>
        /// <param name="items">Массив</param>
        /// <param name="minIndex">Нижняя сортируемая граница</param>
        /// <param name="maxIndex">Верхняя сортируемая граница</param>
        /// <param name="stack1">Временный стэк</param>
        /// <param name="stack2">Временный стэк</param>
        static void SortQuickWithStack<T>( this T[] items, int minIndex, int maxIndex, Stack<T> stack1, Stack<T> stack2 ) where T : IComparable<T>
        {
            // Сортировать надо всего один элемент, т.е. он отсортирован
            if ( maxIndex - minIndex <= 1 )
                return;

            stack1.Clear();
            stack2.Clear();

            // получаем индекс разделяющего элемента
            var dividerIndex = minIndex + ( maxIndex - minIndex ) / 2; //random.Next( minIndex, maxIndex );
            var divider = items[dividerIndex];
            // Распихиваем по стекам, то что меньше делителя на лево от него, то что больше или равно на право
            for ( int i = minIndex; i <= maxIndex; i++ )
            {
                if ( i == dividerIndex )
                    continue;

                if ( items[i].CompareTo( divider ) < 0 )
                    stack1.Push( items[i] );
                else
                    stack2.Push( items[i] );
            }

            var index = minIndex;

            while ( stack1.Count > 0 )
            {
                items[index] = stack1.Pop();
                index++;
            }
            var newDividerIndex = index;
            items[newDividerIndex] = divider;
            index++;
            while ( stack2.Count > 0 )
            {
                items[index] = stack2.Pop();
                index++;
            }

            SortQuickWithStack( items, minIndex, newDividerIndex - 1, stack1, stack2 );
            SortQuickWithStack( items, newDividerIndex, maxIndex, stack1, stack2 );
        }
    }
}