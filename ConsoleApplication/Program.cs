using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IO.Swagger.Api;

namespace ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            var api = new DefaultApi("http://petstore.swagger.io/api");

            var pets = api.FindPets();

            Console.WriteLine("Found {0} pets.", pets.Count);
        }
    }
}
