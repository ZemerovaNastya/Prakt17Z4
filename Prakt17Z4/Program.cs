using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace Prakt17Z4
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader("file1.txt");
            List<Country> list = new List<Country>();
            Console.WriteLine("Введите численость населения: ");
            try
            {
                int N = Convert.ToInt32(Console.ReadLine());
                if (N <= 0) { Console.WriteLine("Кол-во населения не может быть ниже 0!"); }
                else
                {
                    try
                    {
                        while (!sr.EndOfStream)
                        {
                            string str = sr.ReadLine();
                            string[] st = str.Split(' ');
                            if (st.Length == 5)
                            {
                                list.Add(new Country() { country = st[0], num = Convert.ToInt32(st[1] + st[2] + st[3] + st[4]) });
                            }
                            else if (st.Length == 4)
                            {
                                list.Add(new Country() { country = st[0], num = Convert.ToInt32(st[1] + st[2] + st[3]) });
                            }
                            else if (st.Length == 3)
                            {
                                list.Add(new Country() { country = st[0], num = Convert.ToInt32(st[1] + st[2]) });
                            }
                            else { list.Add(new Country() { country = st[0], num = Convert.ToInt32(st[1]) }); }
                        }
                        Console.WriteLine("Исходный массив: ");
                        Console.WriteLine();
                        foreach (var item in list)
                        {
                            Console.WriteLine(item.country + " " + item.num);
                        }
                        Console.WriteLine();
                        Console.WriteLine("Упорядоченный список стран, у которых численность больше n: ");
                        Console.WriteLine();
                        foreach (var item in list.OrderBy(x => x.country.Length).Where(x => x.num > N).ToList())
                        {
                            Console.WriteLine(item.country + " " + item.num);
                        }
                        sr.Close();
                    }
                    catch { Console.WriteLine("Файл содержит неправильный тип данных!"); }
                }
            }
            catch { Console.WriteLine("Неправильный тип данных!"); }
        }
    }
}