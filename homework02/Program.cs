using System;
using System.Collections.Generic;
using System.Linq;

namespace homework02
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Models.User> Users = new List<Models.User>();

            Users.Add(new Models.User { Name = "Dave", Password = "hello" });
            Users.Add(new Models.User { Name = "Steve", Password = "steve" });
            Users.Add(new Models.User { Name = "Lisa", Password = "hello" });

            Users.ForEach(user => Console.Write($"Name: {user.Name} - Password: {user.Password}\n"));
            Console.WriteLine("\n");

            //var QueryPasswordHello =
            //    from user in Users
            //    where user.Password == "hello"
            //    select user;

            //using lambda operator same query as above
            var QueryPasswordHello = Users.Where(user => user.Password == "hello");
            Console.WriteLine("Users where the password is 'hello':");
            foreach (var user in QueryPasswordHello)
            {
                Console.WriteLine(user.Name);
            }
            Console.WriteLine("\n");

            var QuerySameNameAsPassord = Users.Where(user => user.Name.ToLower() == user.Password);
            Console.WriteLine(QuerySameNameAsPassord.Count());
            Users.Remove(new Models.User { Name = "Dave", Password = "hello" });
            foreach (var user in Users)
            {

                Console.WriteLine(user.Name);
            }

            //Users.ForEach(user => Console.Write($"Name: {user.Name} - Password: {user.Password}\n"));

        }
    }
}
