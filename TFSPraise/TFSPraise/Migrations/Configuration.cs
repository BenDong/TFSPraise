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
                new User { Name = "Jhon Brig", ID = "P0057737", Resign = false },
                new User { Name = "J Wyman", ID = "P0057738", Resign = false },
                new User { Name = "Youhana Saad", ID = "P0057739", Resign = false },
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
                new Receiver { Name = "Jhon Brig", ReceiverID = "P0057737", Resign = false },
                new Receiver { Name = "J Wyman", ReceiverID = "P0057738", Resign = false },
                new Receiver { Name = "Youhana Saad", ReceiverID = "P0057739", Resign = false },
            };
            receivers.ForEach(r => context.Receivers.Add(r));
            context.SaveChanges();

            var blogs = new List<Blog>
            {
                new Blog { Content = "Blog Content 1", PublishDate = DateTime.Now, Publisher = users.FirstOrDefault() },
                new Blog { Content = "Blog Content 2", PublishDate = DateTime.Now, Publisher = users.Skip(1).FirstOrDefault() },
                new Blog { Content = "Blog Content 3", PublishDate = DateTime.Now, Publisher = users.Skip(2).FirstOrDefault() },
                new Blog { Content = "Blog Content 4", PublishDate = DateTime.Now, Publisher = users.Skip(3).FirstOrDefault() },
                new Blog { Content = "Blog Content 5", PublishDate = DateTime.Now, Publisher = users.Skip(4).FirstOrDefault() },
                new Blog { Content = "Blog Content 6", PublishDate = DateTime.Now, Publisher = users.Skip(5).FirstOrDefault() },
                new Blog { Content = "Blog Content 7", PublishDate = DateTime.Now, Publisher = users.Skip(6).FirstOrDefault() },
                new Blog { Content = "Blog Content 8", PublishDate = DateTime.Now, Publisher = users.Skip(7).FirstOrDefault() },
                new Blog { Content = "Blog Content 9", PublishDate = DateTime.Now, Publisher = users.Skip(8).FirstOrDefault() },
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
