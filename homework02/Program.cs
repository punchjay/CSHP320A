using System;
using System.Collections.Generic;
using System.Linq;

namespace homework02
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Models.User> Users = new List<Models.User>
            {
                new Models.User { Name = "Dave", Password = "hello" },
                new Models.User { Name = "Steve", Password = "steve" },
                new Models.User { Name = "Jay", Password = "Jay" },
                new Models.User { Name = "bob", Password = "bob" },
                new Models.User { Name = "Tom", Password = "tom" },
                new Models.User { Name = "Lisa", Password = "hello" }
            };

            //var QueryPasswordHello =
            //    from user in Users
            //    where user.Password.ToUpper() == "HELLO"
            //    select user;

            //using lambda operator same query as above
            var QueryPasswordHello = Users.Where(user => user.Password.ToUpper() == "HELLO");
            Console.WriteLine("Users where the password is 'hello':");
            foreach (var user in QueryPasswordHello) Console.WriteLine(user.Name);
            Console.WriteLine("\n");

            var QuerySameNameAsPassword = Users.Where(user => user.Name.ToLower() == user.Password);
            Console.WriteLine("Users where lower-cased password version of their name:");
            foreach (var user in QuerySameNameAsPassword)
            {
                Console.WriteLine(user.Name);
                user.Password = "";
            }
            Console.WriteLine("\n");

            var QueryFirstPasswordHello = Users.FirstOrDefault(user => user.Password.ToUpper() == "HELLO");
            Console.WriteLine("First user that has the password 'hello':");
            Console.WriteLine(QueryFirstPasswordHello.Name);
            Console.WriteLine("\n");
            Users.Remove(QueryFirstPasswordHello);

            Console.WriteLine("Users remaining:");
            Users.ForEach(user => Console.Write($"Name: {user.Name} - Password: {user.Password}\n"));
        }
    }
}
