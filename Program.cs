using System;
using System.Collections.Generic;
using System.Web;
//using System.Web.Extensions;
using System.Web.Script.Serialization;

namespace uvajanje_JSON
{
    public class Date
    {
        public int y;
        public int m;
        public int d;
    }

    public class Person
    {
        public string firstName;
        public string lastName;
        public Date dateOfBirth;
    }

    class Program
    {
        static void Main()
        {
            var obj = new Person
            {
                firstName = "Markoff",
                lastName = "Chaney",
                dateOfBirth = new Date
                {
                    y = 1996,
                    m = 8,
                    d = 8
                }
            };
            var json = new JavaScriptSerializer().Serialize(obj);
            Console.WriteLine(json);

            Console.ReadKey();
        }
    }
}