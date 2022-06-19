using System;

namespace Task5
{
	class Program
	{
		static void Main(string[] args)
		{
			TransformToElephant();
			Console.WriteLine("Муха");
			//... custom application code
		}

		//Если же мы хотим сохранить возможность вывода информации в консоль то можем сохранить консольный выходной поток в переменную
		//И далее через метод SetOut присвоить этот поток свойству Out
		//
		//static void Main(string[] args)
		//{
		//	var textwriter = Console.Out;
		//
		//	TransformToElephant();
		//	Console.WriteLine("Муха");
		//
		//	Console.SetOut(textwriter);
		//	Console.WriteLine("Слоник");
		//}


		static void TransformToElephant()
		{
			Console.WriteLine("Слон");
			//Присваиваем консольному выходому потоку объект StringWriter, который наследуется от TextWriter
			//Таким образом при использовании метода Console.WriteLine вывода в консоль происходить не будет
			Console.SetOut(new System.IO.StringWriter());
		}
	}

}
