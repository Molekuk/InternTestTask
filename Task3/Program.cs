using System;
using System.Collections.Generic;
using System.Linq;

namespace Task3
{
	static class Program
	{
		
		public static IEnumerable<(T item, int? tail)> EnumerateFromTail<T>(this IEnumerable<T> enumerable, int? tailLength)
		{
			if (enumerable == null)
				throw new ArgumentNullException(nameof(enumerable));

			List<(T item, int? tail)> result = new List<(T item, int? tail)>();

			//индекс элемента
			var index = 0;
			var count = enumerable.Count();
			//Позиция элемента относительно конца (Если мы передали tailLenght больше количества элементов, будем считать все элементы в списке)
			var position = tailLength > count ? count - 1 : tailLength - 1;

			//Перебираем список, подсчет элементов начинается с count-tailLenght
			//Если элемент меньше чем count-tailLenght то в позицию элемента вписываем null
			//Таким образом мы можем реализовать такой метод за один перебор значений
			foreach (var item in enumerable)
			{
				if (index >= count - tailLength)
				{
					result.Add((item, position));
					position--;
				}
				else
					result.Add((item, null));
				index++;
			}
			return result;
		}



		static void Main(string[] args)
		{
			List<int> intList = new List<int>() { 1, 2, 3, 4, 5, 6 };
			try
			{
				//При передачи следующих значений подсчет элементов происходить не будет, и в tail будет null
				var a = intList.EnumerateFromTail(null);
				var b = intList.EnumerateFromTail(0);
				var c = intList.EnumerateFromTail(-10);

				//Корректный подсчет элементов
				var d = intList.EnumerateFromTail(10);
				var e = intList.EnumerateFromTail(3);

				Console.WriteLine("Список d");
				foreach (var elem in d)
                {
                    Console.Write(elem+" ");
                }

                Console.WriteLine("\nСписок e");
				foreach (var elem in e)
				{
					Console.Write(elem + " ");
				}

				//Если список принимает значение null то возникает исключение
				intList = null;
				var f = intList.EnumerateFromTail(4);

			}
			catch (Exception ex)
			{
				Console.WriteLine("\n"+ex.Message);
			}
		}
	}

}
