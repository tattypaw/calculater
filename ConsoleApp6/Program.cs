//Потеряева Т.А. 
//Написать программу-калькулятор по вычислению сложения, вычитания, умножения, деления, возведения в степень, вычисление знака числа, получение модуля, округление в большую и меньшую сторону. В функциях предусмотреть логирование и исключения.
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;

namespace ConsoleApp6
{
    class Program
    {
        static void Main(string[] args)
        {
            float a, b=0, selection;
            Console.WriteLine("Введите число"); 
            a=float.Parse(Console.ReadLine());
           
            Console.WriteLine("Выберите математическую операцию");
            Console.WriteLine("1. Сложение" );
            Console.WriteLine("2. Вычитание");
            Console.WriteLine("3. Умножение");
            Console.WriteLine("4. Деление");
            Console.WriteLine("5. Возведение в степень");
            Console.WriteLine("6. Вычисление знака числа");
            Console.WriteLine("7. Получение модуля");
            Console.WriteLine("8. Округление в большую сторону");
            Console.WriteLine("9. Округление в меньшую сторону");
            selection=int.Parse(Console.ReadLine());
            if (selection < 6)
            {
                Console.WriteLine("Введите второе число" );
                b=float.Parse(Console.ReadLine());
            }
            switch (selection)
            {
                case 1:
                    Console.WriteLine("Результат сложения {0}", a + b);
                    break;
                case 2:
                    Console.WriteLine("Результат вычитания {0}", a - b);
                    break;
                case 3:
                    Console.WriteLine("Результат уменожения {0}", a * b);
                    break;
                case 4:

                    try
                    {
                        a = a / b;
                        Console.WriteLine("Результат деления {0}", a);
                    }
                    catch (DivideByZeroException e)
                    {
                        Console.WriteLine("Ошибка! Делить на ноль нельзя!");
                        using (var file = new StreamWriter("test.txt", true))
                        {
                            file.WriteLine($"Исключение: {e.Message}");
                            file.WriteLine($"Метод: {e.TargetSite}");
                            file.WriteLine($"Трассировка стека: {e.StackTrace}");
                        }
                    }

                    break;
                    
                case 5:
                    Console.WriteLine("{0}-я степень {1} равна {2}", b, a, Math.Pow(a, b));
                    break;
                case 6:
                    if (a<0){Console.WriteLine("Число отрицательное");}
                    else{Console.WriteLine("Число положительное" );}
                    break;
                case 7:
                    if (a<0){Console.WriteLine("Модуль {0} равен {1}",a,-a);}
                    else{Console.WriteLine("Модуль {0} равен {1}",a,a);}
                    break;
                case 8:
                    Console.WriteLine("Результат округления равен {0}",Math.Ceiling(a));
                    break;
                case 9:
                    Console.WriteLine("Результат округления равен {0}",Math.Floor(a));
                    break;
                default:
                    Console.WriteLine("Ошибка! Пункт меню отсутствует!");
                    break;
            }
            Console.Read();
        }
    }
}