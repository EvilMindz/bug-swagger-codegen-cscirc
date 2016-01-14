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
            var api = new DefaultApi("http://petstore.swagger.io/v2/");
            api.Configuration.ApiKey.Add("api-key","special-key");

            var pet = api.FindPetById(1);

            Console.WriteLine("Found {0} pet.", pet == null ? "no" : pet.Name);
            Console.ReadLine();
        }
    }
}
