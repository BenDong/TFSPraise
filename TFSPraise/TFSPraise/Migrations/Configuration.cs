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
            var praises = new List<Praise>
            {
                new Praise { Content = "testing content 1", OwnerID = "P0057731", PraiseDate = DateTime.Now, ReceivierID = "P0057739", PraiseID = 1 },
                new Praise { Content = "testing content 2", OwnerID = "P0057732", PraiseDate = DateTime.Now, ReceivierID = "P0057738", PraiseID = 2 },
                new Praise { Content = "testing content 3", OwnerID = "P0057733", PraiseDate = DateTime.Now, ReceivierID = "P0057737", PraiseID = 3 },
                new Praise { Content = "testing content 4", OwnerID = "P0057734", PraiseDate = DateTime.Now, ReceivierID = "P0057736", PraiseID = 4 },
                new Praise { Content = "testing content 5", OwnerID = "P0057735", PraiseDate = DateTime.Now, ReceivierID = "P0057735", PraiseID = 5 },
                new Praise { Content = "testing content 6", OwnerID = "P0057736", PraiseDate = DateTime.Now, ReceivierID = "P0057734", PraiseID = 6 },
                new Praise { Content = "testing content 7", OwnerID = "P0057737", PraiseDate = DateTime.Now, ReceivierID = "P0057733", PraiseID = 7 },
                new Praise { Content = "testing content 8", OwnerID = "P0057738", PraiseDate = DateTime.Now, ReceivierID = "P0057732", PraiseID = 8 },
                new Praise { Content = "testing content 9", OwnerID = "P0057739", PraiseDate = DateTime.Now, ReceivierID = "P0057731", PraiseID = 9 }
            };
            praises.ForEach(p => context.Praises.Add(p));
            context.SaveChanges();

            var employees = new List<Employee>
            {
                new Employee { Name = "Ben Dong", ID = "P0057731", ResignFlag = false },
                new Employee { Name = "JackTmc", ID = "P0057732", ResignFlag = false },
                new Employee { Name = "Hugo Hu", ID = "P0057733", ResignFlag = false },
                new Employee { Name = "Alan Wang", ID = "P0057734", ResignFlag = false },
                new Employee { Name = "Wil Brady", ID = "P0057735", ResignFlag = false },
                new Employee { Name = "Will Lennon", ID = "P0057736", ResignFlag = false },
                new Employee { Name = "Jhon Brig", ID = "P0057737", ResignFlag = false },
                new Employee { Name = "J Wyman", ID = "P0057738", ResignFlag = false },
                new Employee { Name = "Youhana Saad", ID = "P0057739", ResignFlag = false },
            };
            employees.ForEach(e => context.Employees.Add(e));
            context.SaveChanges();

            var blogs = new List<Blog>
            {
                new Blog { Content = "Blog Content 1", BlogTime = DateTime.Now, OwnerID = "P0057731" },
                new Blog { Content = "Blog Content 2", BlogTime = DateTime.Now, OwnerID = "P0057732" },
                new Blog { Content = "Blog Content 3", BlogTime = DateTime.Now, OwnerID = "P0057733" },
                new Blog { Content = "Blog Content 4", BlogTime = DateTime.Now, OwnerID = "P0057734" },
                new Blog { Content = "Blog Content 5", BlogTime = DateTime.Now, OwnerID = "P0057735" },
                new Blog { Content = "Blog Content 6", BlogTime = DateTime.Now, OwnerID = "P0057736" },
                new Blog { Content = "Blog Content 7", BlogTime = DateTime.Now, OwnerID = "P0057737" },
                new Blog { Content = "Blog Content 8", BlogTime = DateTime.Now, OwnerID = "P0057738" },
                new Blog { Content = "Blog Content 9", BlogTime = DateTime.Now, OwnerID = "P0057739" },
            };
            blogs.ForEach(b => context.Blogs.Add(b));
            context.SaveChanges();
        }
    }
}
