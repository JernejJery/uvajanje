using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using static System.String; //using static

namespace uvajanje
{
    class Program
    {

        class Person
        {
            public string firstName { get; }    //Read-only auto-properties
            public string lastName { get; }

            public string someString { get; set; }

            public int age { get; set; } = -1; //Auto-Property Initializers

            public string FullName => $"{lastName}, {firstName}"; //Expression-bodied function members

            public Person(string firstName1, string lastName1) //constuctor
            {
                if (String.IsNullOrWhiteSpace(lastName1))
                    throw new ArgumentException(message: "Cannot be blank", paramName: nameof(lastName1)); //nameof Expressions
                this.firstName = firstName1;
                this.lastName = lastName1;
            }

        }

        public static async Task<string> MakeRequestWithNotModifiedSupport() //Await in Catch and Finally blocks
        {
            var client = new System.Net.Http.HttpClient();
            var streamTask = client.GetStringAsync("https://localHost:10000");
            try
            {
                var responseText = await streamTask;
                return responseText;
            }
            catch (System.Net.Http.HttpRequestException e) when (e.Message.Contains("404")) //Exception Filters
            {
                await logError("Recovered from redirect", e);
                return "Not found!";
            }
            finally
            {
                await logMethodExit();
                client.Dispose();
            }
        }

        private static Task logError(string v, HttpRequestException e)
        {
            throw new NotImplementedException();
        }

        private static Task logMethodExit()
        {
            throw new NotImplementedException();
        }

        static List<Person> all = new List<Person>();

        static void Enroll(Person s)
        {
            all.Add(s);
        }

        //static void Add(this List<Person> e, Person s) => Enroll(s); //Extension Add methods in collection initializers

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Person p = new Person("jernej", "orovic");
            Console.WriteLine(p.FullName);

            //p.someString = "asd";

            var SomeString = p?.someString; //Null-conditional operators
            Console.WriteLine(SomeString);

            string some = nameof(SomeString); //nameof Expressions

            string stringInterpolation = $"{p.FullName} and some string: {p.someString}"; //String Interpolation

            Dictionary<int, string> webErrors = new Dictionary<int, string> //Index Initializers
            {
                [10] = "Highest grade",
                [1] = "Lowest grade",
                [6] = "You passed"
            };

            Person p2 = new Person(some, "dfg");
            Person p3 = new Person("asd", "dfg");


            List<Person> list = new List<Person>();
            list.Add(p);
            list.Add(p2);


            Console.ReadKey();
        }
    }
}