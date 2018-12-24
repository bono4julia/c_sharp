using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace uklon1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите индекс числа:");
            string inputIndex = Console.ReadLine();
            int index;
            bool isNumber = int.TryParse(inputIndex, out index);

            if (isNumber)
            {
                int[] numbers = new int[index + 1];

                numbers[0] = 1;

                if (index > 0)
                    numbers[1] = 1;

                if (index > 1)
                    numbers[2] = 2;

                if (index > 2)
                    for (var i = 3; i <= index; i++)
                        numbers[i] = numbers[i - 1] + numbers[i - 2] + numbers[i - 3];

                Console.WriteLine("Число по индексу:");
                Console.WriteLine(numbers[index]);

            } else {
                Console.WriteLine("Индекс числа задан неверно");
            }

             Console.ReadKey();
        }
    }
}
