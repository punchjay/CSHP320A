using System;
using System.Collections.Generic;
using System.Linq;

namespace homework02
{
    class Program
    {
        static void Main(string[] args)
        {
            var users = new List<Models.User>
            {
                new Models.User { Name = "Dave", Password = "hello" },
                new Models.User { Name = "Steve", Password = "steve" },
                new Models.User { Name = "Lisa", Password = "hello" }
            };

            //using lambda operator same query as below
            var QueryPasswordHello = users.Where(password => password.Password == "hello");

            //var QueryPasswordHello = 
            //    from password in users
            //    where password.Password == "hello"
            //    select password;

            users.ForEach(i => Console.Write($"Name: {i.Name} - Password: {i.Password}\t"));
            Console.WriteLine(QueryPasswordHello.Count());
        }
    }
}
 