using System;
using System.Collections;
using System.Text;

/* На вход подается число N.
 * На каждой из следующих N строках записаны ФИО человека, 
 * разделенные одним пробелом. Отчество может отсутствовать.
 * Используя собственноручно написанный итератор, выведите имена людей,
 * отсортированные в лексико-графическом порядке в формате 
 *      <Фамилия_с_большой_буквы> <Заглавная_первая_буква_имени>.
 * Затем выведите имена людей в исходном порядке.
 * 
 * Код, данный в условии, НЕЛЬЗЯ стирать, его можно только дополнять.
 * Не использовать yield.
 * 
 * Пример входных данных:
 * 3
 * Banana Bill Bananovich
 * Apple Alex Applovich
 * Carrot Clark Carrotovich
 * 
 * Пример выходных данных:
 * Apple A.
 * Banana B.
 * Carrot C.
 * 
 * Banana B.
 * Apple A.
 * Carrot C.
 * 
 * В случае ввода некорректных данных выбрасывайте ArgumentException.
*/
namespace Task03
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.UTF8;
            Console.OutputEncoding = Encoding.UTF8;
            try
            {
                if (int.TryParse(Console.ReadLine(), out int N) && N > 0)
                {                  
                    Person[] people = new Person[N];
                    for (int i = 0; i < N; i++)
                    {
                        var input = Console.ReadLine().Split();
                        if (input.Length < 2 || string.IsNullOrWhiteSpace(input[0]) || string.IsNullOrWhiteSpace(input[1]))
                        {
                            throw new ArgumentException();
                        }
                        people[i] = new Person(input[1], input[0]);
                    }

                    People peopleList = new People(people);

                    foreach (Person p in peopleList)
                        Console.WriteLine(p);
                    Console.WriteLine();
                    foreach (Person p in peopleList.GetPeople)
                        Console.WriteLine(p);
                }
                else
                {
                    throw new ArgumentException();
                }
            }
            catch (ArgumentException)
            {
                Console.Write("error");
            }



            Console.ReadLine();
        }
    }

    public class Person : IComparable<Person>
    {
        public string firstName;
        public string lastName;

        public Person(string firstName, string lastName)
        {
            var firstLetter = firstName[0].ToString();
            this.firstName = firstName.Replace(firstLetter, firstLetter.ToUpper());
            firstLetter = lastName[0].ToString();
            this.lastName = lastName.Replace(firstLetter, firstLetter.ToUpper());
        }

        public int CompareTo(Person other)
        {
            int comp = lastName.ToLower().CompareTo(other.lastName.ToLower());
            if (comp == 0)
            {
                return firstName.ToLower().CompareTo(other.firstName.ToLower());
            }
            return comp;
        }
        public override string ToString()
        {
            return $"{lastName} {firstName[0]}.";
        }
    }

    public class People : IEnumerable
    {
        private Person[] _people;

        public People(Person[] people)
        {
            _people = people;
        }
        public Person[] GetPeople
        {
            get
            {
                return _people;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public PeopleEnum GetEnumerator()
        {
            return new PeopleEnum(_people);
        }
    }

    public class PeopleEnum : IEnumerator
    {
        int position = -1;
        public Person[] _people;

        public PeopleEnum(Person[] people)
        {
            _people = new Person[people.Length];
            Array.Copy(people, _people, people.Length);
            Array.Sort(_people);
        }

        public bool MoveNext()
        {
            return position++ != _people.Length - 1;
        }

        public void Reset()
        {
            position = -1;
        }


        public Person Current
        {
            get
            {
                return _people[position];
            }
        }

        object IEnumerator.Current => Current;
    }
}
