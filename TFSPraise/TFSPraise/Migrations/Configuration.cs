namespace TFSPraise.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Collections.Generic;
    using System.Linq;
    using TFSPraise.Entities;

    internal sealed class Configuration : DbMigrationsConfiguration<TFSPraise.Concrete.TFSPraiseContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(TFSPraise.Concrete.TFSPraiseContext context)
        {

            var users = new List<User>
            {
                new User { Name = "Ben Dong", ID = "P0057731", Resign = false },
                new User { Name = "JackTmc", ID = "P0057732", Resign = false },
                new User { Name = "Hugo Hu", ID = "P0057733", Resign = false },
                new User { Name = "Alan Wang", ID = "P0057734", Resign = false },
                new User { Name = "Wil Brady", ID = "P0057735", Resign = false },
                new User { Name = "Will Lennon", ID = "P0057736", Resign = false },
                new User { Name = "John Brig", ID = "P0057737", Resign = false },
                new User { Name = "J Wyman", ID = "P0057738", Resign = false },
                new User { Name = "Youhana Saad", ID = "P0057739", Resign = false }
            };
            users.ForEach(u => context.Users.Add(u));
            context.SaveChanges();

            var receivers = new List<Receiver>
            {
                new Receiver { Name = "Ben Dong", ReceiverID = "P0057731", Resign = false },
                new Receiver { Name = "JackTmc", ReceiverID = "P0057732", Resign = false },
                new Receiver { Name = "Hugo Hu", ReceiverID = "P0057733", Resign = false },
                new Receiver { Name = "Alan Wang", ReceiverID = "P0057734", Resign = false },
                new Receiver { Name = "Wil Brady", ReceiverID = "P0057735", Resign = false },
                new Receiver { Name = "Will Lennon", ReceiverID = "P0057736", Resign = false },
                new Receiver { Name = "John Brig", ReceiverID = "P0057737", Resign = false },
                new Receiver { Name = "J Wyman", ReceiverID = "P0057738", Resign = false },
                new Receiver { Name = "Youhana Saad", ReceiverID = "P0057739", Resign = false }
            };
            receivers.ForEach(r => context.Receivers.Add(r));
            context.SaveChanges();

            var blogs = new List<Blog>
            {
                new Blog { Title ="DROP TABLE (Transact-SQL)", Content = "Removes one or more table definitions and all data, indexes, triggers, constraints, and permission specifications for those tables. Any view or stored procedure that references the dropped table must be explicitly dropped by using DROP VIEW or DROP PROCEDURE. To report the dependencies on a table, use sys.dm_sql_referencing_entities.",
                    PublishDate = DateTime.Now.AddDays(-1),
                    Publisher = users.FirstOrDefault()
                },
                new Blog { Title="How to: Send Data Using the WebRequest Class",
                    Content = "The following procedure describes the steps used to send data to a server. This procedure is commonly used to post data to a Web page.",
                    PublishDate = DateTime.Now.AddDays(-3),
                    Publisher = users.Skip(1).FirstOrDefault()
                },
                new Blog { Title = "How to: Request a Web Page and Retrieve the Results as a Stream",
                    Content = "This example shows how to request a Web page and retrieve the results in a stream./n WebClient myClient = new WebClient(); /n Stream response = myClient.OpenRead(\"http://www.contoso.com/index.htm\");",
                    PublishDate = DateTime.Now.AddDays(4),
                    Publisher = users.Skip(2).FirstOrDefault()
                },
                new Blog { Title ="Creating Internet Requests", Content = "Applications create WebRequest instances through the WebRequest.Create method. This is a static method that creates a class derived from WebRequest based on the URI scheme passed to it.",
                    PublishDate = DateTime.Now,
                    Publisher = users.Skip(3).FirstOrDefault()
                },
                new Blog { Title = "Handling Errors",
                    Content = "The WebRequest and WebResponse classes throw both system exceptions (such as ArgumentException) and Web-specific exceptions (which are WebExceptions thrown by the GetResponse method).",
                    PublishDate = DateTime.Now.AddHours(4), Publisher = users.Skip(4).FirstOrDefault() },
                new Blog { Title = "Making Asynchronous Requests", Content = "The System.Net classes use the .NET Framework's standard asynchronous programming model for asynchronous access to Internet resources. The BeginGetResponse and EndGetResponse methods of the WebRequest class start and complete asynchronous requests for an Internet resource.",
                    PublishDate = DateTime.Now.AddMonths(3), Publisher = users.Skip(5).FirstOrDefault() },
                new Blog { Title = "Using Streams on the Network", Content = "Network resources are represented in the .NET Framework as streams. By treating streams generically, the .NET Framework offers the following capabilities: ",
                    PublishDate = DateTime.Now.AddYears(-1), Publisher = users.Skip(6).FirstOrDefault() },
                new Blog { Title = "A common way to send and receive Web data", Content = " Whatever the actual contents of the file — HTML, XML, or anything else — your application will use Stream.Write and Stream.Read to send and receive data",
                    PublishDate = DateTime.Now.AddMonths(-1), Publisher = users.Skip(7).FirstOrDefault() },
                new Blog { Title ="Using Streams on the Network", Content = "This example shows how to retrieve a protocol-specific WebResponse that matches a WebRequest.",
                    PublishDate = DateTime.Now.AddDays(1),
                    Publisher = users.Skip(8).FirstOrDefault() }
            };
            blogs.ForEach(b => context.Blogs.Add(b));
            context.SaveChanges();

            var praises = new List<Praise>
            {
                new Praise { PraiseContent = "Praise content 1", OwnerID = "P0057731", PraiseDate = DateTime.Now,
                    Receivers = receivers },
                new Praise { PraiseContent = "Praise content 2", OwnerID = "P0057732", PraiseDate = DateTime.Now,
                    Receivers = receivers.Take(4).ToList() },
                new Praise { PraiseContent = "Praise content 3", OwnerID = "P0057733", PraiseDate = DateTime.Now,
                    Receivers = receivers.Take(2).ToList()},
                new Praise { PraiseContent = "Praise content 4", OwnerID = "P0057734", PraiseDate = DateTime.Now,
                    Receivers = receivers.Skip(4).Take(3).ToList() },
                new Praise { PraiseContent = "Praise content 5", OwnerID = "P0057735", PraiseDate = DateTime.Now,
                    Receivers = receivers.Where(r => r.Name == "JackTmc" || r.Name == "Ben Dong").ToList() },
                new Praise { PraiseContent = "Praise content 6", OwnerID = "P0057736", PraiseDate = DateTime.Now,
                    Receivers = receivers.Skip(1).Take(2).ToList() },
                new Praise { PraiseContent = "Praise content 7", OwnerID = "P0057737", PraiseDate = DateTime.Now,
                    Receivers = receivers.Skip(2).Take(2).ToList() },
                new Praise { PraiseContent = "Praise content 8", OwnerID = "P0057738", PraiseDate = DateTime.Now,
                    Receivers = receivers.Skip(5).Take(2).ToList() },
                new Praise { PraiseContent = "Praise content 9", OwnerID = "P0057739", PraiseDate = DateTime.Now,
                    Receivers = receivers.Skip(1).Take(1).ToList()}
            };
            praises.ForEach(p => context.Praises.Add(p));
            context.SaveChanges();

        }
    }
}
