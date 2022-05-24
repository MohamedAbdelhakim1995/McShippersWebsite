using McShippersWebsite.DTOs;
using McShippersWebsite.Interfaces;
using McShippersWebsite.Models;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace McShippersWebsite.Repository
{
    public class UserRepository:IUserRepository
    {
        private readonly Context context;
        private readonly UserManager<ApplicationUser> userManager;

        public UserRepository(Context context,UserManager<ApplicationUser> userManager)
        {
            this.context = context;
            this.userManager = userManager;
        }
        public int Delete(string id)
        {
            ApplicationUser p = context.applicationUser.FirstOrDefault(p => p.Id == id);
            context.applicationUser.Remove(p);
            return context.SaveChanges();
        }

        public List<ApplicationUser> GetAll()
        {
            return context.applicationUser.ToList();
        }

        public ApplicationUser GetById(string id)
        {
            return context.applicationUser.FirstOrDefault(p => p.Id == id);
        }



        public async Task<IdentityResult> Insert(RegisterDTO obj)
        {
            ApplicationUser newUser = new ApplicationUser();
            newUser.UserName = obj.UserName;
            newUser.Email = obj.Email;



            IdentityResult result = await userManager.CreateAsync(newUser, obj.Password);

            return result;

          
        }

        public int Update(string id, ApplicationUser obj)
        {
            ApplicationUser p = context.applicationUser.FirstOrDefault(c => c.Id == id);

            p.UserName = obj.UserName;


            return context.SaveChanges();
        }
    }
}
