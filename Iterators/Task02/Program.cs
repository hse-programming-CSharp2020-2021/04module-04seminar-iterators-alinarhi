using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
В основной программе объявите и инициализируйте одномерный строковый массив 
и выполните циклический перебор его элементов с разных «начальных точек», 
разделяя элементы одним пробелом.

Тестирование приложения выполняется путем запуска разных наборов тестов.
На вход в первой строке поступает число - номер элемента, начиная с которого 
пойдет циклический перебор.
В следующей строке указаны элементы последовательности, разделенные одним или 
несколькими пробелами.
3
1 2 3 4 5
Программа должна вывести на экран:
3 4 5 1 2

В случае ввода некорректных данных выбрасывайте ArgumentException.

Никаких дополнительных символов выводиться не должно.

Код метода Main можно подвергнуть изменениям, но вывод меняться не должен.

 */
namespace Task02
{
    class IteratorSample : IEnumerable<string> // НЕ МЕНЯТЬ
    {
        string[] values;
        int start;

        public IteratorSample(string[] values, int start)
        {
            if (start < 0 || values == null || start > values.Length - 1)
            {
                throw new ArgumentException();
            }
            this.values = values;
            this.start = start;
        }

        public IEnumerator<string> GetEnumerator()
        {
            for (int i = start; i < values.Length; i++)
            {
                yield return values[i];
            }
            for (int i = 0; i < start; i++)
            {
                yield return values[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                if (int.TryParse(Console.ReadLine(), out int startingIndex))
                {
                    startingIndex--;
                    string[] values = Console.ReadLine().Split();
                    Array.ForEach(values, str => str.Trim());

                    var spacesDeleted = new List<string>();
                    foreach (var value in values)
                    {
                        if (!string.IsNullOrEmpty(value))
                        {
                            spacesDeleted.Add(value);
                        }
                    }

                    foreach (string ob in new IteratorSample(spacesDeleted.ToArray(), startingIndex))
                        Console.Write(ob + " ");
                    Console.WriteLine();
                }
                else
                {
                    throw new ArgumentException();
                }
            }
            catch (ArgumentException)
            {
                Console.WriteLine("error");
            }
            catch (Exception)
            {
                Console.WriteLine("problem");
            }
        }
    }
}
