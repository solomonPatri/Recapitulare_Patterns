using Recapitulare_Patterns.users.exceptions;
using Recapitulare_Patterns.users.models;
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

        IUserRepo _repo;
        public UserComandService()
        {
            this._repo = UserFactory.CreateUserService<IUserRepo>();

        }

        public User Add(User user)
        {
            User  searchedUser=this._repo.FindUserByUsername(user.Username);
            if (searchedUser==null)
            {

               return this._repo.AddUser(user);
                

            }

            throw new UserAlreadyExistException();


        }

        public User Delete(int id)
        {
            User finduser = this._repo.FindUserById(id);

            if (finduser != null)
            {
                this._repo.DeleteUser(id);
                return finduser;


            }

            throw new UserNotFoundException();
        }

        public User UpdateUser(User user)
        {

            User update = _repo.FindUserById(user.Id);
            if (update != null)
            {
         
                    this._repo.UpdateUser(user);
                throw new UserNotUpdateException();   //exista dar nu se poate moficia


            }

            throw new UserNotFoundException(); // nu exista atunci returnam mesajul Doesm't Exist!!!
            

        }




    }
}
