using System;
using System.Collections.Generic;
using System.Text;

namespace Dados
{
    class DbInitializer
    {
        public static void Initialize(DatabaseContext context)
        {
            context.Database.EnsureCreated();

            //if (!context.Access.Any())
            //{
            //    context.Access.Add(new Access { Name = "Marketing" });
            //    context.SaveChanges();
            //}

            //if (context.Roles.FirstOrDefault() == null)
            //{
            //    context.Roles.Add(new IdentityRole("Users"));
            //    context.SaveChanges();
            //}
        }
    }
}
