# CSHP320A

homework02

Create a console application and use the following snippet of code.

Create a Models directory and copy the User class from the Data Binding topic.

```var users = new List<Models.User>();

users.Add(new Models.User { Name = "Dave", Password="hello" });
users.Add(new Models.User { Name = "Steve", Password="steve" });
users.Add(new Models.User { Name = "Lisa", Password="hello" });```

Use System.Linq for all the requirements. IE. Don't use a for/foreach loop to manipulate the users list.

1. Display to the console, the names of the users where the password is "hello". Hint: Where

2. Delete any passwords that are the lower-cased version of their Name. Do not just look for "steve". It has to be data-driven. Hint: Remove or RemoveAll

3. Delete the first User that has the password "hello". Hint: First or FirstOrDefault

4. Display to the console the remaining users with their Name and Password.