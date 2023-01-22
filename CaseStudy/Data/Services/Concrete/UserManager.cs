using CaseStudy.Data.Base;
using CaseStudy.Data.Services.Abstract;
using CaseStudy.Models;

namespace CaseStudy.Data.Services.Concrete
{
    public class UserManager : EntityBaseRepository<User>, IUserService
    {
        public UserManager(AppDbContext context) : base(context)
        {
        }
    }
}
