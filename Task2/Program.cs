using System;
using System.Globalization;

namespace Task2
{
	class Program
	{
		static readonly IFormatProvider _ifp = CultureInfo.InvariantCulture;

		class Number
		{
			readonly int _number;

			public Number(int number)
			{
				_number = number;
			}

			public override string ToString()
			{
				return _number.ToString(_ifp);
			}
			//Чтобы на экран выводился результат сложения любых значений someValue1 и someValue2 мы должны перегрузить оператор +
			//Чтобы метод корректно складывал большие значения, например int.MaxValue + int.MaxValue мы преобразуем строку value к long
			public static string operator +(Number num, string value) => (num._number + long.Parse(value)).ToString();
		}

		static void Main(string[] args)
		{
			int someValue1 = 10;
			int someValue2 = 5;
			//Без перегрузки метода на экран выводится сумма строк - 105
			string result = new Number(someValue1) + someValue2.ToString(_ifp);
			Console.WriteLine(result);
			Console.ReadKey();
		}
	}

}
