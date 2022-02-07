using System;
using Serilog;
namespace SimbirSoftTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
              .MinimumLevel.Debug()
              .WriteTo.Console()
              .WriteTo.File("logs/myapp.txt", rollingInterval: RollingInterval.Day)
              .CreateLogger();
            for (; ; )
            {
                Console.WriteLine("Для парсинка сайта нажмите Start. Для выхода из программы любую другую кнопку");
                string command = Console.ReadLine();
                try
                {
                    if (command == "Start")
                    {
                        Pars pars = new Pars();
                        pars.Parse();
                    }
                    else
                    { 
                      Console.ReadKey(); 
                      break; 
                    }
                }
                catch(Exception e) 
                {
                    Console.WriteLine($"Программа завершилась с ошибкой: {e}"); 
                }
            }        
        }
    }
}
