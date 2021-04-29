using System;
using System.Collections.Generic;
using System.Linq;

namespace homework02
{
    class Program
    {
        static void Main(string[] args)
        {
            var Users = new List<Models.User>
            {
                new Models.User { Name = "Dave", Password = "hello" },
                new Models.User { Name = "Steve", Password = "steve" },
                new Models.User { Name = "Lisa", Password = "hello" }
            };

            //Users.ForEach(user => Console.Write($"Name: {user.Name} - Password: {user.Password}\t"));

            //using lambda operator same query as below
            var QueryPasswordHello = Users.Where(user => user.Password == "hello");

            //var QueryPasswordHello =
            //    from user in Users
            //    where user.Password == "hello"
            //    select user;

            foreach (var user in QueryPasswordHello)
            {
                Console.WriteLine(user.Name);
            }
        }
    }
}
