using System;
using System.Collections;

/* На вход подается число N.
 * Нужно создать коллекцию из N квадратов последовательного ряда натуральных чисел 
 * и вывести ее на экран дважды. Элементы коллекции разделять пробелом. 
 * Выводы всей коллекции разделять переходом на новую строку.
 * Не хранить всю коллекцию в памяти.
 * 
 * Код, данный в условии, НЕЛЬЗЯ стирать, его можно только дополнять.
 * Не использовать yield и foreach. Не вызывать метод Reset() в классе Program.
 * 
 * Пример входных данных:
 * 3
 * 
 * Пример выходных данных:
 * 1 4 9
 * 1 4 9
 * 
 * В случае ввода некорректных данных выбрасывайте ArgumentException.
*/
namespace Task04
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                if (int.TryParse(Console.ReadLine(), out int value) && value > 0)
                {
                    MyInts myInts = new MyInts();
                    IEnumerator enumerator = myInts.MyEnumerator(value);

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
            Console.ReadLine();
        }

        static void IterateThroughEnumeratorWithoutUsingForeach(IEnumerator enumerator)
        {           
            while (enumerator.MoveNext())
            {
                Console.Write(enumerator.Current + " ");
            }
            enumerator.Reset();
        }
    }

    class MyInts : IEnumerator // НЕ МЕНЯТЬ ЭТУ СТРОКУ
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
                return position * position;
            }
        }

        object IEnumerator.Current => Current;
    }
}
