using McShippersWebsite.DTOs;
using McShippersWebsite.Models;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace McShippersWebsite.Interfaces
{
    public interface IUserRepository
    {
        List<ApplicationUser> GetAll();

        ApplicationUser GetById(string id);

        Task<IdentityResult> Insert( RegisterDTO obj);

        int Update(string id, ApplicationUser obj);

        int Delete(string id);
    }
}
