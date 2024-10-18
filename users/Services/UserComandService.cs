using Recapitulare_Patterns.users.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recapitulare_Patterns.users.Services
{
    public class UserComandService : IUserCommandService
    {

        private IUserRepo _repo;

        public UserComandService(IUserRepo userQueryService)
        {
            this._repo = userQueryService;


        }

        public User Add(User user)
        {
            User  searchedUser=this._repo.FindUserByUsername(user.Username);
            if (searchedUser==null)
            {

               return this._repo.AddUser(user);

            }
            return null;


        }

        public User Delete(int id)
        {
            User finduser = this._repo.FindUserById(id);

            if (finduser != null)
            {
                this._repo.DeleteUser(id);
                return finduser;


            }
            return null;           
        }

        public User UpdateUser(User user)
        {

            User update = _repo.FindUserById(user.Id);
            if(update != null)
            {

                this._repo.UpdateUser(user);
                return update;


            }
            return null;

        }




    }
}
