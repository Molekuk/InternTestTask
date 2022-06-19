using System;

namespace Task1
{
	class Program
	{
		static void Main(string[] args)
		{
			try
			{
				FailProcess1();
			}
			catch { }

			Console.WriteLine("Failed to fail process!");
			Console.ReadKey();
		}

		//Не совсем корректный способ - вызов критического исключения (При выделении памяти возникает StackOverflow exception)
		static void FailProcess1()
		{
			unsafe
			{
				Span<int> a = stackalloc int[10000000];
			}

			//или

			unsafe
			{
				var a = -12;
				Span<int> nums = stackalloc int[a];
			}

		}

		//Завершает текущий процесс и возвращает операционной системе код выхода
		static void FailProcess2()
		{
			System.Environment.Exit(0);
		}

		//Завершает текущий процесс после записи сообщения в журнал событий приложений Windows
		static void FailProcess3()
		{
			//Включает сообщение в отчет об ошибках
			System.Environment.FailFast("Exit");

			//или

			//Включает сообщение и сведение об исключении в отчет об ошибках
			System.Environment.FailFast("Exit",new Exception("Exit"));

		}

		//Принудительное завершение процесса
		static void FailProcess4()
		{
			//Получаем текущий процесс и убиваем его
			System.Diagnostics.Process.GetCurrentProcess().Kill();

			//Если мы знаем id процесса
			System.Diagnostics.Process.GetProcessById(1).Kill();

            //Если мы знаем имя процесса
            foreach (var process in System.Diagnostics.Process.GetProcessesByName("Some name"))
            {
				process.Kill();
            }
		}
	}

}
