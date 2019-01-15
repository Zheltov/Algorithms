using System;

namespace Algorithms.Core.DataStructures
{
    public class QueueOnArray<T>
    {
        const int DefaultCapacity = 16;

        private T[] items;
        private int indexUp = 0;
        private int indexDown = 0;

        public int Capacity { get; set; }

        public QueueOnArray()
            : this( DefaultCapacity )
        { }

        public QueueOnArray( int capacity )
        {
            Capacity = capacity;
            items = new T[Capacity];
        }

        public T Dequeue()
        {
            if ( indexDown == indexUp )
                throw new InvalidOperationException();

            var result = items[indexDown];
            items[indexDown] = default( T );
            indexDown++;

            return result;
        }

        public void Enqueue( T item )
        {
            // Если некуда добавлять, то меняем размер массива
            if ( indexUp >= items.Length )
            {

                if ( indexDown > 0 )
                {
                    // Если нижний индекс не ноль, то сдвигаем массив
                    for ( int i = indexDown; i < indexUp; i++ )
                        items[i - indexDown] = items[i];

                    indexUp -= indexDown;
                    indexDown = 0;
                }
                else
                {
                    // достигнут предел массива, создаем новый и копируем элементы
                    var itemsNew = new T[indexUp + Capacity];
                    for ( int i = 0; i < indexUp; i++ )
                        itemsNew[i] = items[i];

                    items = itemsNew;
                }
            }

            items[indexUp] = item;
            indexUp++;
        }


    }
}
