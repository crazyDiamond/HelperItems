using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wantify.Web.Core.Database;
using Wantify.Web.Core.Services;
using Wantify.Web.Shared.Model;

namespace Wantify.UserManager
{
    class Program
    {
        static void Main(string[] args)
        {
            Task.WaitAll(MainAsync(args));
            Console.ReadKey();
        }

        static async Task MainAsync(string[] args)
        {
            var context = new WantifyDbContext();
            var userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(context));

            var username = "jeeva_nadarajah@yahoo.com";
            var password = "Password!1";

            var user = await userManager.FindAsync(username, password);

            if(user != null)
            {
                await userManager.DeleteAsync(user);
                Console.WriteLine("Deleted user successfully! {0}", username);
            }
            else
            {
                Console.WriteLine("User not found {0}", username);
            }
        }
    }
}
