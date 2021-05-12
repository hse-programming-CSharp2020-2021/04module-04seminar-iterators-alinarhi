using System;
using System.Collections;
using System.Text;

/* На вход подается число N.
 * Нужно создать коллекцию из N элементов последовательного ряда натуральных чисел, возведенных в 10 степень, 
 * и вывести ее на экран ТРИЖДЫ. Инвертировать порядок элементов при каждом последующем выводе.
 * Элементы коллекции разделять пробелом. 
 * Очередной вывод коллекции разделять переходом на новую строку.
 * Не хранить всю коллекцию в памяти.
 * 
 * Код, данный в условии, НЕЛЬЗЯ стирать, его можно только дополнять.
 * Не использовать yield и foreach. Не вызывать метод Reset() в классе Program.
 * 
 * Пример входных данных:
 * 2
 * 
 * Пример выходных данных:
 * 1 1024
 * 1024 1
 * 1 1024
 * 
 * В случае ввода некорректных данных выбрасывайте ArgumentException.
 * В других ситуациях выбрасывайте 
*/
namespace Task05
{
    class Program
    {
        static int counter = 0;
        static void Main(string[] args)
        {
            try
            {
                if (int.TryParse(Console.ReadLine(), out int value) && value > 0)
                {
                    MyDigits myDigits = new MyDigits();
                    IEnumerator enumerator = myDigits.MyEnumerator(value);

                    IterateThroughEnumeratorWithoutUsingForeach(enumerator);
                    Console.WriteLine();
                    IterateThroughEnumeratorWithoutUsingForeach(enumerator);
                    Console.WriteLine();
                    IterateThroughEnumeratorWithoutUsingForeach(enumerator);
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
            catch (ArithmeticException)
            {
                Console.WriteLine("ooops");
            }

            Console.ReadLine();
        }

        static void IterateThroughEnumeratorWithoutUsingForeach(IEnumerator enumerator)
        {
            counter++;

            StringBuilder str = new StringBuilder();
            while (enumerator.MoveNext())
            {
                str.Append(enumerator.Current + " ");
            }
            string output = str.ToString();

            if (counter % 2 == 0)
            {
                var numbers = output.Split();
                Array.Reverse(numbers);
                output = String.Join(" ", numbers);
            }

            output = output.Trim();
            Console.Write(output);
            enumerator.Reset();
        }
    }

    class MyDigits : IEnumerator // НЕ МЕНЯТЬ ЭТУ СТРОКУ
    {
        int position = 0;
        int end;
        public IEnumerator MyEnumerator(int value)
        {
            end = value;
            return this;
        }

        public bool MoveNext()
        {
            return position++ != end;
        }

        public void Reset()
        {
            position = 0;
        }

        public object Current
        {
            get
            {
                return Math.Pow(position, 10);
            }
        }

        object IEnumerator.Current => Current;
    }

}

