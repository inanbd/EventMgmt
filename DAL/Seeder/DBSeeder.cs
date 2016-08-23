using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using DAL;

namespace DAL.Seeder
{
    public class DBSeeder : DropCreateDatabaseIfModelChanges<EMDbContext>
    {
        protected override void Seed(EMDbContext context)
        {
            base.Seed(context);


            User usr = new User()
            {
                
                UserName = "admin",
                FirstName = "admin",
                LastName = "admin",
                Email = "admin@event.com",
                Password = "admin",
                ConfirmPassword="admin",
                UserType="admin",
                Address="default address",
                ContactNumber="01741497189"
                
                
            };

            User usr2 = new User()
            {
                
                UserName = "customer",
                FirstName = "customer",
                LastName = "customer",
                Email = "customer@event.com",
                Password = "customer",
                ConfirmPassword = "customer",
                UserType = "customer",
                Address = "default address",
                ContactNumber = "01741497189"

            };
            context.Users.Add(usr);
            context.Users.Add(usr2);
            context.SaveChanges();

            Event evnt = new Event()
            {
                EventTitle = "test",
                user = usr,
                UserId = usr.UserId
            };
            //context.Events.Add(evnt);

            
            
            context.SaveChanges();
        }
    }
}