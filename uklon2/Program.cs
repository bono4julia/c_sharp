using Newtonsoft.Json;
using System;
using System.IO;
using System.Linq;

class ArrStrings{
    public int[] arr1, arr2;
}

namespace uklon2
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"D:\sharp\uklon\uklon2\file.json";
            string[] arrStr;
            int[] arrOdd;
            ArrStrings arrs;

            if (!File.Exists(path))
            {
                Console.WriteLine("Файл не найден");
                Console.ReadKey();
                return;
            }

            // deserialize JSON directly from a file
            using (StreamReader file = File.OpenText(path))
            {
                JsonSerializer serializer = new JsonSerializer();
                arrs = (ArrStrings)serializer.Deserialize(file, typeof(ArrStrings));
            }

            Console.WriteLine("Исходный массив-1: " + string.Join(" ", arrs.arr1));
            Console.WriteLine("Исходный массив-2: " + string.Join(" ", arrs.arr2));

            //-уникальные числа(среди всего набора чисел встречающихся в обоих массивах)

            var z = new int[arrs.arr1.Length + arrs.arr2.Length];
            arrs.arr1.CopyTo(z, 0);
            arrs.arr2.CopyTo(z, arrs.arr1.Length);

            var result1 = z
                         .Select(str => new { Name = str, Count = z.Count(s => s == str) })
                         .Where(obj => obj.Count == 1)
                         .Distinct()
                         .Select(str => str.Name);

            Console.WriteLine("1. Уникальные числа(среди всего набора чисел встречающихся в обоих массивах): " + string.Join(" ", result1));

            var result2 = arrs.arr1
                         .Select(str => new { Name = str, Count = arrs.arr1.Count(s => s == str) })
                         .Where((obj) => obj.Count == 1 && obj.Name % 2 != 0)
                         .Distinct()
                         .Select(str => new { Name = str.Name, Count = arrs.arr2.Count(s => s == str.Name), isContained = arrs.arr2.Contains(str.Name) });

            Console.WriteLine("2. Уникальные нечетные числа из первого массива и информация сколько раз такое число встречается во втором массиве: \n" + string.Join("\n", result2));


            var result3 = arrs.arr1
                           .Select(str => new { Name = str, Count = arrs.arr1.Count(s => s == str) })
                           .Where((obj) => obj.Name % 2 == 0)
                           .Distinct()
                           .Select(str => new { Name = str.Name, Count = arrs.arr2.Count(s => s == str.Name), isContained = arrs.arr2.Contains(str.Name) })
                           .Where((obj) => !obj.isContained)
                           .Select(str => str.Name)
                           .Sum();

            Console.WriteLine("3. Cумма четных чисел первого массива, которые не представлены во втором массиве: " + string.Join(" ", result3));

            Console.ReadKey();
        }
    }
}