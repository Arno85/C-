using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Linq
{
    // Initialize a class where we can iterate through
    public class Params : IEnumerable<int>
    {
        private int a, b, c;

        public Params(int a, int b, int c)
        {
            this.a = a;
            this.b = b;
            this.c = c;
        }

        public IEnumerator<int> GetEnumerator()
        {
            yield return a;
            yield return b;
            yield return c;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }


    public class Person
    {
        private readonly string firstName;
        private readonly string middleName;
        private readonly string lastName;

        public Person(string firstName, string middleName, string lastName)
        {
            this.firstName = firstName;
            this.middleName = middleName;
            this.lastName = lastName;
        }

        public IEnumerable<string> Names
        {
            get
            {
                yield return firstName;
                yield return middleName;
                yield return lastName;
            }
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            var p = new Params(1, 2, 3);
            Output(p, "IEnumerable");

            var person = new Person("Bob", "Lennon", "Le rouge");
            Output(person.Names);


            // Empty operator
            Output(Enumerable.Empty<int>(), "Empty");


            // Repeat operator
            Output(Enumerable.Repeat("Hello", 3), "Repeat");


            // Range operator
            Output(Enumerable.Range(1, 10), "Range");
            Output(Enumerable.Range('a', 'z' + 1 - 'a').Select(c => (char)c));
            Output(Enumerable.Range(1, 10).Select(i => new string('x', i)));


            // Cast operators
            var numbers = Enumerable.Range(1, 10);
            Output(numbers.ToArray(), "Cast"); // or ToList

            var dic = numbers.ToDictionary(i => (double)i / 10, i => i % 2 == 0);
            Output(dic);

            var arr = new[] { 1, 2, 3 };
            Output(arr.AsEnumerable()); // AsQueryable


            // MAPPING

            // Select
            var numbers2 = Enumerable.Range(1, 10);
            var squares = numbers2.Select(x => x * x);
            Output(squares, "Select");

            var sentence = "This is a nice sentence";
            var wordWithLength = sentence.Split().Select(w => new { Word = w, Size = w.Length });
            Output(wordWithLength);

            var random = new Random();
            var randomNumbers = Enumerable.Range(1, 10).Select(_ => random.Next(10));
            Output(randomNumbers);


            // SelectMany
            // Map and flatten the result
            var sequences = new[] { "red,green,blue", "orange", "white,pink" };
            var allWords = sequences.SelectMany(s => s.Split(',')); // Select would have give us an IEnumerable of strings arrays because of Split
            Output(allWords, "SelectMany");

            // Generate pairwise construction of 2 lists.
            var objects = new[] { "house", "car", "bicycle" };
            var colors = new[] { "red", "green", "gray" };
            var pairs = colors.SelectMany(_ => objects, (color, obj) => new { color, obj });
            Output(pairs);


            // FILTERING

            // Where
            var numbers3 = Enumerable.Range(1, 10);
            var oddSquares = numbers.Select(x => x * x).Where(y => y % 2 == 0);
            Output(oddSquares, "Where");


            // OfType<>
            object[] values = { 1, 2.5, 3, 4.56 };
            var integers = values.OfType<int>();
            Output(integers, "OfType");


            // Exercise
            Output(Exercise.MyFilter(Enumerable.Range(1, 10)), "Exercise");


            // SORTING

            // OrderBy
            var randoms2 = new Random();
            var randomValues = Enumerable.Range(1, 10).Select(_ => random.Next(10) - 5);
            var csvString = new Func<IEnumerable<int>, string>(values =>
            {
                var test = string.Join(',', values.Select(v => v.ToString()));
                return test;
            });
            Output(csvString(randomValues.OrderBy(x => x)), "OrderBy");

            
            IOrderedEnumerable<int> valOrderedByDescending = randomValues.OrderByDescending(x => x);
            Output(csvString(valOrderedByDescending), "OrderByDescending");


            // ThenBy
            // OrderBy return an IOrderedEnumerable instead of an IEnumerable
            // Allow to order by a second criteria or more with ThenBy
            var people = new[] { 
                new { name = "Adam", age = 36 },
                new { name = "Boris", age = 18 },
                new { name = "Zoe", age = 20 },
                new { name = "Claire", age = 36 },
                new { name = "Adam", age = 20 },
                new { name = "Jack", age = 20 },
            };
            Output(people.OrderBy(p => p.age).ThenByDescending(p => p.name), "ThenBy");


            // Reverse
            var s = "This is a test";
            Output(new string(s.Reverse().ToArray()), "Reverse");


            // GROUPING

        }

        static void Output<T>(IEnumerable<T> list, string linqOperator = "")
        {
            var separator = String.Join("-", Enumerable.Range(1, 40).Select(x => String.Empty));

            if (!string.IsNullOrEmpty(linqOperator))
            {
                Console.WriteLine(separator);
                Console.WriteLine(linqOperator);
                Console.WriteLine(separator);
            }

            foreach (var l in list)
            {
                Console.WriteLine(l);
            }

            Console.WriteLine(String.Empty);
        }

        static void Output(string value, string linqOperator = "")
        {
            var separator = String.Join("-", Enumerable.Range(1, 40).Select(x => String.Empty));

            if (!string.IsNullOrEmpty(linqOperator))
            {
                Console.WriteLine(separator);
                Console.WriteLine(linqOperator);
                Console.WriteLine(separator);
            }

            Console.WriteLine(value);

            Console.WriteLine(String.Empty);
        }

        public class Exercise
        {
            public static IEnumerable<int> MyFilter(IEnumerable<int> input)
            {
                return input
                    .Where(i => i % 2 == 0)
                    .Select(i => i * i)
                    .Where(i => i < 50);
            }
        }
    }
}
