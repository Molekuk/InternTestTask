using System;
using System.Collections.Generic;
using System.Linq;

namespace Task4
{
    class Program
    {
        //Метод корректно работает при условии если входящий поток соответствует условию:
        //"Если в потоке встретилось число x, то в нём больше не встретятся числа меньше, чем (x - sortFactor)"
        static IEnumerable<int> Sort(IEnumerable<int> inputStream, int sortFactor, int maxValue)
        {
            if (inputStream == null)
                throw new ArgumentNullException(nameof(inputStream));
            if (sortFactor <= 0)
                throw new ArgumentOutOfRangeException(nameof(sortFactor));

            //Нижняя граница элементов
            int limit = 0;
            //Первый элемент в буфере
            int first = 0;
            List<int> result = new List<int>();
            List<int> buffer = new List<int>();

            //Перебираем поток элементов
            foreach (var elem in inputStream)
            {
                //Определяем максимальную нижнюю границу
                limit = limit > elem - sortFactor ? limit : elem - sortFactor;
                buffer.Add(elem);
                first = buffer[0];
                
                //Так как буфер отсортирован по возрастанию, мы проверяем элементы начиная с первого
                //Если первый элемент меньше или равен нижней границе, значит дальше в списке элемента меньше чем первый не будет, поэтому мы добавляем его в результирующий список
                while (buffer.Count > 0 && first <= limit)
                {
                    result.Add(first);
                    buffer.RemoveAt(0);
                    first = buffer[0];
                }

                //Сортируем буфер по возрастанию
                //Находим нужную позицию последнего добавленного элемента попарно сравнивая этот элемент с предыдущим
                if (buffer.Count > 1)
                {
                    for (int i = buffer.Count - 1; i >= 1; i--)
                    {
                        if (buffer[i] < buffer[i - 1])
                            (buffer[i], buffer[i - 1]) = (buffer[i - 1], buffer[i]);
                        else break;
                    }
                }

            }
            //Добавляем оставшийся буфер в результирующий список
            //После встречи первого максимального элемента он и все последующие элементы не могут быть меньше нижней границы
            //Отсюда и возникают оставшиеся в буфере элементы
            result.AddRange(buffer);

            return result;
        }

        static void Main(string[] args)
        {
            int softFactor = 5;
            List<int> list = new List<int> { 30, 32, 29, 30, 29, 25, 34, 33, 34, 35, 40, 36, 35, 38, 36, 40, 50, 46, 47, 48, 50, 50, 60,58,57,56,60,60};

            System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
            sw.Start();
            var sortedList = Sort(list, softFactor, list.Max());
            sw.Stop();

            Console.Write("sortedList: ");
            foreach (var elem in sortedList)
            {
                Console.Write($"{elem} ");
            }


            //Как мы можем увидеть сортировка при помощи метода Sort примерно в 10 раз эффективнее сортировки при помощи Linq
            //Емкостная сложность O(n)
            //Временная сложность O(n)
            Console.WriteLine("\nSort time in milliseconds: " + sw.Elapsed.TotalMilliseconds);
            sw.Restart();
            var sortedList2 = list.OrderBy(x => x).ToList();
            sw.Stop();
            Console.WriteLine("Linq time in milliseconds: " + sw.Elapsed.TotalMilliseconds);

            Console.Read();
        }
    }

}
