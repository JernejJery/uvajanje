using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Script.Serialization;
using System.IO;


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

        static object toFile(object obj) //objekt -> json
        {
            var json = new JavaScriptSerializer().Serialize(obj);

            System.IO.File.WriteAllText("out.txt", json.ToString());
            return json;
        }

        static object toObject(string json) //json -> objekt
        {
            JavaScriptSerializer oJS = new JavaScriptSerializer();
            object oRootObject = new object();
            oRootObject = oJS.Deserialize<object>(json);

            return oRootObject;
        }


        static void Main()
        {
            var obj = new Person
            {
                firstName = "Jernej",
                lastName = "Orovič",
                dateOfBirth = new Date
                {
                    y = 1996,
                    m = 8,
                    d = 8
                }
            };
            try
            {
                string s = System.IO.File.ReadAllText("oudt.txt");
                toObject(s);
            }
            catch (Exception e) when (e.Message.Contains("Could not find file"))
            {
                Console.WriteLine("No file found");
            }
            

            Console.WriteLine(toFile(obj).ToString());

            Console.ReadKey();
        }
    }
}